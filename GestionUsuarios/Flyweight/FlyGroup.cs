using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                ctx.Database.ExecuteSqlCommand("EXECUTE STR_CRUDGROUP @token, @idgrupo, @name, @description, " +
                    "@readuser, @createuser, @updateuser, @deleteuser," +
                    "@readgroup, @creategroup, @updategroup, @deletegroup, " +
                    "@readpermission, @createpermission, @updatepermission, @deletepermission," +
                    "@reademail, @createemail, @updateemail, @deleteemail, " +
                    "@status, @highUser",
                    new SqlParameter("token", token),
                    new SqlParameter("idgrupo", data.Id),
                    new SqlParameter("name", WebUtility.HtmlEncode(data.Name.ToLower())),
                    new SqlParameter("description", (data.Description != "") ? WebUtility.HtmlEncode(data.Description) : ""),
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
                throw;
            }
        }
    }
}
