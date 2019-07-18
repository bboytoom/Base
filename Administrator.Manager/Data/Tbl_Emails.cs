namespace Administrator.Manager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Emails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Tbl_Users")]
        public int Id_user { get; set; }

        public int MainU_email { get; set; }
        
        public int Type_email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(80)]
        public string Email_email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Description_email { get; set; }

        public bool Active_email { get; set; }

        public int? UpdateU_email { get; set; }

        public DateTime? UpdateD_email { get; set; }

        public int? CreateU_email { get; set; }

        public DateTime? CreateD_email { get; set; }

        public int? DeleteU_email { get; set; }

        public DateTime? DeleteD_email { get; set; }

        public bool? Delete_stautus_email { get; set; }

        public virtual Tbl_Users Tbl_Users { get; set; }
    }
}
