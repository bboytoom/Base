using GestionUsuarios.Data;
using GestionUsuarios.Flyweight;
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
    public class CreateUserImp : ICreateUser
    {
        private DataModels ctx;
        private QueryUser objetcQuery;
        private CreateUserImp()
        {
            ctx = new DataModels();
        }
         
        public string CreateUser(ViewModelUser Data)
        {
            string email_clean = "";

            if (Data.Idgroup == 0 || Data.HighUser == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            if(Data.Email == "" || Data.Password == "" || Data.Name == "" || Data.Lnamep == "")
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            var search_email = ctx.Tbl_Correos
                        .Where(w => w.email_correo == email_clean).FirstOrDefault();

            if (search_email != null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );
            
            objetcQuery = new QueryUser(Data);
            return objetcQuery.Query(1);
        }
    }

    public class UpdateUserImp : IUpdateUser
    {
        private DataModels ctx;
        private QueryUser objetcQuery;
        private UpdateUserImp()
        {
            ctx = new DataModels();
        }

        public string UpdateUser(ViewModelUser Data)
        {
            string email_clean = "";

            if (Data.Idgroup == 0 || Data.HighUser == 0 || Data.Id == 0 || Data.Idemail == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            if (Data.Email == "" || Data.Password == "" || Data.Name == "" || Data.Lnamep == "")
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            var search_user = ctx.Tbl_Usuarios
                        .Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_user == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            objetcQuery = new QueryUser(Data);
            return objetcQuery.Query(2);
        }
    }

    public class DeleteUserImp : IDeleteUser
    {
        private DataModels ctx;
        private QueryUser objetcQuery;
        private DeleteUserImp()
        {
            ctx = new DataModels();
        }

        public string DeleteUser(ViewModelUser Data)
        {
            if (Data.Id == 0 || Data.HighUser == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            var search_user = ctx.Tbl_Usuarios
                        .Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_user == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            objetcQuery = new QueryUser(Data);
            return objetcQuery.Query(3);
        }
    }

    public class ReadUserImp : IReadUser
    {
        private DataModels ctx;
        private ReadUserImp()
        {
            ctx = new DataModels();
        }

        public List<ViewModelUser> ReadUser(int Id)
        {
            IQueryable<ViewModelUser> salida;

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

    public class ReadAllUserImp : IReadAllUser
    {
        private DataModels ctx;
        private ReadAllUserImp()
        {
            ctx = new DataModels();
        }

        public List<Tbl_Usuarios> ReadAllUser()
        {
            IQueryable<Tbl_Usuarios> salida;

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
