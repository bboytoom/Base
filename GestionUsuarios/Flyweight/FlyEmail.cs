using GestionUsuarios.Data.DSManagerTableAdapters;
using GestionUsuarios.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Flyweight
{
    abstract class AbstractEmail
    {
        protected ViewModelEmail data;
        public abstract string Query(int token);
    }

    class QueryEmail : AbstractEmail
    {
        private Tbl_CorreosTableAdapter dt_email;
        public QueryEmail(ViewModelEmail Data)
        {
            dt_email = new Tbl_CorreosTableAdapter();
            data = Data;
        }

        public override string Query(int token)
        {
            try
            {
                string email_clean = WebUtility.HtmlEncode(data.Email.ToLower());
                string description_clean = (data.Description != "") ? WebUtility.HtmlEncode(data.Description) : "";

                dt_email.STR_CRUDEMAIL(token, data.Id, data.Iduser, data.Mainemail,
                    email_clean, description_clean, data.Status, data.HighUser);

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
