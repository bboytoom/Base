using GestionUsuarios.Data;
using GestionUsuarios.Flyweight;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

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
            string email_clean;

            if (Data.Idgroup == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == null || Data.Password == null || Data.Name == null || Data.Lnamep == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Password == "" || Data.Name == "" || Data.Lnamep == "")
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
            {
                CustomErrorDetail customError = new CustomErrorDetail("Email no valido", "El correo ingresado no es valido");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.UnsupportedMediaType);
            }

            var search_email = ctx.Tbl_Correos.Where(w => w.email_correo == email_clean).FirstOrDefault();

            if (search_email != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            objetcQuery = new QueryUser(Data);
            return objetcQuery.Query(1, ctx);
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
            string email_clean;

            if (Data.Idgroup == 0 || Data.HighUser == 0 || Data.Id == 0 || Data.Idemail == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Name == "" || Data.Lnamep == "")
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == null || Data.Name == null || Data.Lnamep == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
            {
                CustomErrorDetail customError = new CustomErrorDetail("Email no valido", "El correo ingresado no es valido");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.UnsupportedMediaType);
            }

            var search_email_repeat = ctx.Tbl_Correos.Where(w => w.id != Data.Idemail &&  w.email_correo == Data.Email).FirstOrDefault();

            if (search_email_repeat != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            objetcQuery = new QueryUser(Data);
            return objetcQuery.Query(2, ctx);
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
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_user = ctx.Tbl_Usuarios.Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_user == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            objetcQuery = new QueryUser(Data);
            return objetcQuery.Query(3, ctx);
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
