using GestionUsuarios.Data;
using GestionUsuarios.Flyweight;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace GestionUsuarios.Implementation
{
    public class CreateGroupImp : ICreateGroup
    {
        private DataModels ctx;
        private QueryGroup objetcQuery;
        private CreateGroupImp()
        {
            ctx = new DataModels();
        }

        public string CreateGroup(ViewModelGroup Data)
        {
            string name_clean = "";

            if (Data.Name == "" || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            name_clean = WebUtility.HtmlEncode(Data.Name.ToLower());

            var search_group = ctx.Tbl_Grupos.Where(w => w.nombre_grupo == name_clean).FirstOrDefault();

            if (search_group != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            objetcQuery = new QueryGroup(Data);
            return objetcQuery.Query(1);
        }
    }

    public class UpdateGroupImp : IUpdateGroup
    {
        private DataModels ctx;
        private QueryGroup objetcQuery;
        private UpdateGroupImp()
        {
            ctx = new DataModels();
        }

        public string UpdateGroup(ViewModelGroup Data)
        {         
            if (Data.Name == "" || Data.HighUser == 0 || Data.Id == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_group = ctx.Tbl_Grupos.Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_group == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            var search_group_repeat = ctx.Tbl_Grupos.Where(w => w.id != Data.Id && w.nombre_grupo == Data.Name).FirstOrDefault();

            if (search_group_repeat != null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Ya no esta disponible", "El grupo que ingreso ya se encuentra en uso");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.Gone);
            }

            objetcQuery = new QueryGroup(Data);
            return objetcQuery.Query(2);
        }
    }

    public class DeleteGroupImp : IDeleteGroup
    {
        private DataModels ctx;
        private QueryGroup objetcQuery;
        private DeleteGroupImp()
        {
            ctx = new DataModels();
        }

        public string DeleteGroup(ViewModelGroup Data)
        {
            if (Data.Id == 0 || Data.HighUser == 0)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Datos Faltantes", "Faltan algunos datos necesarios en la petición");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.BadRequest);
            }

            var search_group = ctx.Tbl_Grupos.Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_group == null)
            {
                CustomErrorDetail customError = new CustomErrorDetail("Dato no encontrado", "No se encontro ninguna coincidencia en los datos");
                throw new WebFaultException<CustomErrorDetail>(customError, HttpStatusCode.NotFound);
            }

            objetcQuery = new QueryGroup(Data);
            return objetcQuery.Query(3);
        }
    }

    public class ReadGroupImp : IReadGroup
    {
        private DataModels ctx;
        private ReadGroupImp()
        {
            ctx = new DataModels();
        }

        public List<ViewModelGroup> ReadGroup(int Id)
        {
            IQueryable<ViewModelGroup> salida;
            
            try
            {
                salida = ctx.Tbl_Grupos.Join(ctx.Tbl_Permisos,
                    pkgrupo => pkgrupo.id, 
                    fkgrupo => fkgrupo.id_grupo,
                    (pkgrupo, fkgrupo) => new ViewModelGroup
                    {
                        Id = pkgrupo.id,
                        Name = pkgrupo.nombre_grupo,
                        Description = pkgrupo.descripcion_grupo,
                        Readuser = fkgrupo.mostrarUsuario_permiso,
                        Createuser = fkgrupo.crearUsuario_permiso,
                        Updateuser = fkgrupo.editarUsuario_permiso,
                        Deleteuser = fkgrupo.eliminarUsuario_permiso,
                        Readgroup = fkgrupo.mostrarGrupo_permiso,
                        Creategroup = fkgrupo.crearGrupo_permiso,
                        Updategroup = fkgrupo.editarGrupo_permiso,
                        Deletegroup = fkgrupo.eliminarGrupo_permiso,
                        Readpermission = fkgrupo.mostrarPermiso_permiso,
                        Createpermission = fkgrupo.crearPermiso_permiso,
                        Updatepermission = fkgrupo.editarPermiso_permiso,
                        Deletepermission = fkgrupo.eliminarPermiso_permiso,
                        Reademail = fkgrupo.mostrarEmail_permiso,
                        Createemail = fkgrupo.crearEmail_permiso,
                        Updateemail = fkgrupo.editarEmail_permiso,
                        Deleteemail = fkgrupo.eliminarEmail_permiso,
                        Status = pkgrupo.activo_grupo
                    }).Where(w => w.Id == Id);

                return salida.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class ReadAllGroupImp : IReadAllGroup
    {
        private DataModels ctx;
        private ReadAllGroupImp()
        {
            ctx = new DataModels();
        }

        public List<Tbl_Grupos> ReadAllGroup()
        {
            IQueryable<Tbl_Grupos> salida;

            try
            {
                salida = ctx.Tbl_Grupos.Select(s => new Tbl_Grupos
                {
                    id = s.id,
                    nombre_grupo = s.nombre_grupo,
                    descripcion_grupo = s.descripcion_grupo,
                    activo_grupo = s.activo_grupo
                });
            }
            catch (Exception)
            {
                throw;
            }
            
            return salida.ToList();
        }
    }
}
