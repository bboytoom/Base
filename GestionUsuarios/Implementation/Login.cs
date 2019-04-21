using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

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
            string email_clean;
            
            if (Email == "" || Email == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 200,
                        Respuesta = false
                    }
                );

            email_clean = WebUtility.HtmlEncode(Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 200,
                        Respuesta = false
                    }
                );

            try
            {
                var query = ctx.Tbl_Correos.Where(w => w.email_correo == email_clean).FirstOrDefault();

                if (query == null)
                    return JsonConvert.SerializeObject(
                        new OutJsonCheck
                        {
                            Status = 200,
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
                CustomErrorDetail customError = new CustomErrorDetail(500, "Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }

    public class LoginImp 
    {
        private DataModels ctx;
        public LoginImp()
        {
            ctx = new DataModels();
        }

        public Tbl_Usuarios Login(ViewModelsLogin data)
        {
            string password_clean;
            
            password_clean = HEncrypt.PasswordEncryp(data.Password);

            return ctx.Tbl_Usuarios.Join(ctx.Tbl_Correos,
                    pkusuario => pkusuario.id, fkusuario => fkusuario.id_usuario,
                    (pkusuario, fkusuario) => new
                    {
                        User_table = pkusuario,
                        Email_table = fkusuario
                    })
                    .Where(w => w.Email_table.email_correo == data.Email && w.User_table.password_usuario == password_clean)
                    .Select(s => s.User_table).FirstOrDefault();
        }
    }
}
