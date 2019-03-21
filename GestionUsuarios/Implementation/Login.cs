using GestionUsuarios.Data;
using GestionUsuarios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Implementation
{
    public class CheckEmailImp : ICheckEmail
    {
        public bool CheckEmail(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    throw new NotImplementedException();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    public class LoginImp : ILogin
    {
        public string Login(string Email, string Password)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    throw new NotImplementedException();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
