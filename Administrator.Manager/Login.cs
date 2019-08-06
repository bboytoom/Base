using Administrator.Contract;
using Administrator.Data;
using Administrator.Manager.Helpers;
using System;
using System.Linq;

namespace Administrator.Manager
{
    #region verifica credenciales

    public class LoginImp
    {
        private Configuration connect;
        public LoginImp()
        {
            connect = Configuration.Ctx();
        }

        public ViewModelClaims Login(ViewModelsAuth data)
        {
            string password_clean;
            password_clean = HEncrypt.PasswordEncryp(data.Password);

            ViewModelClaims salida = connect.getConexion.Tbl_Users
                .Where(w => w.Email_user == data.Email && w.Password_user == password_clean)
                .Select(s => new ViewModelClaims
                {
                    Identificador = s.Id.ToString(),
                    Fullname = s.Name_user + " " + s.LnameP_user + " " + s.LnameM_user,
                    MainUser = s.MainU_user.ToString(),
                    Email = s.Email_user,
                    PhotoUser = s.Photo_user,
                    TypeUser = s.Type_user,
                }).FirstOrDefault();

            return salida;
        }
    }

    #endregion

    #region Inicia las clases estaticas

    public static class CStatusUser
    {
        public static bool StatusUser(string Email)
        {
            Configuration connect = Configuration.Ctx();

            try
            {
                Tbl_Users find_user = connect.getConexion.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();
                return find_user.Active_user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public static class LockOutUser
    {
        public static bool InsertAttemps(string Email)
        {
            Configuration connect = Configuration.Ctx();

            try
            {
                Tbl_Users find_user = connect.getConexion.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();

                var insert_attemp = new Tbl_Users()
                {
                    Id = find_user.Id,
                    Id_group = find_user.Id_group,
                    Type_user = find_user.Type_user,
                    Photo_user = find_user.Photo_user,
                    Email_user = find_user.Email_user,
                    Password_user = find_user.Password_user,
                    Name_user = find_user.Name_user,
                    LnameP_user = find_user.LnameP_user,
                    LnameM_user = find_user.LnameM_user,
                    MainU_user = find_user.MainU_user,
                    CreateD_user = find_user.CreateD_user,
                    CreateU_user = find_user.CreateU_user,
                    UpdateD_user = find_user.UpdateD_user,
                    UpdateU_user = find_user.UpdateU_user,
                    Active_user = find_user.Active_user,
                    Cycle_user = find_user.Cycle_user,
                    Attemp_user = (find_user.Attemp_user + 1)
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(insert_attemp);
                connect.getConexion.SaveChanges();

                if (find_user.Attemp_user == 4)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InsertCycle(string Email)
        {
            Configuration connect = Configuration.Ctx();

            try
            {
                Tbl_Users find_user = connect.getConexion.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();

                var cycle_attemp = new Tbl_Users()
                {
                    Id = find_user.Id,
                    Id_group = find_user.Id_group,
                    Type_user = find_user.Type_user,
                    Photo_user = find_user.Photo_user,
                    Email_user = find_user.Email_user,
                    Password_user = find_user.Password_user,
                    Name_user = find_user.Name_user,
                    LnameP_user = find_user.LnameP_user,
                    LnameM_user = find_user.LnameM_user,
                    MainU_user = find_user.MainU_user,
                    CreateD_user = find_user.CreateD_user,
                    CreateU_user = find_user.CreateU_user,
                    UpdateD_user = find_user.UpdateD_user,
                    UpdateU_user = find_user.UpdateU_user,
                    Active_user = find_user.Active_user,
                    Attemp_user = 0,
                    Cycle_user = (find_user.Cycle_user + 1)
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(cycle_attemp);
                connect.getConexion.SaveChanges();

                if (find_user.Cycle_user == 3)
                {
                    var lockuot_user = new Tbl_Users()
                    {
                        Id = find_user.Id,
                        Id_group = find_user.Id_group,
                        Type_user = find_user.Type_user,
                        Photo_user = find_user.Photo_user,
                        Email_user = find_user.Email_user,
                        Password_user = find_user.Password_user,
                        Name_user = find_user.Name_user,
                        LnameP_user = find_user.LnameP_user,
                        LnameM_user = find_user.LnameM_user,
                        MainU_user = find_user.MainU_user,
                        CreateD_user = find_user.CreateD_user,
                        CreateU_user = find_user.CreateU_user,
                        UpdateD_user = find_user.UpdateD_user,
                        UpdateU_user = find_user.UpdateU_user,
                        Active_user = false,
                        Attemp_user = 0,
                        Cycle_user = 0
                    };

                    connect.getConexion.Entry(find_user).CurrentValues.SetValues(lockuot_user);
                    connect.getConexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ResetAttemps(string Email)
        {
            Configuration connect = Configuration.Ctx();

            try
            {
                Tbl_Users find_user = connect.getConexion.Tbl_Users.Where(w => w.Email_user == Email).FirstOrDefault();

                var reset_attemp = new Tbl_Users()
                {
                    Id = find_user.Id,
                    Id_group = find_user.Id_group,
                    Type_user = find_user.Type_user,
                    Photo_user = find_user.Photo_user,
                    Email_user = find_user.Email_user,
                    Password_user = find_user.Password_user,
                    Name_user = find_user.Name_user,
                    LnameP_user = find_user.LnameP_user,
                    LnameM_user = find_user.LnameM_user,
                    MainU_user = find_user.MainU_user,
                    CreateD_user = find_user.CreateD_user,
                    CreateU_user = find_user.CreateU_user,
                    UpdateD_user = find_user.UpdateD_user,
                    UpdateU_user = find_user.UpdateU_user,
                    Active_user = true,
                    Attemp_user = 0,
                    Cycle_user = 0
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(reset_attemp);
                connect.getConexion.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion  
}
