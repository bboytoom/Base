using Administrator.Manager.Data;
using Administrator.Manager.Flyweight;
using Administrator.Manager.Helpers;
using Administrator.Manager.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Administrator.Manager.Implementation
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
            string email_clean = "";

            if (Data.Iduser == 0 || Data.HighUser == 0 || Data.Email == "")
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

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
            if (Data.Id == 0 || Data.Iduser == 0 || Data.HighUser == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );
            
            if(Data.Email == "")
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            var search_email = ctx.Tbl_Correos
                        .Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_email == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

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
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );
            
            var search_email = ctx.Tbl_Correos
                        .Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_email == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

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
