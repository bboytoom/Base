using System;
using System.Collections.Generic;
using System.Linq;
using Administrator.Contract;
using Administrator.Database;
using Administrator.Query.Interface;

namespace Administrator.Query
{
    #region ABC de la clase Group

    public class GroupsImp : IOperations<ViewModelGroup, ViewModelReadGroup>
    {
        private Configuration _connect;
        public GroupsImp()
        {
            _connect = Configuration.Ctx();
        }

        public bool Create(ViewModelGroup data, int hieghUser, int main)
        {
            try
            {
                var create_group = new Tbl_Groups
                {
                    Id = data.Id,
                    Id_main = main,
                    Group = data.Group,
                    Description = data.Description,
                    Read_user = data.Readuser,
                    Update_user = data.Updateuser,
                    Create_user = data.Createuser,
                    Delete_user = data.Deleteuser,
                    Read_group = data.Readgroup,
                    Update_group = data.Updategroup,
                    Create_group = data.Creategroup,
                    Delete_group = data.Deletegroup,
                    Read_permission = data.Readpermission,
                    Update_permission = data.Updatepermission,
                    Create_permission = data.Createpermission,
                    Delete_permission = data.Deletepermission,
                    Status = true,
                    Generate_user = hieghUser,
                    Generate_date = DateTime.Now
                };

                _connect.getConexion.Tbl_Groups.Add(create_group);
                _connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id, int hieghUser)
        {
            try
            {
                var search_group = _connect.getConexion.Tbl_Groups.Find(id);

                var delete_group = new Tbl_Groups
                {
                    Id = search_group.Id,
                    Id_main = search_group.Id_main,
                    Group = search_group.Group,
                    Description = search_group.Description,
                    Status = false,
                    Generate_user = search_group.Generate_user,
                    Generate_date = search_group.Generate_date,
                    Remove_user = hieghUser,
                    Remove_date = DateTime.Now,
                    Remove_status = true
                };

                _connect.getConexion.Entry(search_group).CurrentValues.SetValues(delete_group);
                _connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ViewModelGroup Read(int id)
        {
            ViewModelGroup result = _connect.getConexion.Tbl_Groups.Where(w => w.Id.Equals(id))
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

        public IEnumerable<ViewModelReadGroup> ReadAll(int id_main)
        {
            IEnumerable<ViewModelReadGroup> result = _connect.getConexion
                .Tbl_Groups.Where(w => w.Id_main.Equals(id_main))
                .Select(s => new ViewModelReadGroup
                {
                    Id = s.Id,
                    Group = s.Group,
                    Description = s.Description,
                    Status = s.Status
                }).ToList();

            return result;
        }

        public bool Update(ViewModelGroup data, int hieghUser)
        {
            try
            {
                var search_group = _connect.getConexion.Tbl_Groups.Find(data.Id);

                var update_group = new Tbl_Groups
                {
                    Id = data.Id,
                    Id_main = search_group.Id_main,
                    Group = data.Group,
                    Description = data.Description,
                    Read_user = data.Readuser,
                    Update_user = data.Updateuser,
                    Create_user = data.Createuser,
                    Delete_user = data.Deleteuser,
                    Read_group = data.Readgroup,
                    Update_group = data.Updategroup,
                    Create_group = data.Creategroup,
                    Delete_group = data.Deletegroup,
                    Read_permission = data.Readpermission,
                    Update_permission = data.Updatepermission,
                    Create_permission = data.Createpermission,
                    Delete_permission = data.Deletepermission,
                    Status = data.Status,
                    Generate_user = search_group.Generate_user,
                    Generate_date = search_group.Generate_date,
                    Edit_user = hieghUser,
                    Edit_date = DateTime.Now
                };

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion
}