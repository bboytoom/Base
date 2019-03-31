namespace GestionUsuarios.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Permisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_grupo { get; set; }

        public bool mostrarUsuario_permiso { get; set; }

        public bool editarUsuario_permiso { get; set; }

        public bool crearUsuario_permiso { get; set; }

        public bool eliminarUsuario_permiso { get; set; }

        public bool mostrarGrupo_permiso { get; set; }

        public bool editarGrupo_permiso { get; set; }

        public bool crearGrupo_permiso { get; set; }

        public bool eliminarGrupo_permiso { get; set; }

        public bool mostrarPermiso_permiso { get; set; }

        public bool editarPermiso_permiso { get; set; }

        public bool crearPermiso_permiso { get; set; }

        public bool eliminarPermiso_permiso { get; set; }

        public bool mostrarEmail_permiso { get; set; }

        public bool editarEmail_permiso { get; set; }

        public bool crearEmail_permiso { get; set; }

        public bool eliminarEmail_permiso { get; set; }

        public virtual Tbl_Grupos Tbl_Grupos { get; set; }
    }
}
