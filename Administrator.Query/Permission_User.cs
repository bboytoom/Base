using System;
using Administrator.Contract;
using Administrator.Database;

namespace Administrator.Query
{
    public static class Permission_UserImp
    {
        public static bool Create(ViewModelGroupUser data, int id)
        {
            var _connect = Configuration.Ctx();

            try
            {
                var create_permission = new Tbl_Permission_User
                {
                    Id = id,
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
                    Delete_permission = data.Deletepermission
                };

                _connect.getConexion.Tbl_Permission_User.Add(create_permission);
                _connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Update(ViewModelGroupUser data, int id)
        {
            var _connect = Configuration.Ctx();

            try
            {
                var search_permission = _connect.getConexion.Tbl_Permission_User.Find(id);

                var update_permission = new Tbl_Permission_User
                {
                    Id = id,
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
                    Delete_permission = data.Deletepermission
                };

                _connect.getConexion.Entry(search_permission).CurrentValues.SetValues(update_permission);
                _connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
