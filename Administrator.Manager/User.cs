using Administrator.Contract;
using Administrator.Data;
using Administrator.Manager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Manager
{
    #region ABC de la clase usuario usuario

    public class UserImp
    {
        private Configuration connect;
        public UserImp()
        {
            connect = Configuration.Ctx();
        }

        public void Create(ViewModelUser Data, int HieghUser, int MainUser)
        {
            string passwordCry = HEncrypt.PasswordEncryp(Data.Password);

            try
            {
                var insert_user = new Tbl_Users()
                {
                    Id_group = Data.Idgroup,
                    Type_user = Data.Typeuser,
                    MainU_user = MainUser,
                    Email_user = Data.Email,
                    Password_user = passwordCry,
                    Name_user = Data.Name,
                    LnameP_user = Data.Lnamep,
                    LnameM_user = Data.Lnamem,
                    Active_user = true,
                    Photo_user = "default.png",
                    CreateU_user = HieghUser,
                    CreateD_user = DateTime.Now
                };

                connect.getConexion.Tbl_Users.Add(insert_user);
                connect.getConexion.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ViewModelUser Data, int HieghUser, int MainUser)
        {
            try
            {
                Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(Data.Id);

                var update_user = new Tbl_Users()
                {
                    Id = Data.Id,
                    Id_group = Data.Idgroup,
                    Type_user = Data.Typeuser,
                    MainU_user = find_user.MainU_user,
                    Email_user = Data.Email,
                    Password_user = find_user.Password_user,
                    Name_user = Data.Name,
                    LnameP_user = Data.Lnamep,
                    LnameM_user = Data.Lnamem,
                    Photo_user = find_user.Photo_user,
                    Active_user = Data.Status,
                    UpdateU_user = HieghUser,
                    UpdateD_user = DateTime.Now,
                    CreateU_user = find_user.CreateU_user,
                    CreateD_user = find_user.CreateD_user
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(update_user);
                connect.getConexion.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int Id, int HieghUser)
        {
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Find(Id);

            try
            {
                var delete_user = new Tbl_Users()
                {
                    Id = Id,
                    Id_group = find_user.Id_group,
                    MainU_user = find_user.MainU_user,
                    Type_user = find_user.Type_user,
                    Photo_user = find_user.Photo_user,
                    Email_user = find_user.Email_user,
                    Password_user = find_user.Password_user,
                    Name_user = find_user.Name_user,
                    LnameP_user = find_user.LnameP_user,
                    LnameM_user = find_user.LnameM_user,
                    Active_user = false,
                    DeleteU_user = HieghUser,
                    DeleteD_user = DateTime.Now,
                    Delete_stautus_user = true
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(delete_user);
                connect.getConexion.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ViewModelUser Read(int Id)
        {
            try
            {
                ViewModelUser salida = connect.getConexion.Tbl_Users.Where(w => w.Id == Id)
                    .Select(s => new ViewModelUser
                    {
                        Id = s.Id,
                        Idgroup = s.Id_group,
                        Typeuser = s.Type_user,
                        Email = s.Email_user,
                        Name = s.Name_user,
                        Nameimg = s.Photo_user,
                        Lnamep = s.LnameP_user,
                        Lnamem = s.LnameM_user,
                        Status = s.Active_user
                    }).FirstOrDefault();

                return salida;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ViewModelReadUser> ReadAll(string sortorder, string searchstring, int id_main)
        {
            var show_user = from s in connect.getConexion.Tbl_Users
                            where s.MainU_user == id_main
                            select new ViewModelReadUser
                            {
                                Id = s.Id,
                                Email = s.Email_user,
                                Photo = s.Photo_user,
                                FullName = s.LnameP_user + " " + s.LnameM_user + " " + s.Name_user,
                                Status = s.Active_user
                            };

            if (!String.IsNullOrEmpty(searchstring))
                show_user = show_user.Where(s => s.FullName.Contains(searchstring));

            switch (sortorder)
            {
                case "name_desc":
                    show_user = show_user.OrderByDescending(s => s.FullName);
                    break;
                default:
                    show_user = show_user.OrderBy(s => s.FullName);
                    break;
            }

            return show_user.ToList();
        }
    }

    #endregion
}
