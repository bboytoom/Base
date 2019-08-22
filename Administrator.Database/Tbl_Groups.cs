using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administrator.Database
{
    [Table("Groups")]
    public class Tbl_Groups
    {
        public Tbl_Groups() => Tbl_Users = new HashSet<Tbl_Users>();

        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("id_main", Order = 2)]
        [Required]
        public int Id_main { get; set; }

        [Column("group", Order = 3, TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string Group { get; set; }

        [Column("description", Order = 4, TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column("status", Order = 5)]
        public bool Status { get; set; }

        [Column("edit_user", Order = 6)]
        public int? Edit_user { get; set; }

        [Column("edit_date", Order = 7)]
        public DateTime? Edit_date { get; set; }

        [Column("generate_user", Order = 8)]
        public int? Generate_user { get; set; }

        [Column("generate_date", Order = 9)]
        public DateTime? Generate_date { get; set; }

        [Column("remove_user", Order = 10)]
        public int? Remove_user { get; set; }

        [Column("remove_date", Order = 11)]
        public DateTime? Remove_date { get; set; }

        [Column("remove_status", Order = 12)]
        public bool? Remove_status { get; set; }

        public Tbl_Permission_User Permission_User { get; set; }

        public Tbl_Permission_Root Permission_Root { get; set; }

        public virtual ICollection<Tbl_Users> Tbl_Users { get; set; }
    }
}
