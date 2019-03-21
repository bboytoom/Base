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
    public class CreateEmailImp : ICreateEmail
    {
        public string CreateEmail(ViewModelEmail data)
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

    public class UpdateEmailImp : IUpdateEmail
    {
        public string UpdateEmail(ViewModelEmail data)
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

    public class DeleteEmailImp : IDeleteEmail
    {
        public string DeleteEmail(int Id, int HighUser)
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

    public class ReadEmailImp : IReadEmail
    {
        public List<ViewModelEmail> ReadEmail(int Id)
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

    public class ReadAllEmailImp : IReadAllEmail
    {
        public List<ViewModelEmail> ReadAllEmail()
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
