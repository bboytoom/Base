using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace GestionUsuarios.Implementation
{
    public class CheckEmailImp : ICheckEmail
    {
        private DataModels ctx;
        private CheckEmailImp()
        {
            ctx = new DataModels();
        }

        public string CheckEmail(string Email)
        {
            string email_clean;
            
            if (Email == "" || Email == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 200,
                        Respuesta = false
                    }
                );

            email_clean = WebUtility.HtmlEncode(Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 200,
                        Respuesta = false
                    }
                );

            try
            {
                var query_failed = ctx.Tbl_Usuarios.Join(ctx.Tbl_Correos,
                    pkuser => pkuser.id,
                    fkuser => fkuser.id_usuario,
                    (pkuser, fkuser) => new
                    {
                        USERS = pkuser,
                        EMAIL = fkuser
                    }).Where(w => w.EMAIL.email_correo == email_clean && w.USERS.activo_usuario == false)
                    .FirstOrDefault();


                if (query_failed == null)
                {
                    var query = ctx.Tbl_Correos
                    .Where(w => w.email_correo == email_clean && w.activo_correo == true)
                    .FirstOrDefault();

                    if (query == null)
                        return JsonConvert.SerializeObject(
                            new OutJsonCheck
                            {
                                Status = 404,
                                Respuesta = false
                            }
                        );

                    return JsonConvert.SerializeObject(
                        new OutJsonCheck
                        {
                            Status = 200,
                            Respuesta = true
                        }
                    );
                }

                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 401,
                        Respuesta = false
                    }
                );
            }
            catch (Exception)
            {
                CustomErrorDetail customError = new CustomErrorDetail(500, "Error en la peticion", "Hubo un error en la peticion a la base");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.InternalServerError);
            }
        }
    }

    public class LoginImp 
    {
        private DataModels ctx;
        public LoginImp()
        {
            ctx = new DataModels();
        }

        public Tbl_Usuarios Login(ViewModelsLogin data)
        {
            string password_clean;
            
            password_clean = HEncrypt.PasswordEncryp(data.Password);

            return ctx.Tbl_Usuarios.Join(ctx.Tbl_Correos,
                    pkusuario => pkusuario.id, fkusuario => fkusuario.id_usuario,
                    (pkusuario, fkusuario) => new
                    {
                        User_table = pkusuario,
                        Email_table = fkusuario
                    })
                    .Where(w => w.Email_table.email_correo == data.Email && w.User_table.password_usuario == password_clean)
                    .Select(s => s.User_table).FirstOrDefault();
        }
    }

    public static class LockOutUser
    {
        public static bool InsertAttemps(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    var search_user = ctx.Tbl_Usuarios.Join(ctx.Tbl_Correos,
                        pkuser => pkuser.id,
                        fkuser => fkuser.id_usuario,
                        (pkuser, fkuser) => new
                        {
                            USERS = pkuser,
                            EMAILS = fkuser
                        }).Where(w => w.EMAILS.email_correo == Email)
                        .Select(s => s.USERS).FirstOrDefault();
                    
                    var insert_attemp = new Tbl_Usuarios()
                    {
                        id = search_user.id,
                        id_grupo = search_user.id_grupo,
                        userType_usuario = search_user.userType_usuario,
                        foto_usuario = search_user.foto_usuario,
                        password_usuario = search_user.password_usuario,
                        curp_usuario = search_user.curp_usuario,
                        rfc_usuario = search_user.rfc_usuario,
                        nombre_usuario = search_user.nombre_usuario,
                        apellidoP_usuario = search_user.apellidoP_usuario,
                        apellidoM_usuario = search_user.apellidoM_usuario,
                        nacimientoF_usuario = search_user.nacimientoF_usuario,
                        activo_usuario = search_user.activo_usuario,
                        actualizaU_usuario = search_user.actualizaU_usuario,
                        actualizaF_usuario = search_user.actualizaF_usuario,
                        altaU_usuario = search_user.altaU_usuario,
                        altaF_usuario = search_user.altaF_usuario,
                        eliminaU_usuario = search_user.eliminaU_usuario,
                        eliminaF_usuario = search_user.eliminaF_usuario,
                        elimina_status_usuario = search_user.elimina_status_usuario,
                        ciclos_usuario = search_user.ciclos_usuario,                      
                        intentos_usuario = (search_user.intentos_usuario + 1)
                    };

                    ctx.Entry(search_user).CurrentValues.SetValues(insert_attemp);
                    ctx.SaveChanges();

                    if (search_user.intentos_usuario == 3)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void InsertCycle(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    var search_user = ctx.Tbl_Usuarios.Join(ctx.Tbl_Correos,
                        pkuser => pkuser.id,
                        fkuser => fkuser.id_usuario,
                        (pkuser, fkuser) => new
                        {
                            USERS = pkuser,
                            EMAILS = fkuser
                        }).Where(w => w.EMAILS.email_correo == Email)
                        .Select(s => s.USERS).FirstOrDefault();

                    var cycle_attemp = new Tbl_Usuarios()
                    {
                        id = search_user.id,                      
                        id_grupo = search_user.id_grupo,
                        userType_usuario = search_user.userType_usuario,
                        foto_usuario = search_user.foto_usuario,
                        password_usuario = search_user.password_usuario,
                        curp_usuario = search_user.curp_usuario,
                        rfc_usuario = search_user.rfc_usuario,
                        nombre_usuario = search_user.nombre_usuario,
                        apellidoP_usuario = search_user.apellidoP_usuario,
                        apellidoM_usuario = search_user.apellidoM_usuario,
                        nacimientoF_usuario = search_user.nacimientoF_usuario,
                        activo_usuario = search_user.activo_usuario,
                        actualizaU_usuario = search_user.actualizaU_usuario,
                        actualizaF_usuario = search_user.actualizaF_usuario,
                        altaU_usuario = search_user.altaU_usuario,
                        altaF_usuario = search_user.altaF_usuario,
                        eliminaU_usuario = search_user.eliminaU_usuario,
                        eliminaF_usuario = search_user.eliminaF_usuario,
                        elimina_status_usuario = search_user.elimina_status_usuario,
                        ciclos_usuario = (search_user.ciclos_usuario + 1),                     
                        intentos_usuario = 0                        
                    };

                    ctx.Entry(search_user).CurrentValues.SetValues(cycle_attemp);
                    ctx.SaveChanges();

                    if (search_user.ciclos_usuario == 3)
                    {
                        var lockuot_user = new Tbl_Usuarios()
                        {
                            id = search_user.id,
                            id_grupo = search_user.id_grupo,
                            userType_usuario = search_user.userType_usuario,
                            foto_usuario = search_user.foto_usuario,
                            password_usuario = search_user.password_usuario,
                            curp_usuario = search_user.curp_usuario,
                            rfc_usuario = search_user.rfc_usuario,
                            nombre_usuario = search_user.nombre_usuario,
                            apellidoP_usuario = search_user.apellidoP_usuario,
                            apellidoM_usuario = search_user.apellidoM_usuario,
                            nacimientoF_usuario = search_user.nacimientoF_usuario,
                            activo_usuario = false,
                            actualizaU_usuario = search_user.actualizaU_usuario,
                            actualizaF_usuario = search_user.actualizaF_usuario,
                            altaU_usuario = search_user.altaU_usuario,
                            altaF_usuario = search_user.altaF_usuario,
                            eliminaU_usuario = search_user.eliminaU_usuario,
                            eliminaF_usuario = search_user.eliminaF_usuario,
                            elimina_status_usuario = search_user.elimina_status_usuario,
                            ciclos_usuario = 0,
                            intentos_usuario = 0
                        };

                        ctx.Entry(search_user).CurrentValues.SetValues(lockuot_user);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void ResetAttemps(string Email)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    var search_user = ctx.Tbl_Usuarios.Join(ctx.Tbl_Correos,
                        pkuser => pkuser.id,
                        fkuser => fkuser.id_usuario,
                        (pkuser, fkuser) => new
                        {
                            USERS = pkuser,
                            EMAILS = fkuser
                        }).Where(w => w.EMAILS.email_correo == Email)
                        .Select(s => s.USERS).FirstOrDefault();

                    var reset_attemp = new Tbl_Usuarios()
                    {
                        id = search_user.id,
                        id_grupo = search_user.id_grupo,
                        userType_usuario = search_user.userType_usuario,
                        foto_usuario = search_user.foto_usuario,
                        password_usuario = search_user.password_usuario,
                        curp_usuario = search_user.curp_usuario,
                        rfc_usuario = search_user.rfc_usuario,
                        nombre_usuario = search_user.nombre_usuario,
                        apellidoP_usuario = search_user.apellidoP_usuario,
                        apellidoM_usuario = search_user.apellidoM_usuario,
                        nacimientoF_usuario = search_user.nacimientoF_usuario,
                        activo_usuario = search_user.activo_usuario,
                        actualizaU_usuario = search_user.actualizaU_usuario,
                        actualizaF_usuario = search_user.actualizaF_usuario,
                        altaU_usuario = search_user.altaU_usuario,
                        altaF_usuario = search_user.altaF_usuario,
                        eliminaU_usuario = search_user.eliminaU_usuario,
                        eliminaF_usuario = search_user.eliminaF_usuario,
                        elimina_status_usuario = search_user.elimina_status_usuario,
                        ciclos_usuario = 0,
                        intentos_usuario = 0
                    };

                    ctx.Entry(search_user).CurrentValues.SetValues(reset_attemp);
                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
