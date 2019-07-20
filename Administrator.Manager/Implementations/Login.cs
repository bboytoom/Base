using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using Administrator.Manager.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace Administrator.Manager.Implementations
{
    #region verifica correo

    public class CheckEmailImp : ICheckEmail
    {
        private DataModels ctx;
        private CheckEmailImp()
        {
            ctx = new DataModels();
        }

        public string CheckEmail(string Email)
        {
            string email_clean;

            if (Email == "" || Email == null)
                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = false });

            email_clean = WebUtility.HtmlEncode(Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = false });

            try
            {
                var query_failed = ctx.Tbl_Users
                    .Where(w => w.Email_user == email_clean && w.Active_user == false)
                    .FirstOrDefault();

                if (query_failed == null)
                {
                    var query = ctx.Tbl_Users
                    .Where(w => w.Email_user == email_clean).FirstOrDefault();

                    if (query == null)
                        return JsonConvert.SerializeObject(new { Status = 404, Respuesta = false });

                    return JsonConvert.SerializeObject(new { Status = 200, Respuesta = true });
                }

                return JsonConvert.SerializeObject(new { Status = 401, Respuesta = false });
            }
            catch (Exception)
            {
                CustomErrorDetail customError = new CustomErrorDetail(500, "Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }

    #endregion

    #region verifica credenciales
    public class LoginImp : ILogin
    {
        private DataModels ctx;
        public LoginImp()
        {
            ctx = new DataModels();
        }

        public Tbl_Users Login(ViewModelsLogin data)
        {
            string password_clean;

            password_clean = HEncrypt.PasswordEncryp(data.Password);

            return ctx.Tbl_Users.Where(w => w.Email_user == data.Email && w.Password_user == password_clean).FirstOrDefault();
        }
    }
    #endregion

    #region Inicia las clases estaticas

    public static class CStatusUser
    {
        public static bool StatusUser(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    Tbl_Users find_user = ctx.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();
                    return find_user.Active_user;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    public static class LockOutUser
    {
        public static bool InsertAttemps(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    Tbl_Users find_user = ctx.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();

                    var insert_attemp = new Tbl_Users()
                    {
                        Id = find_user.Id,
                        Id_group = find_user.Id_group,
                        Type_user = find_user.Type_user,
                        Photo_user = find_user.Photo_user,
                        Email_user = find_user.Email_user,
                        Password_user = find_user.Password_user,
                        Name_user = find_user.Name_user,
                        LnameP_user = find_user.LnameP_user,
                        LnameM_user = find_user.LnameM_user,
                        MainU_user = find_user.MainU_user,
                        CreateD_user = find_user.CreateD_user,
                        CreateU_user = find_user.CreateU_user,
                        UpdateD_user = find_user.UpdateD_user,
                        UpdateU_user = find_user.UpdateU_user,
                        Active_user = find_user.Active_user,
                        Cycle_user = find_user.Cycle_user,
                        Attemp_user = (find_user.Attemp_user + 1)
                    };

                    ctx.Entry(find_user).CurrentValues.SetValues(insert_attemp);
                    ctx.SaveChanges();

                    if (find_user.Attemp_user == 4)
                        return true;

                    return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void InsertCycle(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    Tbl_Users find_user = ctx.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();

                    var cycle_attemp = new Tbl_Users()
                    {
                        Id = find_user.Id,
                        Id_group = find_user.Id_group,
                        Type_user = find_user.Type_user,
                        Photo_user = find_user.Photo_user,
                        Email_user = find_user.Email_user,
                        Password_user = find_user.Password_user,
                        Name_user = find_user.Name_user,
                        LnameP_user = find_user.LnameP_user,
                        LnameM_user = find_user.LnameM_user,
                        MainU_user = find_user.MainU_user,
                        CreateD_user = find_user.CreateD_user,
                        CreateU_user = find_user.CreateU_user,
                        UpdateD_user = find_user.UpdateD_user,
                        UpdateU_user = find_user.UpdateU_user,
                        Active_user = find_user.Active_user,
                        Attemp_user = 0,
                        Cycle_user = (find_user.Cycle_user + 1)
                    };

                    ctx.Entry(find_user).CurrentValues.SetValues(cycle_attemp);
                    ctx.SaveChanges();

                    if (find_user.Cycle_user == 3)
                    {
                        var lockuot_user = new Tbl_Users()
                        {
                            Id = find_user.Id,
                            Id_group = find_user.Id_group,
                            Type_user = find_user.Type_user,
                            Photo_user = find_user.Photo_user,
                            Email_user = find_user.Email_user,
                            Password_user = find_user.Password_user,
                            Name_user = find_user.Name_user,
                            LnameP_user = find_user.LnameP_user,
                            LnameM_user = find_user.LnameM_user,
                            MainU_user = find_user.MainU_user,
                            CreateD_user = find_user.CreateD_user,
                            CreateU_user = find_user.CreateU_user,
                            UpdateD_user = find_user.UpdateD_user,
                            UpdateU_user = find_user.UpdateU_user,
                            Active_user = false,
                            Attemp_user = 0,
                            Cycle_user = 0
                        };

                        ctx.Entry(find_user).CurrentValues.SetValues(lockuot_user);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void ResetAttemps(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    Tbl_Users find_user = ctx.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();

                    var reset_attemp = new Tbl_Users()
                    {
                        Id = find_user.Id,
                        Id_group = find_user.Id_group,
                        Type_user = find_user.Type_user,
                        Photo_user = find_user.Photo_user,
                        Email_user = find_user.Email_user,
                        Password_user = find_user.Password_user,
                        Name_user = find_user.Name_user,
                        LnameP_user = find_user.LnameP_user,
                        LnameM_user = find_user.LnameM_user,
                        MainU_user = find_user.MainU_user,
                        CreateD_user = find_user.CreateD_user,
                        CreateU_user = find_user.CreateU_user,
                        UpdateD_user = find_user.UpdateD_user,
                        UpdateU_user = find_user.UpdateU_user,
                        Active_user = true,
                        Attemp_user = 0,
                        Cycle_user = 0
                    };

                    ctx.Entry(find_user).CurrentValues.SetValues(reset_attemp);
                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    #endregion  
}
