using GestionUsuarios.Data;
using GestionUsuarios.Flyweight;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Implementation
{
    public class CreateEmailImp : ICreateEmail
    {
        private DataModels ctx;
        private QueryEmail objetcQuery;
        private CreateEmailImp()
        {
            ctx = new DataModels();
        }

        public string CreateEmail(ViewModelEmail Data)
        {
            string email_clean;

            if (Data.Iduser == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Email == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

            if(!HCheckEmail.EmailCheck(email_clean))
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

            objetcQuery = new QueryEmail(Data);
            return objetcQuery.Query(1, ctx);
        }
    }

    public class UpdateEmailImp : IUpdateEmail
    {
        private DataModels ctx;
        private QueryEmail objetcQuery;
        private UpdateEmailImp()
        {
            ctx = new DataModels();
        }

        public string UpdateEmail(ViewModelEmail Data)
        {
            string email_clean;

            if (Data.Id == 0 || Data.Iduser == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Email == null)
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

            var search_email = ctx.Tbl_Correos.Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_email == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            var search_email_repeat = ctx.Tbl_Correos.Where(w => w.id != Data.Id && w.email_correo == Data.Email).FirstOrDefault();

            if (search_email_repeat != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            objetcQuery = new QueryEmail(Data);
            return objetcQuery.Query(2, ctx);
        }
    }

    public class DeleteEmailImp : IDeleteEmail
    {
        private DataModels ctx;
        private QueryEmail objetcQuery;
        private DeleteEmailImp()
        {
            ctx = new DataModels();
        }

        public string DeleteEmail(ViewModelEmail Data)
        {
            if (Data.Id == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_email = ctx.Tbl_Correos.Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_email == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            objetcQuery = new QueryEmail(Data);
            return objetcQuery.Query(3, ctx);
        }
    }

    public class ReadEmailImp : IReadEmail
    {
        private DataModels ctx;
        private ReadEmailImp()
        {
            ctx = new DataModels();
        }

        public List<ViewModelEmail> ReadEmail(int Id)
        {
            IQueryable<ViewModelEmail> salida;

            try
            {
                salida = ctx.Tbl_Correos.Where(w => w.id == Id)
                    .Select(s => new ViewModelEmail
                    {
                        Id = s.id,
                        Iduser = s.id_usuario,
                        Mainemail = s.principal_correo,
                        Email = s.email_correo,
                        Description = s.descripcion_correo,
                        Status = s.activo_correo
                    });

                return salida.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
    public class ReadAllEmailImp : IReadAllEmail
    {
        private DataModels ctx;
        private ReadAllEmailImp()
        {
            ctx = new DataModels();
        }

        public List<Tbl_Correos> ReadAllEmail()
        {
            IQueryable<Tbl_Correos> salida;

            try
            {
                salida = ctx.Tbl_Correos.Select(s => new Tbl_Correos
                {
                    id = s.id,
                    principal_correo = s.principal_correo,
                    email_correo = s.email_correo,
                    descripcion_correo = s.descripcion_correo,
                    activo_correo = s.activo_correo
                });

                return salida.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
