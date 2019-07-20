using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using Administrator.Manager.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Administrator.Manager.Implementations
{
    #region Crear usuario

    public class CreateUserImp : ICreateUser
    {
        private DataModels ctx;
        private CreateUserImp()
        {
            ctx = new DataModels();
        }

        public string CreateUser(ViewModelUser Data)
        {
            string email_clean;

            if (Data.Idgroup == 0 || Data.HighUser == 0 || Data.Typeuser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == null || Data.Password == null || Data.Name == null || Data.Lnamep == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Password == "" || Data.Name == "" || Data.Lnamep == "")
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

            var search_email = ctx.Tbl_Users.Where(w => w.Email_user == email_clean).FirstOrDefault();

            if (search_email != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(410, "Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            try
            {
                var insert_user = new Tbl_Users()
                {
                    Id_group = Data.Idgroup,
                    Type_user = Data.Typeuser,
                    Email_user = email_clean,
                    Password_user = Data.Password,
                    Name_user = Data.Name,
                    LnameP_user = Data.Lnamep,
                    LnameM_user = Data.Lnamem,
                    Active_user = true,
                    Photo_user = "default.png",
                    CreateU_user = Data.HighUser,
                    CreateD_user = DateTime.Now
                };

                ctx.Tbl_Users.Add(insert_user);
                ctx.SaveChanges();
                
                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = true });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class CreateSuperImp : IUserSuper
    {
        private DataModels ctx;
        public CreateSuperImp()
        {
            ctx = new DataModels();
        }

        public void UserSuper(ViewModelUser Data, string HieghUser, string MainUser)
        {
            try
            {
                var insert_user = new Tbl_Users()
                {
                    Id_group = Data.Idgroup,
                    Type_user = Data.Typeuser,
                    MainU_user = Convert.ToInt32(MainUser),
                    Email_user = Data.Email,
                    Password_user = Data.Password,
                    Name_user = Data.Name,
                    LnameP_user = Data.Lnamep,
                    LnameM_user = Data.Lnamem,
                    Active_user = true,
                    Photo_user = "default.png",
                    CreateU_user = Convert.ToInt32(HieghUser),
                    CreateD_user = DateTime.Now
                };

                ctx.Tbl_Users.Add(insert_user);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion

    #region Actualizar usuario

    public class UpdateUserImp : IUpdateUser
    {
        private DataModels ctx;
        private UpdateUserImp()
        {
            ctx = new DataModels();
        }

        public string UpdateUser(ViewModelUser Data)
        {
            string email_clean;

            if (Data.Idgroup == 0 || Data.HighUser == 0 || Data.Id == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == "" || Data.Name == "" || Data.Lnamep == "")
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            if (Data.Email == null || Data.Name == null || Data.Lnamep == null)
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

            var search_email_repeat = ctx.Tbl_Users.Where(w => w.Id != Data.Id && w.Email_user == email_clean).FirstOrDefault();

            if (search_email_repeat != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(410, "Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            try
            {
                Tbl_Users find_user = ctx.Tbl_Users.Find(Data.Id);

                if (find_user == null)
                {
                    CustomErrorDetail customError = new CustomErrorDetail(404, "Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                    throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
                }

                var update_user = new Tbl_Users()
                {
                    Id = Data.Id,
                    Id_group = Data.Idgroup,
                    Type_user = Data.Typeuser,
                    Email_user = email_clean,
                    Password_user = find_user.Password_user,
                    Name_user = Data.Name,
                    LnameP_user = Data.Lnamep,
                    LnameM_user = Data.Lnamem,
                    Photo_user = find_user.Photo_user,
                    Active_user = Data.Status,
                    UpdateU_user = Data.HighUser,
                    UpdateD_user = DateTime.Now,
                    CreateU_user = find_user.CreateU_user,
                    CreateD_user = find_user.CreateD_user
                };

                ctx.Entry(find_user).CurrentValues.SetValues(update_user);
                ctx.SaveChanges();
                
                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = true });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class UpdateSuperImp : IUserSuper
    {
        private DataModels ctx;
        public UpdateSuperImp()
        {
            ctx = new DataModels();
        }

        public void UserSuper(ViewModelUser Data, string HieghUser, string MainUser)
        {
            try
            {
                Tbl_Users find_user = ctx.Tbl_Users.Find(Data.Id);

                var update_user = new Tbl_Users()
                {
                    Id = Data.Id,
                    Id_group = Data.Idgroup,
                    Type_user = Data.Typeuser,
                    MainU_user = find_user.MainU_user,
                    Email_user = Data.Email,
                    Password_user = find_user.Password_user,
                    Name_user = Data.Name,
                    LnameP_user = Data.Lnamep,
                    LnameM_user = Data.Lnamem,
                    Photo_user = find_user.Photo_user,
                    Active_user = Data.Status,
                    UpdateU_user = Convert.ToInt32(HieghUser),
                    UpdateD_user = DateTime.Now,
                    CreateU_user = find_user.CreateU_user,
                    CreateD_user = find_user.CreateD_user
                };

                ctx.Entry(find_user).CurrentValues.SetValues(update_user);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion

    #region Eliminar usuario

    public class DeleteUserImp : IDeleteUser
    {
        private DataModels ctx;
        private DeleteUserImp()
        {
            ctx = new DataModels();
        }

        public string DeleteUser(int Id, int HighUser)
        {
            if (Id == 0 || HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            Tbl_Users find_user = ctx.Tbl_Users.Find(Id);

            if (find_user == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(404, "Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            try
            {
                var delete_user = new Tbl_Users()
                {
                    Id = Id,
                    Id_group = find_user.Id_group,
                    Type_user = find_user.Type_user,
                    Photo_user = find_user.Photo_user,
                    Email_user = find_user.Email_user,
                    Password_user = find_user.Password_user,
                    Name_user = find_user.Name_user,
                    LnameP_user = find_user.LnameP_user,
                    LnameM_user = find_user.LnameM_user,
                    Active_user = false,
                    DeleteU_user = HighUser,
                    DeleteD_user = DateTime.Now,
                    Delete_stautus_user = true
                };

                ctx.Entry(find_user).CurrentValues.SetValues(delete_user);
                ctx.SaveChanges();

                return JsonConvert.SerializeObject(new { Status = 200, Respuesta = true });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class DeleteUserSuperImp : IDeleteUserSuper
    {
        private DataModels ctx;
        public DeleteUserSuperImp()
        {
            ctx = new DataModels();
        }

        public void DeleteUserSuper(int Id, string HieghUser)
        {
            Tbl_Users find_user = ctx.Tbl_Users.Find(Id);

            try
            {
                var delete_user = new Tbl_Users()
                {
                    Id = Id,
                    Id_group = find_user.Id_group,
                    MainU_user = find_user.MainU_user,
                    Type_user = find_user.Type_user,
                    Photo_user = find_user.Photo_user,
                    Email_user = find_user.Email_user,
                    Password_user = find_user.Password_user,
                    Name_user = find_user.Name_user,
                    LnameP_user = find_user.LnameP_user,
                    LnameM_user = find_user.LnameM_user,
                    Active_user = false,
                    DeleteU_user = Convert.ToInt32(HieghUser),
                    DeleteD_user = DateTime.Now,
                    Delete_stautus_user = true
                };

                ctx.Entry(find_user).CurrentValues.SetValues(delete_user);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion

    #region Mostrar usuario

    public class ReadUserImp : IReadUser
    {
        private DataModels ctx;
        public ReadUserImp()
        {
            ctx = new DataModels();
        }

        public ViewModelUser ReadUser(int Id)
        {
            try
            {
                ViewModelUser salida = ctx.Tbl_Users.Where(w => w.Id == Id)
                    .Select(s => new ViewModelUser
                    {
                        Id = s.Id,
                        Idgroup = s.Id_group,
                        Typeuser = s.Type_user,
                        Email = s.Email_user,
                        Name = s.Name_user,
                        Nameimg = s.Photo_user,
                        Lnamep = s.LnameP_user,
                        Lnamem = s.LnameM_user,
                        Status = s.Active_user
                    }).FirstOrDefault();

                return salida;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class ReadAllUserImp : IReadAllUser
    {
        private DataModels ctx;
        public ReadAllUserImp()
        {
            ctx = new DataModels();
        }

        public List<Tbl_Users> ReadAllUser(string sortorder, string searchstring, int id_main)
        {
            var show_user = from s in ctx.Tbl_Users where s.MainU_user == id_main select s;

            if (!String.IsNullOrEmpty(searchstring))
            {
                show_user = show_user.Where(s => s.Name_user.Contains(searchstring));
            }

            switch (sortorder)
            {
                case "name_desc":
                    show_user = show_user.OrderByDescending(s => s.Name_user);
                    break;
                default:
                    show_user = show_user.OrderBy(s => s.Name_user);
                    break;
            }

            return show_user.ToList();
        }
    }

    public class ReadAllSuperImp: IReadAllUser
    {
        private DataModels ctx;
        public ReadAllSuperImp()
        {
            ctx = new DataModels();
        }

        public List<Tbl_Users> ReadAllUser(string sortorder, string searchstring, int id_main)
        {
            var show_user = from s in ctx.Tbl_Users where s.MainU_user == id_main select s;

            if (!String.IsNullOrEmpty(searchstring))
            {
                show_user = show_user.Where(s => s.Name_user.Contains(searchstring));
            }

            switch (sortorder)
            {
                case "name_desc":
                    show_user = show_user.OrderByDescending(s => s.Name_user);
                    break;
                default:
                    show_user = show_user.OrderBy(s => s.Name_user);
                    break;
            }

            return show_user.ToList();
        }
    }

    #endregion

    #region carga de imagenes

    public class UploadImgImp : IUploadImg
    {
        private DataModels ctx;
        private UploadImgImp()
        {
            ctx = new DataModels();
        }

        public void UploadImg(ViewModelUploadImg File)
        {
            if (File.Image != null || File.Image != "")
            {
                Tbl_Users find_user = ctx.Tbl_Users.Find(File.Id);

                var update_user = new Tbl_Users()
                {
                    Id = File.Id,
                    Photo_user = File.Name,
                    Type_user = find_user.Type_user,
                    Id_group = find_user.Id_group,
                    Email_user = find_user.Email_user,
                    Password_user = find_user.Password_user,
                    Active_user = find_user.Active_user,
                    Name_user = find_user.Name_user,
                    LnameM_user = find_user.LnameM_user,
                    LnameP_user = find_user.LnameP_user,
                    UpdateD_user = find_user.UpdateD_user,
                    UpdateU_user = find_user.UpdateU_user,
                    CreateD_user = find_user.CreateD_user,
                    CreateU_user = find_user.CreateU_user
                };

                ctx.Entry(find_user).CurrentValues.SetValues(update_user);
                ctx.SaveChanges();

                HImages.ImagesSys(File.Image, File.Name, "/Administrator/Images");
            }
        }
    }

    #endregion
}
 