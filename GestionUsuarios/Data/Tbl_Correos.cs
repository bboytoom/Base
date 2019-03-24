namespace Administrator.Manager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Correos
    {
        public int id { get; set; }

        public int id_usuario { get; set; }

        public bool principal_correo { get; set; }

        [Required]
        [StringLength(80)]
        public string email_correo { get; set; }

        [StringLength(200)]
        public string descripcion_correo { get; set; }

        public bool activo_correo { get; set; }

        public int? actualizaU_correo { get; set; }

        public DateTime? actualizaF_correo { get; set; }

        public int? altaU_correo { get; set; }

        public DateTime? altaF_correo { get; set; }

        public int? eliminaU_correo { get; set; }

        public DateTime? eliminaF_correo { get; set; }

        public virtual Tbl_Usuarios Tbl_Usuarios { get; set; }
    }
}
