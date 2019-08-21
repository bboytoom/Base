using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administrator.Database
{
    [Table("Entry")]
    public class Tbl_Entry
    {
        [Column("id", Order = 0)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("id_user", Order = 1)]
        public int Id_user { get; set; }

        [Column("fullname", Order = 2, TypeName = "varchar(80)")]
        [Required]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Column("ip", Order = 3, TypeName = "varchar(15)")]
        [Required]
        [MaxLength(15)]
        public string IP_User { get; set; }

        [Column("browser", Order = 4, TypeName = "varchar(50)")]
        [Required]
        [MaxLength(50)]
        public string Browser { get; set; }

        [Column("entry_date", Order = 5)]
        public DateTime? Entry_date { get; set; }

        [ForeignKey("Id_user")]
        public virtual Tbl_Users Tbl_Users { get; set; }
    }
}