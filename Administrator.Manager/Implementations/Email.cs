using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using Administrator.Manager.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace Administrator.Manager.Implementations
{
    #region Crear email

    public class CreateEmailImp : ICreateEmail
    {
        private Configuration connect;
        private CreateEmailImp()
        {
            connect = Configuration.Ctx();
        }

        public string CreateEmail(ViewModelEmail Data)
        {
            string email_clean;

            if (Data.Iduser == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Email == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
            {
                CustomErrorDetail customError = new CustomErrorDetail(415, "Email no valido", "El correo ingresado no es valido");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.UnsupportedMediaType);
            }

            var search_email = connect.getConexion.Tbl_Emails.Where(w => w.Email_email == email_clean).FirstOrDefault();

            if (search_email != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(410, "Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            try
            {
                var create_email = new Tbl_Emails()
                {
                    Id_user = Data.Iduser,
                    Type_email = Data.Typeuser,
                    Email_email = email_clean,
                    Description_email = WebUtility.HtmlEncode(Data.Description),
                    Active_email = true,
                    CreateU_email = Data.HighUser,
                    CreateD_email = DateTime.Now
                };

                connect.getConexion.Tbl_Emails.Add(create_email);
                connect.getConexion.SaveChanges();

                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = true });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion

    #region Actualizar email

    public class UpdateEmailImp : IUpdateEmail
    {
        private Configuration connect;
        private UpdateEmailImp()
        {
            connect = Configuration.Ctx();
        }

        public string UpdateEmail(ViewModelEmail Data)
        {
            string email_clean;

            if (Data.Id == 0 || Data.Iduser == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Email == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            email_clean = WebUtility.HtmlEncode(Data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
            {
                CustomErrorDetail customError = new CustomErrorDetail(415, "Email no valido", "El correo ingresado no es valido");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.UnsupportedMediaType);
            }

            var search_email_repeat = connect.getConexion.Tbl_Emails.Where(w => w.Id != Data.Id && w.Email_email == Data.Email).FirstOrDefault();

            if (search_email_repeat != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(410, "Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            try
            {
                Tbl_Emails find_email = connect.getConexion.Tbl_Emails.Find(Data.Id);

                if (find_email == null)
                {
                    CustomErrorDetail customError = new CustomErrorDetail(404, "Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                    throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
                }

                var update_email = new Tbl_Emails()
                {
                    Id = Data.Id,
                    Id_user = Data.Iduser,
                    Type_email = Data.Typeuser,
                    Email_email = email_clean,
                    Description_email = WebUtility.HtmlEncode(Data.Description),
                    Active_email = Data.Status,
                    UpdateU_email = Data.HighUser,
                    UpdateD_email = DateTime.Now
                };

                connect.getConexion.Entry(find_email).CurrentValues.SetValues(update_email);
                connect.getConexion.SaveChanges();

                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = true });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion

    #region Eliminar email

    public class DeleteEmailImp : IDeleteEmail
    {
        private Configuration connect;
        private DeleteEmailImp()
        {
            connect = Configuration.Ctx();
        }

        public string DeleteEmail(ViewModelEmail Data)
        {
            if (Data.Id == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            try
            {
                Tbl_Emails find_email = connect.getConexion.Tbl_Emails.Find(Data.Id);

                if (find_email == null)
                {
                    CustomErrorDetail customError = new CustomErrorDetail(404, "Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                    throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
                }

                var delete_email = new Tbl_Emails()
                {
                    Id = Data.Id,
                    Id_user = find_email.Id_user,
                    Type_email = find_email.Type_email,
                    Email_email = find_email.Email_email,
                    Description_email = find_email.Description_email,
                    Active_email = false,
                    DeleteU_email = Data.HighUser,
                    DeleteD_email = DateTime.Now,
                    Delete_stautus_email = true
                };

                connect.getConexion.Entry(find_email).CurrentValues.SetValues(delete_email);
                connect.getConexion.SaveChanges();

                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = true });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion

    #region Mostrar email

    public class ReadEmailImp
    {
        private Configuration connect;
        public ReadEmailImp()
        {
            connect = Configuration.Ctx();
        }

        public List<ViewModelEmail> ReadEmail(int Id)
        {
            throw new NotImplementedException();
        }
    }

    public class ReadAllEmailImp
    {
        private Configuration connect;
        public ReadAllEmailImp()
        {
            connect = Configuration.Ctx();
        }

        public List<Tbl_Emails> ReadAllEmail()
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
