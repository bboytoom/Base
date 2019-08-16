using Administrator.Contract;
using Administrator.Manager.Helpers;
using Administrator.Query;
using System;
using System.Net;

namespace Administrator.Manager
{
    public class Authentication
    {
        private Auth ObjAuth;

        public Authentication()
        {
            ObjAuth = new Auth();
        }

        public ViewModelClaims Login(string email, string password)
        {
            string email_clean;
            string password_cryp;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email);

            email_clean = WebUtility.HtmlEncode(email).ToLower();

            if (!HCheckEmail.EmailCheck(email_clean))
                throw new ArgumentOutOfRangeException("email_clean", "El correo no es correcto");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(password);

            password_cryp = HEncrypt.PasswordEncryp(password);

            return ObjAuth.Login(email_clean.ToLower(), password_cryp);
        }

        public bool CheckUser(string email)
        {
            string email_clean;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email);

            email_clean = WebUtility.HtmlEncode(email).ToLower();

            if (!HCheckEmail.EmailCheck(email_clean))
                throw new ArgumentOutOfRangeException("email_clean", "El correo no es correcto");

            if (ObjAuth.CheckUserActive(email_clean))
                return false;

            return ObjAuth.CheckUserExist(email_clean.ToLower());
        }

        public static bool ValidStatus(string email)
        {
            string email_clean;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email);

            email_clean = WebUtility.HtmlEncode(email).ToLower();

            if (!HCheckEmail.EmailCheck(email_clean))
                throw new ArgumentOutOfRangeException("email_clean", "El correo no es correcto");

            return Validation.Status(email);
        }

        public static bool ValidAttemps(string email)
        {
            string email_clean;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email);

            email_clean = WebUtility.HtmlEncode(email).ToLower();

            if (!HCheckEmail.EmailCheck(email_clean))
                throw new ArgumentOutOfRangeException("email_clean", "El correo no es correcto");

            return Validation.InsertAttemps(email_clean);
        }

        public static bool ValidCycle(string email)
        {
            string email_clean;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email);

            email_clean = WebUtility.HtmlEncode(email).ToLower();

            if (!HCheckEmail.EmailCheck(email_clean))
                throw new ArgumentOutOfRangeException("email_clean", "El correo no es correcto");

            return Validation.InsertCycle(email_clean);
        }

        public static bool ValidResetAttemp(string email)
        {
            string email_clean;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email);

            email_clean = WebUtility.HtmlEncode(email).ToLower();

            if (!HCheckEmail.EmailCheck(email_clean))
                throw new ArgumentOutOfRangeException("email_clean", "El correo no es correcto");

            return Validation.ResetAttemps(email_clean);
        }
    }
}
