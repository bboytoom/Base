using Administrator.Contract;
using Administrator.Data;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Manager
{
    #region ABC de la clase Group

    public class GroupImp
    {
        private Configuration connect;
        public GroupImp()
        {
            connect = Configuration.Ctx();
        }

        public ViewModelGroup Read(int id)
        {
            ViewModelGroup result = connect.getConexion.Tbl_Groups.Where(w => w.Id == id)
                    .Select(s => new ViewModelGroup
                    {
                        Id = s.Id,
                        Group = s.Group,
                        Description = s.Description,
                        Readuser = s.Read_user,
                        Createuser = s.Create_user,
                        Updateuser = s.Update_user,
                        Deleteuser = s.Delete_user,
                        Readgroup = s.Read_group,
                        Creategroup = s.Create_group,
                        Updategroup = s.Update_group,
                        Deletegroup = s.Delete_group,
                        Readpermission = s.Read_permission,
                        Createpermission = s.Create_permission,
                        Updatepermission = s.Update_permission,
                        Deletepermission = s.Delete_permission,
                        Status = s.Status
                    }).FirstOrDefault();

            return result;
        }

        public List<ViewModelReadGroup> ReadAll(int id_main)
        {
            List<ViewModelReadGroup> result = connect.getConexion
                .Tbl_Groups.Where(w => w.Id_main == id_main)
                .Select(s => new ViewModelReadGroup
                {
                    Id = s.Id,
                    Group = s.Group,
                    Description = s.Description,
                    Status = s.Status
                }).ToList();

            return result;
        }
    }

    #endregion
}