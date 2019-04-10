using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace GestionUsuarios.Flyweight
{
    abstract class AbstractGroup
    {
        protected ViewModelGroup data;
        public abstract string Query(int token, DataModels ctx);
    }

    class QueryGroup : AbstractGroup
    {
        public QueryGroup(ViewModelGroup Data)
        {
            data = Data;
        }

        public override string Query(int token, DataModels ctx)
        {
            string name_clean;
            string description_clean;

            try
            {
                description_clean = (data.Description == "" || data.Description == null) ? "" : WebUtility.HtmlEncode(data.Description);
                name_clean = (data.Name == "" || data.Name == null) ? "" : WebUtility.HtmlEncode(data.Name.ToLower());

                ctx.Database.ExecuteSqlCommand("EXECUTE STR_CRUDGROUP @token, @idgrupo, @name, @description, " +
                    "@readuser, @createuser, @updateuser, @deleteuser," +
                    "@readgroup, @creategroup, @updategroup, @deletegroup, " +
                    "@readpermission, @createpermission, @updatepermission, @deletepermission," +
                    "@reademail, @createemail, @updateemail, @deleteemail, " +
                    "@status, @highUser",
                    new SqlParameter("token", token),
                    new SqlParameter("idgrupo", data.Id),
                    new SqlParameter("name", name_clean),
                    new SqlParameter("description", description_clean),
                    new SqlParameter("readuser", data.Readuser),
                    new SqlParameter("createuser", data.Createuser),
                    new SqlParameter("updateuser", data.Updateuser),
                    new SqlParameter("deleteuser", data.Deleteuser),
                    new SqlParameter("readgroup", data.Readgroup),
                    new SqlParameter("creategroup", data.Creategroup),
                    new SqlParameter("updategroup", data.Updategroup),
                    new SqlParameter("deletegroup", data.Deletegroup),
                    new SqlParameter("readpermission", data.Readpermission),
                    new SqlParameter("createpermission", data.Createpermission),
                    new SqlParameter("updatepermission", data.Updatepermission),
                    new SqlParameter("deletepermission", data.Deletepermission),
                    new SqlParameter("reademail", data.Reademail),
                    new SqlParameter("createemail", data.Createemail),
                    new SqlParameter("updateemail", data.Updateemail),
                    new SqlParameter("deleteemail", data.Deleteemail),
                    new SqlParameter("status", data.Status),
                    new SqlParameter("highUser", data.HighUser)
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
                CustomErrorDetail customError = new CustomErrorDetail("Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }
}
