using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

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

                ctx.Database.ExecuteSqlCommand("EXECUTE STR_CRUDEMAIL @token, @Id, @Iduser, " +
                    "@Mainemail, @Email, @Description, @Status, @HighUser",
                    new SqlParameter("token", token),
                    new SqlParameter("Id", data.Id),
                    new SqlParameter("Iduser", data.Iduser),
                    new SqlParameter("Mainemail", data.Mainemail),
                    new SqlParameter("Email", email_clean),
                    new SqlParameter("Description", description_clean),
                    new SqlParameter("Status", data.Status),
                    new SqlParameter("HighUser", data.HighUser)
                );

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
                CustomErrorDetail customError = new CustomErrorDetail(500, "Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }
}
