using GestionUsuarios.Data.DSManagerTableAdapters;
using static GestionUsuarios.Data.DSManager;
using GestionUsuarios.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GestionUsuarios.Data;
using System.ServiceModel.Web;

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
            string photo_clean;
            string email_clean;
            string password_clean;
            string curp_clean;
            string rfc_clean;
            string name_clean;
            string Lnamep_clean;
            string Lnamem_clean;

            try
            {
                if (token == 3)
                {
                    photo_clean = (data.Photo == null) ? "" : WebUtility.HtmlEncode(data.Photo);
                    email_clean = (data.Email == null) ? "" : WebUtility.HtmlEncode(data.Email);
                    password_clean = (data.Password == null) ? "" : HEncrypt.PasswordEncryp(data.Password);
                    curp_clean = (data.Curp == null) ? "" : WebUtility.HtmlEncode(data.Curp);
                    rfc_clean = (data.Rfc == null) ? "" : WebUtility.HtmlEncode(data.Rfc);
                    name_clean = (data.Name == null) ? "" : WebUtility.HtmlEncode(data.Name);
                    Lnamep_clean = (data.Lnamep == null) ? "" : WebUtility.HtmlEncode(data.Lnamep);
                    Lnamem_clean = (data.Lnamem == null) ? "" : WebUtility.HtmlEncode(data.Lnamem);
                }
                else
                {
                    photo_clean = (data.Photo == "" || data.Photo == null) ? "" : WebUtility.HtmlEncode(data.Photo.ToLower());
                    email_clean = WebUtility.HtmlEncode(data.Email.ToLower());
                    password_clean = HEncrypt.PasswordEncryp(data.Password);
                    curp_clean = (data.Curp == "" || data.Curp == null) ? "" : WebUtility.HtmlEncode(data.Curp.ToLower());
                    rfc_clean = (data.Rfc == "" || data.Rfc == null) ? "" : WebUtility.HtmlEncode(data.Rfc.ToLower());
                    name_clean = WebUtility.HtmlEncode(data.Name.ToLower());
                    Lnamep_clean = WebUtility.HtmlEncode(data.Lnamep.ToLower());
                    Lnamem_clean = WebUtility.HtmlEncode(data.Lnamem.ToLower());
                }
                
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
                CustomErrorDetail customError = new CustomErrorDetail("Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }
}
