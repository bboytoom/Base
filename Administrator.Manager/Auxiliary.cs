using Administrator.Data;
using Administrator.Manager.Helpers;
using System;
using System.Linq;

namespace Administrator.Manager
{
    #region Cambio de password

    public class CheckPasswordImp
    {
        private Configuration connect;
        public CheckPasswordImp()
        {
            connect = Configuration.Ctx();
        }

        public bool CheckPassword(int Id, string Password)
        {
            string passwordCry = HEncrypt.PasswordEncryp(Password);

            var check = connect.getConexion.Tbl_Users
                .Where(w => w.Id == Id && w.Password_user == passwordCry).FirstOrDefault();

            if (check != null)
                return true;

            return false;
        }

        public bool ChangePasswordImp(int Id, string Password)
        {
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(Id);
            string passwordCry;

            if (find_user == null)
                return false;

            passwordCry = HEncrypt.PasswordEncryp(Password);

            var update_user = new Tbl_Users()
            {
                Id = Id,
                Photo_user = find_user.Photo_user,
                Type_user = find_user.Type_user,
                Id_group = find_user.Id_group,
                Email_user = find_user.Email_user,
                Password_user = passwordCry,
                Active_user = find_user.Active_user,
                MainU_user = find_user.MainU_user,
                Name_user = find_user.Name_user,
                LnameM_user = find_user.LnameM_user,
                LnameP_user = find_user.LnameP_user,
                UpdateU_user = find_user.UpdateU_user,
                UpdateD_user = DateTime.Now,
                CreateD_user = find_user.CreateD_user,
                CreateU_user = find_user.CreateU_user
            };

            connect.getConexion.Entry(find_user).CurrentValues.SetValues(update_user);
            connect.getConexion.SaveChanges();

            return true;
        }
    }

    #endregion

    #region Obtiene permisos del usuario

    public static class PermissionImp
    {
        public static bool PermissionUser(string NamePermision, int Id)
        {
            Configuration connect = Configuration.Ctx();

            return connect.getConexion.Database
                .SqlQuery<bool>("SELECT " + NamePermision + " FROM dbo.Tbl_Permissions p LEFT JOIN " +
                "dbo.Tbl_Users u ON p.Id_group = u.Id_group WHERE u.Id = " + Id).FirstOrDefault();
        }
    }

    #endregion
}
