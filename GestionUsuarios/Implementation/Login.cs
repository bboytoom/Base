using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using Newtonsoft.Json;
using System;
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
            string email_clean = "";
            
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
                CustomErrorDetail customError = new CustomErrorDetail("Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
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

            if (Email == null || Password == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Email == "" || Password == "")
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            email_clean = WebUtility.HtmlEncode(Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
            {
                CustomErrorDetail customError = new CustomErrorDetail("Email no valido", "El correo ingresado no es valido");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.UnsupportedMediaType);
            }
            
            try
            {
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
                {
                    CustomErrorDetail customError = new CustomErrorDetail("Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                    throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
                }

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
                CustomErrorDetail customError = new CustomErrorDetail("Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }
}
