using System;
using System.Security.Cryptography;
using System.Text;

namespace Administrator.Manager.Helpers
{
    public static class HEncrypt
    {
        public static string PasswordEncryp(string password)
        {
            try
            {
                byte[] hash;

                using (SHA512 sha512 = SHA512.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(password);
                    hash = sha512.ComputeHash(bytes);
                }

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
