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
        private DataModels ctx;
        private CreateGroupImp()
        {
            ctx = new DataModels();
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

            var search_group = ctx.Tbl_Groups.Where(w => w.Name_group == name_clean).FirstOrDefault();

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
                    CreateD_group = insertTime
                };

                ctx.Tbl_Groups.Add(create_group);
                ctx.SaveChanges();

                var search_id = ctx.Tbl_Groups.Where(w => w.Name_group == name_clean).FirstOrDefault();

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

                ctx.Tbl_Permissions.Add(create_permission);
                ctx.SaveChanges();

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

    #endregion

    #region Actualizar grupo

    public class UpdateGroupImp : IUpdateGroup
    {
        private DataModels ctx;
        private UpdateGroupImp()
        {
            ctx = new DataModels();
        }

        public string UpdateGroup(ViewModelGroup Data)
        {
            string name_clean;

            if (Data.Name == "" || Data.HighUser == 0 || Data.Id == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_group = ctx.Tbl_Groups.Where(w => w.Id == Data.Id).FirstOrDefault();

            if (search_group == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail(404, "Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            name_clean = WebUtility.HtmlEncode(Data.Name.ToLower());

            var search_group_repeat = ctx.Tbl_Groups.Where(w => w.Id != Data.Id && w.Name_group == name_clean).FirstOrDefault();

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
                    UpdateU_group = Data.HighUser,
                    UpdateD_group = DateTime.Now
                };

                ctx.Entry(search_group).CurrentValues.SetValues(update_group);
                ctx.SaveChanges();

                Tbl_Permissions find_permission = ctx.Tbl_Permissions.Find(Data.Id);

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

                ctx.Entry(find_permission).CurrentValues.SetValues(update_permission);
                ctx.SaveChanges();

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

    #endregion

    #region Eliminar grupo

    public class DeleteGroupImp : IDeleteGroup
    {
        private DataModels ctx;
        private DeleteGroupImp()
        {
            ctx = new DataModels();
        }

        public string DeleteGroup(int Id, int HighUser)
        {
            if (Id == 0 || HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail(400, "Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_group = ctx.Tbl_Groups.Where(w => w.Id == Id).FirstOrDefault();

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
                    DeleteU_group = HighUser,
                    DeleteD_group = DateTime.Now,
                    Delete_stautus_group = true
                };

                ctx.Entry(search_group).CurrentValues.SetValues(delete_group);
                ctx.SaveChanges();

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

    #endregion

    #region Mostrar grupo

    public class ReadGroupImp : IReadGroup
    {
        private DataModels ctx;
        public ReadGroupImp()
        {
            ctx = new DataModels();
        }

        public List<ViewModelGroup> ReadGroup(int Id)
        {
            try
            {
                List<ViewModelGroup> salida = ctx.Tbl_Groups.Join(ctx.Tbl_Permissions,
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
                }).Where(w => w.Id == Id).ToList();

                return salida;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class ReadAllGroupImp : IReadAllGroup
    {
        private DataModels ctx;
        public ReadAllGroupImp()
        {
            ctx = new DataModels();
        }

        public List<Tbl_Groups> ReadAllGroup(string sortorder, string searchstring)
        {
            var show_group = from s in ctx.Tbl_Groups select s;

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
