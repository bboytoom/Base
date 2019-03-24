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

            throw new NotImplementedException();
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
            password_clean = HEncrypt.PasswordEncryp(Password);

            throw new NotImplementedException();
        }
    }
}
