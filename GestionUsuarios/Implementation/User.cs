using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Implementation
{
    public class CreateUserImp : ICreateUser
    {
        public string CreateUser(ViewModelUser Data)
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

    public class UpdateUserImp : IUpdateUser
    {
        public string UpdateUser(ViewModelUser Data)
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

    public class DeleteUserImp : IDeleteUser
    {
        public string DeleteUser(int Id, int HighUser)
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

    public class ReadUserImp : IReadUser
    {
        public List<ViewModelUser> ReadUser(int Id)
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

    public class ReadAllUserImp : IReadAllUser
    {
        public List<ViewModelUser> ReadAllUser()
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
