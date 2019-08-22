using Administrator.Manager.Helpers;
using Administrator.Query;
using System;
using System.Net;

namespace Administrator.Manager
{
    public class ProfilesImp
    {
        private Profiles ObjPerfile;

        public ProfilesImp()
        {
            ObjPerfile = new Profiles();
        }


        public bool Check(int id, string password)
        {
            string password_cryp;

            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(password, "El argumento se encuentra vacio");

            password_cryp = HEncrypt.PasswordEncryp(password);

            return ObjPerfile.Check(id, password_cryp);
        }

        public bool ChangeEmail(int id, string email)
        {
            string email_clean;

            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email, "El argumento esta vacio o es nulo");

            email_clean = WebUtility.HtmlEncode(email).ToLower();

            if (!HCheckEmail.EmailCheck(email_clean))
                throw new ArgumentOutOfRangeException(nameof(email_clean), "El correo no es correcto");

            return ObjPerfile.ChangeEmail(id, email_clean);
        }

        public bool ChangePassword(int id, string password)
        {
            string password_cryp;

            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(password, "El argumento se encuentra vacio");

            password_cryp = HEncrypt.PasswordEncryp(password);

            return ObjPerfile.ChangePassword(id, password_cryp);
        }
    }
}
