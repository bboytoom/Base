using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administrator.Database
{
    public class Cat_Users
    {
        public Cat_Users() => Tbl_Users = new HashSet<Tbl_Users>();

        [Column("id", Order = 0)]
        [Key]
        public int Id { get; set; }

        [Column("id_main", Order = 1)]
        [Required]
        public int Id_main { get; set; }

        [Column("type_user", Order = 2, TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("description", Order = 3, TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column("status", Order = 4)]
        public bool Status { get; set; }

        [Column("edit_user", Order = 5)]
        public int? Edit_user { get; set; }

        [Column("edit_date", Order = 6)]
        public DateTime? Edit_date { get; set; }

        [Column("generate_user", Order = 7)]
        public int? Generate_user { get; set; }

        [Column("generate_date", Order = 8)]
        public DateTime? Generate_date { get; set; }

        [Column("remove_user", Order = 9)]
        public int? Remove_user { get; set; }

        [Column("remove_date", Order = 10)]
        public DateTime? Remove_date { get; set; }

        [Column("remove_status", Order = 11)]
        public bool? Remove_status { get; set; }

        public virtual ICollection<Tbl_Users> Tbl_Users { get; set; }
    }
}
