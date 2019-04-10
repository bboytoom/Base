using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Flyweight
{
    abstract class AbstractEmail
    {
        protected ViewModelEmail data;
        public abstract string Query(int token, DataModels ctx);
    }

    class QueryEmail : AbstractEmail
    {
        public QueryEmail(ViewModelEmail Data)
        {
            data = Data;
        }

        public override string Query(int token, DataModels ctx)
        {
            string email_clean;
            string description_clean;

            try
            {
                description_clean = (data.Description == "" || data.Email == null) ? WebUtility.HtmlEncode(data.Description) : "";
                email_clean = (data.Email == "" || data.Email == null) ? "" : WebUtility.HtmlEncode(data.Email.ToLower());

                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 200,
                        Respuesta = true
                    }
                );
            }
            catch (Exception)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }
}
