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
    abstract class AbstractUser
    {
        protected ViewModelUser data;
        public abstract string Query(int token);
    }

    class QueryUser : AbstractUser
    {
        private Tbl_UsuariosTableAdapter dt_user;
        public QueryUser(ViewModelUser Data)
        {
            dt_user = new Tbl_UsuariosTableAdapter();
            data = Data;
        }

        public override string Query(int token)
        {
            try
            {
                string photo_clean = (data.Photo != "") ? WebUtility.HtmlEncode(data.Photo) : "default.png";
                string email_clean = WebUtility.HtmlEncode(data.Email.ToLower());
                string password_clean = HEncrypt.PasswordEncryp(data.Password);
                string curp_clean = (data.Curp != "") ? WebUtility.HtmlEncode(data.Curp.ToLower()) : "";
                string rfc_clean = (data.Rfc != "") ? WebUtility.HtmlEncode(data.Rfc.ToLower()) : "";
                string name_clean = WebUtility.HtmlEncode(data.Name.ToLower());
                string Lnamep_clean = WebUtility.HtmlEncode(data.Lnamep.ToLower());
                string Lnamem_clean = WebUtility.HtmlEncode(data.Lnamem.ToLower());

                dt_user.STR_CRUDUSER(token, data.Id, data.Idemail, data.Idgroup,
                    photo_clean, email_clean, data.Mainemail, password_clean, curp_clean, rfc_clean,
                    name_clean, Lnamep_clean, Lnamem_clean, data.Birthdate, data.Status, data.HighUser);

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
