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
    #region Crear grupo

    public class CreateGroupImp : ICreateGroup
    {
        private Configuration connect;
        private CreateGroupImp()
        {
            connect = Configuration.Ctx();
        }

        public string CreateGroup(ViewModelGroup Data)
        {
            string name_clean;
            var insertTime = DateTime.Now;

            if (Data.Name == "" || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            name_clean = WebUtility.HtmlEncode(Data.Name.ToLower());

            var search_group = connect.getConexion.Tbl_Groups.Where(w => w.Name_group == name_clean).FirstOrDefault();

            if (search_group != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(410, "Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            try
            {
                var create_group = new Tbl_Groups()
                {
                    Id = Data.Id,
                    Name_group = name_clean,
                    Description_group = WebUtility.HtmlEncode(Data.Description),
                    Active_group = true,
                    CreateU_group = Data.HighUser,
                    MainU_group = Data.Main,
                    CreateD_group = insertTime
                };

                connect.getConexion.Tbl_Groups.Add(create_group);
                connect.getConexion.SaveChanges();

                var search_id = connect.getConexion.Tbl_Groups.Where(w => w.Name_group == name_clean).FirstOrDefault();

                var create_permission = new Tbl_Permissions()
                {
                    Id_group = search_id.Id,
                    Read_user_permission = Data.Readuser,
                    Update_user_permission = Data.Updateuser,
                    Create_user_permission = Data.Createuser,
                    Delete_user_permission = Data.Deleteuser,
                    Read_group_permission = Data.Readgroup,
                    Update_group_permission = Data.Updategroup,
                    Create_group_permission = Data.Creategroup,
                    Delete_group_permission = Data.Deletegroup,
                    Read_permission_permission = Data.Readpermission,
                    Update_permission_permission = Data.Updatepermission,
                    Create_permission_permission = Data.Createpermission,
                    Delete_permission_permission = Data.Deletepermission,
                    Read_email_permission = Data.Reademail,
                    Update_email_permission = Data.Updateemail,
                    Create_email_permission = Data.Createemail,
                    Delete_email_permission = Data.Deleteemail
                };

                connect.getConexion.Tbl_Permissions.Add(create_permission);
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

    #region Actualizar grupo

    public class UpdateGroupImp : IUpdateGroup
    {
        private Configuration connect;
        private UpdateGroupImp()
        {
            connect = Configuration.Ctx();
        }

        public string UpdateGroup(ViewModelGroup Data)
        {
            string name_clean;

            if (Data.Name == "" || Data.HighUser == 0 || Data.Id == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_group = connect.getConexion.Tbl_Groups.Where(w => w.Id == Data.Id).FirstOrDefault();

            if (search_group == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(404, "Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            name_clean = WebUtility.HtmlEncode(Data.Name.ToLower());

            var search_group_repeat = connect.getConexion.Tbl_Groups.Where(w => w.Id != Data.Id && w.Name_group == name_clean).FirstOrDefault();

            if (search_group_repeat != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(410, "Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            try
            {
                var update_group = new Tbl_Groups()
                {
                    Id = Data.Id,
                    Name_group = name_clean,
                    Description_group = WebUtility.HtmlEncode(Data.Description),
                    Active_group = Data.Status,
                    CreateU_group = search_group.CreateU_group,
                    CreateD_group = search_group.CreateD_group,
                    UpdateU_group = Data.HighUser,
                    MainU_group = Data.Main,
                    UpdateD_group = DateTime.Now
                };

                connect.getConexion.Entry(search_group).CurrentValues.SetValues(update_group);
                connect.getConexion.SaveChanges();

                Tbl_Permissions find_permission = connect.getConexion.Tbl_Permissions.Find(Data.Id);

                var update_permission = new Tbl_Permissions()
                {
                    Id_group = Data.Id,
                    Read_user_permission = Data.Readuser,
                    Update_user_permission = Data.Updateuser,
                    Create_user_permission = Data.Createuser,
                    Delete_user_permission = Data.Deleteuser,
                    Read_group_permission = Data.Readgroup,
                    Update_group_permission = Data.Updategroup,
                    Create_group_permission = Data.Creategroup,
                    Delete_group_permission = Data.Deletegroup,
                    Read_permission_permission = Data.Readpermission,
                    Update_permission_permission = Data.Updatepermission,
                    Create_permission_permission = Data.Createpermission,
                    Delete_permission_permission = Data.Deletepermission,
                    Read_email_permission = Data.Reademail,
                    Update_email_permission = Data.Updateemail,
                    Create_email_permission = Data.Createemail,
                    Delete_email_permission = Data.Deleteemail
                };

                connect.getConexion.Entry(find_permission).CurrentValues.SetValues(update_permission);
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

    #region Eliminar grupo

    public class DeleteGroupImp : IDeleteGroup
    {
        private Configuration connect;
        private DeleteGroupImp()
        {
            connect = Configuration.Ctx();
        }

        public string DeleteGroup(int Id, int HighUser)
        {
            if (Id == 0 || HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_group = connect.getConexion.Tbl_Groups.Where(w => w.Id == Id).FirstOrDefault();

            if (search_group == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(404, "Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            try
            {
                var delete_group = new Tbl_Groups()
                {
                    Id = search_group.Id,
                    Name_group = search_group.Name_group,
                    Description_group = search_group.Description_group,
                    Active_group = false,
                    MainU_group = search_group.MainU_group,
                    DeleteU_group = HighUser,
                    DeleteD_group = DateTime.Now,
                    Delete_stautus_group = true
                };

                connect.getConexion.Entry(search_group).CurrentValues.SetValues(delete_group);
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

    #region Mostrar grupo

    public class ReadGroupImp : IReadGroup
    {
        private Configuration connect;
        public ReadGroupImp()
        {
            connect = Configuration.Ctx();
        }

        public ViewModelGroup ReadGroup(int Id)
        {
            try
            {
                ViewModelGroup salida = connect.getConexion.Tbl_Groups.Join(connect.getConexion.Tbl_Permissions,
                pk => pk.Id, fk => fk.Id_group, (pk, fk) => new ViewModelGroup
                {
                    Id = pk.Id,
                    Name = pk.Name_group,
                    Description = pk.Description_group,
                    Readuser = fk.Read_user_permission,
                    Createuser = fk.Create_user_permission,
                    Updateuser = fk.Update_user_permission,
                    Deleteuser = fk.Delete_user_permission,
                    Readgroup = fk.Read_group_permission,
                    Creategroup = fk.Create_group_permission,
                    Updategroup = fk.Update_group_permission,
                    Deletegroup = fk.Delete_group_permission,
                    Readpermission = fk.Read_permission_permission,
                    Createpermission = fk.Create_permission_permission,
                    Updatepermission = fk.Update_permission_permission,
                    Deletepermission = fk.Delete_permission_permission,
                    Reademail = fk.Read_email_permission,
                    Createemail = fk.Create_email_permission,
                    Updateemail = fk.Update_email_permission,
                    Deleteemail = fk.Delete_email_permission,
                    Status = pk.Active_group
                }).Where(w => w.Id == Id).FirstOrDefault();

                return salida;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class ReadGroupUserImp : IReadGroupUser
    {
        private Configuration connect;
        public ReadGroupUserImp()
        {
            connect = Configuration.Ctx();
        }

        public List<Tbl_Groups> ReadGroupUser(int Id)
        {
            try
            {
                return connect.getConexion.Tbl_Groups.Where(w => w.MainU_group == Id && w.Id != 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class ReadAllGroupImp : IReadAllGroup
    {
        private Configuration connect;
        public ReadAllGroupImp()
        {
            connect = Configuration.Ctx();
        }

        public List<Tbl_Groups> ReadAllGroup(string sortorder, string searchstring, int id_main)
        {
            var show_group = from s in connect.getConexion.Tbl_Groups where s.MainU_group == id_main select s;

            if (!String.IsNullOrEmpty(searchstring))
            {
                show_group = show_group.Where(s => s.Name_group.Contains(searchstring));
            }

            switch (sortorder)
            {
                case "name_desc":
                    show_group = show_group.OrderByDescending(s => s.Name_group);
                    break;
                default:
                    show_group = show_group.OrderBy(s => s.Name_group);
                    break;
            }

            return show_group.ToList();
        }
    }

    #endregion
}