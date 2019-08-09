using Administrator.Contract;
using Administrator.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Query
{
    #region Actualizacion del password

    public class PasswordImp
    {
        private Configuration connect;
        public PasswordImp()
        {
            connect = Configuration.Ctx();
        }

        public bool Check(int id, string password)
        {
            var result = connect.getConexion.Tbl_Users
                .Where(w => w.Id == id && w.Password == password).FirstOrDefault();

            if (result != null)
                return true;

            return false;
        }

        public bool Change(int id, string password)
        {
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(id);

            try
            {
                var update_user = new Tbl_Users()
                {
                    Id = id,
                    Id_main = find_user.Id_main,
                    Id_group = find_user.Id_group,
                    Photo = find_user.Photo,
                    Type = find_user.Type,
                    Email = find_user.Email,
                    Password = password,
                    Name = find_user.Name,
                    LnameM = find_user.LnameM,
                    LnameP = find_user.LnameP,
                    Status = find_user.Status,
                    Edit_user = find_user.Edit_user,
                    Edit_date = DateTime.Now,
                    Generate_user = find_user.Generate_user,
                    Generate_date = find_user.Generate_date
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(update_user);
                connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion

    #region Obtiene el permisos del usuario para cada evento

    public static class PermissionImp
    {
        public static bool Check(string Permision, int Id)
        {
            Configuration connect = Configuration.Ctx();

            return connect.getConexion.Database
                .SqlQuery<bool>("SELECT " + Permision + " Manager.Groups g " +
                "LEFT JOIN Manager.Users u ON g.id = u.id_group WHERE u.id = " + Id).FirstOrDefault();
        }
    }

    #endregion

    #region Obtiene los grupos que le pertenecen a los usuarios

    public static class GroupXUserImp
    {
        public static List<ViewModelGroupList> Read(int id)
        {
            Configuration connect = Configuration.Ctx();

            List<ViewModelGroupList> result = connect.getConexion.Tbl_Groups
                .Where(w => w.Id_main == id && w.Id != 1)
                .Select(s => new ViewModelGroupList
                {
                    Id = s.Id,
                    Name = s.Group
                }).ToList();

            return result;
        }
    }

    #endregion
}
