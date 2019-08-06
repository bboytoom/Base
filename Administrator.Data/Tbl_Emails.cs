namespace Administrator.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Emails
    {
        public int Id { get; set; }

        public int Id_user { get; set; }

        public int Type_email { get; set; }

        [Required]
        [StringLength(80)]
        public string Email_email { get; set; }

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

        public int MainU_email { get; set; }

        public virtual Tbl_Users Tbl_Users { get; set; }
    }
}
