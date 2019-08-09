using Administrator.Contract;
using Administrator.Data;
using System.Linq;

namespace Administrator.Query
{
    #region Verifica credenciales del usuario

    public class LoginImp
    {
        private Configuration connect;
        public LoginImp()
        {
            connect = Configuration.Ctx();
        }

        public ViewModelClaims Login(ViewModelsAuth data)
        {
            ViewModelClaims result = connect.getConexion.Tbl_Users
                .Where(w => w.Email == data.Email && w.Password == data.Password)
                .Select(s => new ViewModelClaims
                {
                    Identificador = s.Id.ToString(),
                    Fullname = s.Name + " " + s.LnameP + " " + s.LnameM,
                    MainUser = s.Id_main.ToString(),
                    Email = s.Email,
                    PhotoUser = s.Photo,
                    TypeUser = s.Type,
                }).FirstOrDefault();

            return result;
        }
    }

    #endregion

    #region Realiza los eventos de bloqueo para el modulo de autenticacion

    public static class Validation
    {
        public static bool Status(string email)
        {
            var connect = Configuration.Ctx();
            return connect.getConexion.Tbl_Users.Where(w => w.Email == email).FirstOrDefault().Status;
        }

        public static bool InsertAttemps(string email)
        {
            var connect = Configuration.Ctx();
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Where(w => w.Email == email).FirstOrDefault();

            var insert_attemp = new Tbl_Users()
            {
                Id = find_user.Id,
                Id_group = find_user.Id_group,
                Type = find_user.Type,
                Photo = find_user.Photo,
                Email = find_user.Email,
                Password = find_user.Password,
                Name = find_user.Name,
                LnameP = find_user.LnameP,
                LnameM = find_user.LnameM,
                Id_main = find_user.Id_main,
                Generate_date = find_user.Generate_date,
                Generate_user = find_user.Generate_user,
                Edit_date = find_user.Edit_date,
                Edit_user = find_user.Edit_user,
                Status = find_user.Status,
                Cycle = find_user.Cycle,
                Attemp = (find_user.Attemp + 1)
            };

            connect.getConexion.Entry(find_user).CurrentValues.SetValues(insert_attemp);
            connect.getConexion.SaveChanges();

            if (find_user.Attemp == 4)
                return true;

            return false;
        }

        public static bool InsertCycle(string email)
        {
            var connect = Configuration.Ctx();
            Tbl_Users find_user = connect.getConexion.Tbl_Users.Where(w => w.Email == email).FirstOrDefault();

            var cycle_attemp = new Tbl_Users()
            {
                Id = find_user.Id,
                Id_group = find_user.Id_group,
                Type = find_user.Type,
                Photo = find_user.Photo,
                Email = find_user.Email,
                Password = find_user.Password,
                Name = find_user.Name,
                LnameP = find_user.LnameP,
                LnameM = find_user.LnameM,
                Id_main = find_user.Id_main,
                Generate_date = find_user.Generate_date,
                Generate_user = find_user.Generate_user,
                Edit_date = find_user.Edit_date,
                Edit_user = find_user.Edit_user,
                Status = find_user.Status,
                Attemp = 0,
                Cycle = (find_user.Cycle + 1)
            };

            connect.getConexion.Entry(find_user).CurrentValues.SetValues(cycle_attemp);
            connect.getConexion.SaveChanges();

            if (find_user.Cycle == 3)
            {
                var lockuot_user = new Tbl_Users()
                {
                    Id = find_user.Id,
                    Id_group = find_user.Id_group,
                    Type = find_user.Type,
                    Photo = find_user.Photo,
                    Email = find_user.Email,
                    Password = find_user.Password,
                    Name = find_user.Name,
                    LnameP = find_user.LnameP,
                    LnameM = find_user.LnameM,
                    Id_main = find_user.Id_main,
                    Generate_date = find_user.Generate_date,
                    Generate_user = find_user.Generate_user,
                    Edit_date = find_user.Edit_date,
                    Edit_user = find_user.Edit_user,
                    Status = false,
                    Attemp = 0,
                    Cycle = 0
                };

                connect.getConexion.Entry(find_user).CurrentValues.SetValues(lockuot_user);
                connect.getConexion.SaveChanges();
            }

            return true;
        }

        public static bool ResetAttemps(string email)
        {
            var connect = Configuration.Ctx();

            Tbl_Users find_user = connect.getConexion.Tbl_Users.Where(w => w.Email == email).FirstOrDefault();

            var reset_attemp = new Tbl_Users()
            {
                Id = find_user.Id,
                Id_group = find_user.Id_group,
                Type = find_user.Type,
                Photo = find_user.Photo,
                Email = find_user.Email,
                Password = find_user.Password,
                Name = find_user.Name,
                LnameP = find_user.LnameP,
                LnameM = find_user.LnameM,
                Id_main = find_user.Id_main,
                Generate_date = find_user.Generate_date,
                Generate_user = find_user.Generate_user,
                Edit_date = find_user.Edit_date,
                Edit_user = find_user.Edit_user,
                Status = true,
                Attemp = 0,
                Cycle = 0
            };

            connect.getConexion.Entry(find_user).CurrentValues.SetValues(reset_attemp);
            connect.getConexion.SaveChanges();

            return true;
        }
    }

    #endregion  
}
