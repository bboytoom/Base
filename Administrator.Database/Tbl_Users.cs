using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administrator.Database
{
    [Table("Users")]
    public class Tbl_Users
    {
        public Tbl_Users() => Tbl_Entry = new HashSet<Tbl_Entry>();

        [Column("id", Order = 0)]
        [Key]
        public int Id { get; set; }

        [Column("id_main", Order = 1)]
        [Required]
        public int Id_main { get; set; }

        [Column("id_group", Order = 2)]
        [Required]
        public int Id_group { get; set; }

        [Column("type", Order = 3)]
        [Required]
        public int Type { get; set; }

        [Column("photo", Order = 4, TypeName = "varchar(60)")]
        [MaxLength(60)]
        public string Photo { get; set; }

        [Column("email", Order = 5, TypeName = "varchar(80)")]
        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Column("password", Order = 6, TypeName = "varchar(250)")]
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [Column("name", Order = 7, TypeName = "varchar(50)")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("lastnamep", Order = 8, TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string LnameP { get; set; }

        [Column("lastnamem", Order = 9, TypeName = "varchar(30)")]
        [MaxLength(30)]
        public string LnameM { get; set; }

        [Column("attemp", Order = 10)]
        public int? Attemp { get; set; }

        [Column("cycle", Order = 11)]
        public int? Cycle { get; set; }

        [Column("status", Order = 12)]
        public bool Status { get; set; }

        [Column("edit_user", Order = 13)]
        public int? Edit_user { get; set; }

        [Column("edit_date", Order = 14)]
        public DateTime? Edit_date { get; set; }

        [Column("generate_user", Order = 15)]
        public int? Generate_user { get; set; }

        [Column("generate_date", Order = 16)]
        public DateTime? Generate_date { get; set; }

        [Column("remove_user", Order = 17)]
        public int? Remove_user { get; set; }

        [Column("remove_date", Order = 18)]
        public DateTime? Remove_date { get; set; }

        [Column("remove_status", Order = 19)]
        public bool? Remove_status { get; set; }

        [ForeignKey("Id_group")]
        public virtual Tbl_Groups Tbl_Groups { get; set; }

        [ForeignKey("Type")]
        public virtual Cat_Users Cat_Users { get; set; }

        public virtual ICollection<Tbl_Entry> Tbl_Entry { get; set; }
    }
}
