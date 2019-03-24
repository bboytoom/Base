namespace Administrator.Manager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Usuarios()
        {
            Tbl_Correos = new HashSet<Tbl_Correos>();
        }

        public int id { get; set; }

        public int id_grupo { get; set; }

        [StringLength(60)]
        public string foto_usuario { get; set; }

        [Required]
        [StringLength(250)]
        public string password_usuario { get; set; }

        [StringLength(20)]
        public string curp_usuario { get; set; }

        [StringLength(20)]
        public string rfc_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_usuario { get; set; }

        [Required]
        [StringLength(30)]
        public string apellidoP_usuario { get; set; }

        [StringLength(30)]
        public string apellidoM_usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime? nacimientoF_usuario { get; set; }

        public bool activo_usuario { get; set; }

        public int? actualizaU_usuario { get; set; }

        public DateTime? actualizaF_usuario { get; set; }

        public int? altaU_usuario { get; set; }

        public DateTime? altaF_usuario { get; set; }

        public int? eliminaU_usuario { get; set; }

        public DateTime? eliminaF_usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Correos> Tbl_Correos { get; set; }

        public virtual Tbl_Grupos Tbl_Grupos { get; set; }
    }
}
