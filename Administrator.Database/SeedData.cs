using Microsoft.EntityFrameworkCore;
using System;

namespace Administrator.Database
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Groups>().HasData(
                new Tbl_Groups
                {
                    Id = 1,
                    Id_main = 1,
                    Group = "Root",
                    Description = "Grupo del Administrador General",
                    Read_user = true,
                    Update_user = true,
                    Create_user = true,
                    Delete_user = true,
                    Read_group = true,
                    Update_group = true,
                    Create_group = true,
                    Delete_group = true,
                    Read_permission = true,
                    Update_permission = true,
                    Create_permission = true,
                    Delete_permission = true,
                    Status = true,
                    Generate_user = 1,
                    Generate_date = DateTime.Now
                },
                new Tbl_Groups
                {
                    Id = 2,
                    Id_main = 1,
                    Group = "Staff",
                    Description = "Grupo de apoyo para el administrador general",
                    Read_user = true,
                    Update_user = true,
                    Create_user = true,
                    Delete_user = false,
                    Read_group = true,
                    Update_group = false,
                    Create_group = true,
                    Delete_group = false,
                    Read_permission = false,
                    Update_permission = false,
                    Create_permission = false,
                    Delete_permission = false,
                    Status = true,
                    Generate_user = 1,
                    Generate_date = DateTime.Now
                },
                new Tbl_Groups
                {
                    Id = 3,
                    Id_main = 1,
                    Group = "Administrador",
                    Description = "Grupo del administrador de la cuenta",
                    Read_user = true,
                    Update_user = true,
                    Create_user = true,
                    Delete_user = true,
                    Read_group = true,
                    Update_group = true,
                    Create_group = true,
                    Delete_group = true,
                    Read_permission = true,
                    Update_permission = true,
                    Create_permission = true,
                    Delete_permission = true,
                    Status = true,
                    Generate_user = 1,
                    Generate_date = DateTime.Now
                }
            );

            modelBuilder.Entity<Cat_Users>().HasData(
              new Cat_Users
              {
                  Id = 1,
                  Id_main = 1,
                  Name = "ROOT",
                  Description = "Usuario con todos los privilegios",
                  Status = true,
                  Generate_user = 1,
                  Generate_date = DateTime.Now
              },
              new Cat_Users
              {
                  Id = 2,
                  Id_main = 1,
                  Name = "STAFF",
                  Description = "Usuario de apoyo",
                  Status = true,
                  Generate_user = 1,
                  Generate_date = DateTime.Now
              },
              new Cat_Users
              {
                  Id = 3,
                  Id_main = 1,
                  Name = "ADMINISTRADOR",
                  Description = "Usuario de apoyo",
                  Status = true,
                  Generate_user = 1,
                  Generate_date = DateTime.Now
              },
              new Cat_Users
              {
                  Id = 4,
                  Id_main = 1,
                  Name = "USUARIO",
                  Description = "Usuario de apoyo para el administrador",
                  Status = true,
                  Generate_user = 1,
                  Generate_date = DateTime.Now
              },
              new Cat_Users
              {
                  Id = 5,
                  Id_main = 1,
                  Name = "CLIENTE",
                  Description = "Cliente del administrador",
                  Status = true,
                  Generate_user = 1,
                  Generate_date = DateTime.Now
              },
              new Cat_Users
              {
                  Id = 6,
                  Id_main = 1,
                  Name = "PROVEEDOR",
                  Description = "Proveedor del administrador",
                  Status = true,
                  Generate_user = 1,
                  Generate_date = DateTime.Now
              },
              new Cat_Users
              {
                  Id = 7,
                  Id_main = 1,
                  Name = "CONTADOR",
                  Description = "contador del administrador",
                  Status = true,
                  Generate_user = 1,
                  Generate_date = DateTime.Now
              }
            );

            modelBuilder.Entity<Tbl_Users>().HasData(
                new Tbl_Users
                {
                    Id = 1,
                    Id_main = 1,
                    Id_group = 1,
                    Type = 1,
                    Photo = "default.png",
                    Email = "root@hotmail.es",
                    Password = "6859F96680702A57A951EABE43FEC49964EA51DDE72DF97E43A1FCF6F8B41B89A51CAE8F3162C0CBB3E7FD0850577759AA653E25C4BDFD57264015FA6588360F",
                    Name = "soy root",
                    LnameP = "paterno",
                    LnameM = "materno",
                    Status = true,
                    Attemp = 0,
                    Cycle = 0,
                    Generate_user = 1,
                    Generate_date = DateTime.Now
                },
                new Tbl_Users
                {
                    Id = 2,
                    Id_main = 1,
                    Id_group = 3,
                    Type = 3,
                    Photo = "default.png",
                    Email = "administrador@hotmail.es",
                    Password = "CFBD3E3A8ADC49B9E0061ADE86C84B499012048C903185821F9428DD981C4610B6D660D484A88641BF81B5B840422EA9E3A5DA29C12821EED60B0D281E5F43DB",
                    Name = "soy admin",
                    LnameP = "adminpaterno",
                    LnameM = "adminmaterno",
                    Status = true,
                    Attemp = 0,
                    Cycle = 0,
                    Generate_user = 1,
                    Generate_date = DateTime.Now
                }
            );
        }
    }
}
