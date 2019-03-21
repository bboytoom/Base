using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Helpers
{
    public static class HEncrypt
    {
        public static string PasswordEncryp(string Password)
        {
            try
            {
                SHA512 sha512 = SHA512Managed.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(Password);
                byte[] hash = sha512.ComputeHash(bytes);
                return GetStringFromHash(hash);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
