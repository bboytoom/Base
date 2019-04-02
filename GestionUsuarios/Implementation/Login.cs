using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Implementation
{
    public class CheckEmailImp : ICheckEmail
    {
        private DataModels ctx;
        private CheckEmailImp()
        {
            ctx = new DataModels();
        }

        public string CheckEmail(string Email)
        {
            string email_clean = "";

            if (Email == "")
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            email_clean = WebUtility.HtmlEncode(Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            try
            {
                var query = ctx.Tbl_Correos
                        .Where(s => s.email_correo == email_clean)
                        .FirstOrDefault();

                if (query == null)
                    return JsonConvert.SerializeObject(
                        new OutJsonCheck
                        {
                            Status = 404,
                            Respuesta = false
                        }
                    );

                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 200,
                        Respuesta = true
                    }
                );
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class LoginImp : ILogin
    {
        private DataModels ctx;
        private LoginImp()
        {
            ctx = new DataModels();
        }

        public string Login(string Email, string Password)
        {
            string email_clean = "";
            string password_clean = "";

            if (Email == "" || Password == "")
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            email_clean = WebUtility.HtmlEncode(Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            password_clean = HEncrypt.PasswordEncryp(Password);

            var query = ctx.Tbl_Usuarios.Join(ctx.Tbl_Correos,
                        pkusuario => pkusuario.id,
                        fkusuario => fkusuario.id_usuario,
                        (pkusuario, fkusuario) => new
                        {
                            User_table = pkusuario,
                            Email_table = fkusuario
                        })
                        .Where(s => s.Email_table.email_correo == email_clean && s.User_table.password_usuario == password_clean)
                        .FirstOrDefault();

            if (query == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            return JsonConvert.SerializeObject(
                new OutJsonCheck
                {
                    Status = 200,
                    Respuesta = true
                }
            );
        }
    }
}
