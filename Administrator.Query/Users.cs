using Administrator.Contract;
using Administrator.Data;
using Administrator.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Query
{
    #region ABC de la clase User

    public class UsersImp : IOperations<ViewModelUser, ViewModelReadUser>
    {
        private Configuration connect;
        public UsersImp()
        {
            connect = Configuration.Ctx();
        }

        public bool Create(ViewModelUser data, int hieghUser, int main)
        {
            try
            {
                var insert_user = new Tbl_Users()
                {
                    Id_group = data.Idgroup,
                    Type = data.Type,
                    Id_main = main,
                    Email = data.Email,
                    Password = data.Password,
                    Name = data.Name,
                    LnameP = data.Lnamep,
                    LnameM = data.Lnamem,
                    Status = true,
                    Photo = data.Photo,
                    Generate_user = hieghUser,
                    Generate_date = DateTime.Now
                };

                connect.getConexion.Tbl_Users.Add(insert_user);
                connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id, int hieghUser)
        {
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(id);

            try
            {
                var delete_user = new Tbl_Users()
                {
                    Id = id,
                    Id_group = find_user.Id_group,
                    Id_main = find_user.Id_main,
                    Type = find_user.Type,
                    Photo = find_user.Photo,
                    Email = find_user.Email,
                    Password = find_user.Password,
                    Name = find_user.Name,
                    LnameP = find_user.LnameP,
                    LnameM = find_user.LnameM,
                    Status = false,
                    Remove_user = hieghUser,
                    Remove_date = DateTime.Now,
                    Remove_status = true
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(delete_user);
                connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ViewModelUser Read(int id)
        {
            ViewModelUser result = connect.getConexion.Tbl_Users
                    .Where(w => w.Id.Equals(id)).Select(s => new ViewModelUser
                    {
                        Id = s.Id,
                        Idgroup = s.Id_group,
                        Type = s.Type,
                        Email = s.Email,
                        Name = s.Name,
                        Photo = s.Photo,
                        Lnamep = s.LnameP,
                        Lnamem = s.LnameM,
                        Status = s.Status
                    }).FirstOrDefault();

            return result;
        }

        public IEnumerable<ViewModelReadUser> ReadAll(int id_main)
        {
            IEnumerable<ViewModelReadUser> result = connect.getConexion
                .Tbl_Users.Where(w => w.Id_main.Equals(id_main))
                .Select(s => new ViewModelReadUser
                {
                    Id = s.Id,
                    Email = s.Email,
                    Photo = s.Photo,
                    FullName = s.LnameP + " " + s.LnameM + " " + s.Name,
                    Status = s.Status
                }).ToList();

            return result;
        }

        public bool Update(ViewModelUser data, int hieghUser)
        { 
            try
            {
                Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(data.Id);

                var update_user = new Tbl_Users()
                {
                    Id = data.Id,
                    Id_group = data.Idgroup,
                    Type = data.Type,
                    Id_main = find_user.Id_main,
                    Email = data.Email,
                    Password = find_user.Password,
                    Name = data.Name,
                    LnameP = data.Lnamep,
                    LnameM = data.Lnamem,
                    Photo = find_user.Photo,
                    Status = data.Status,
                    Edit_user = hieghUser,
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
