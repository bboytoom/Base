using GestionUsuarios.Data.DSManagerTableAdapters;
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
        public abstract string Query(int token);
    }

    class QueryGroup : AbstractGroup
    {
        private Tbl_GruposTableAdapter dt_group;
        public QueryGroup(ViewModelGroup Data)
        {
            dt_group = new Tbl_GruposTableAdapter();
            data = Data;
        }

        public override string Query(int token)
        {
            try
            {
                string name_clean = WebUtility.HtmlEncode(data.Name.ToLower());
                string description_clean = (data.Description != "") ? WebUtility.HtmlEncode(data.Description) : "";

                dt_group.STR_CRUDGROUP(token, data.Id, name_clean, description_clean,
                    data.Readuser, data.Createuser, data.Updateuser, data.Deleteuser,
                    data.Readgroup, data.Creategroup, data.Updategroup, data.Deletegroup,
                    data.Readpermission, data.Createpermission, data.Updatepermission, data.Deletepermission,
                    data.Reademail, data.Createemail, data.Updateemail, data.Deleteemail, data.Status, data.HighUser);

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
