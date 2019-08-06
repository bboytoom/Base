using Administrator.Contract;
using Administrator.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Manager
{
    #region Mostrar grupo

    public class ReadGroupImp
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

        public List<ViewModelReadGroup> ReadAllGroup(string sortorder, string searchstring, int id_main)
        {
            var show_group = from s in connect.getConexion.Tbl_Groups
                             where s.MainU_group == id_main
                             select new ViewModelReadGroup
                             {
                                 Id = s.Id,
                                 Group = s.Name_group,
                                 Description = s.Description_group,
                                 Status = s.Active_group
                             };

            if (!String.IsNullOrEmpty(searchstring))
                show_group = show_group.Where(s => s.Group.Contains(searchstring));

            switch (sortorder)
            {
                case "name_desc":
                    show_group = show_group.OrderByDescending(s => s.Group);
                    break;
                default:
                    show_group = show_group.OrderBy(s => s.Group);
                    break;
            }

            return show_group.ToList();
        }
    }

    public static class ReadGroupUserImp
    {
        public static List<ViewModelGroupList> ReadGroupUser(int Id)
        {
            Configuration connect = Configuration.Ctx();

            List<ViewModelGroupList> salida = connect.getConexion.Tbl_Groups
                .Where(w => w.MainU_group == Id && w.Id != 1)
                .Select(s => new ViewModelGroupList
                {
                    Id = s.Id,
                    Name = s.Name_group
                }).ToList();

            return salida;
        }
    }

    #endregion
}