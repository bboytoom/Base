namespace Administrator.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Users()
        {
            Tbl_Emails = new HashSet<Tbl_Emails>();
        }

        public int Id { get; set; }

        public int Id_group { get; set; }

        public int Type_user { get; set; }

        [StringLength(60)]
        public string Photo_user { get; set; }

        [Required]
        [StringLength(80)]
        public string Email_user { get; set; }

        [Required]
        [StringLength(250)]
        public string Password_user { get; set; }

        [Required]
        [StringLength(50)]
        public string Name_user { get; set; }

        [Required]
        [StringLength(30)]
        public string LnameP_user { get; set; }

        [StringLength(30)]
        public string LnameM_user { get; set; }

        public bool Active_user { get; set; }

        public int? UpdateU_user { get; set; }

        public DateTime? UpdateD_user { get; set; }

        public int? CreateU_user { get; set; }

        public DateTime? CreateD_user { get; set; }

        public int? DeleteU_user { get; set; }

        public DateTime? DeleteD_user { get; set; }

        public bool? Delete_stautus_user { get; set; }

        public int? Attemp_user { get; set; }

        public int? Cycle_user { get; set; }

        public int MainU_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Emails> Tbl_Emails { get; set; }

        public virtual Tbl_Groups Tbl_Groups { get; set; }
    }
}
