namespace GestionUsuarios.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Grupos
    {
        public Tbl_Grupos()
        {
            Tbl_Usuarios = new HashSet<Tbl_Usuarios>();
        }

        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string nombre_grupo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string descripcion_grupo { get; set; }

        public bool activo_grupo { get; set; }

        public int? actualizaU_grupo { get; set; }

        public DateTime? actualizaF_grupo { get; set; }

        public int? altaU_grupo { get; set; }

        public DateTime? altaF_grupo { get; set; }

        public int? eliminaU_grupo { get; set; }

        public DateTime? eliminaF_grupo { get; set; }

        public bool elimina_status_grupo { get; set; }

        public virtual Tbl_Permisos Tbl_Permisos { get; set; }

        public virtual ICollection<Tbl_Usuarios> Tbl_Usuarios { get; set; }
    }
}
