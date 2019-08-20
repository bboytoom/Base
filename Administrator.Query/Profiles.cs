using Administrator.Database;
using Administrator.Query.Interface;
using System;
using System.Linq;

namespace Administrator.Query
{
    #region Actualizacion de credenciales del usuario

    public class Profiles : IChangeCredential
    {
        private Configuration connect;
        public Profiles()
        {
            connect = Configuration.Ctx();
        }

        public bool Check(int id, string password)
        {
            var result = connect.getConexion.Tbl_Users
                .Where(w => w.Id.Equals(id) && w.Password.Equals(password)).FirstOrDefault();

            if (result != null)
                return true;

            return false;
        }

        public bool ChangeEmail(int id, string email)
        {
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(id);

            try
            {
                var update_user = new Tbl_Users
                {
                    Id = id,
                    Id_main = find_user.Id_main,
                    Id_group = find_user.Id_group,
                    Photo = find_user.Photo,
                    Type = find_user.Type,
                    Email = email,
                    Password = find_user.Password,
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

        public bool ChangePassword(int id, string password)
        {
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(id);

            try
            {
                var update_user = new Tbl_Users
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
}
