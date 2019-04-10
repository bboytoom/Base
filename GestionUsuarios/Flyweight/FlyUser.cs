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
        public abstract string Query(int token, DataModels ctx);
    }

    class QueryUser : AbstractUser
    {
        public QueryUser(ViewModelUser Data)
        {
            data = Data;
        }

        public override string Query(int token, DataModels ctx)
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
                photo_clean = (data.Photo == "" || data.Photo == null) ? "" : WebUtility.HtmlEncode(data.Photo.ToLower());
                email_clean = (data.Email == "" || data.Email == null) ? "" : WebUtility.HtmlEncode(data.Email.ToLower());
                curp_clean = (data.Curp == "" || data.Curp == null) ? "" : WebUtility.HtmlEncode(data.Curp.ToLower());
                rfc_clean = (data.Rfc == "" || data.Rfc == null) ? "" : WebUtility.HtmlEncode(data.Rfc.ToLower());
                name_clean = (data.Name == "" || data.Name == null) ? "" : WebUtility.HtmlEncode(data.Name.ToLower());
                Lnamep_clean = (data.Lnamep == "" || data.Lnamep == null) ? "" : WebUtility.HtmlEncode(data.Lnamep.ToLower());
                Lnamem_clean = (data.Lnamem == "" || data.Lnamem == null) ? "" : WebUtility.HtmlEncode(data.Lnamem.ToLower());

                if (token == 2)
                    password_clean = Convert.ToString(ctx.Tbl_Usuarios.Where(w => w.id == data.Id)
                        .Select(s => s.password_usuario).FirstOrDefault());
                else
                    password_clean = (data.Password == "" || data.Password == null) ? "" : HEncrypt.PasswordEncryp(data.Password);
                
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
