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

        [Column("id", Order = 0)]
        [Key]
        public int Id { get; set; }

        [Column("id_main", Order = 1)]
        [Required]
        public int Id_main { get; set; }

        [Column("group", Order = 2, TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string Group { get; set; }

        [Column("description", Order = 3, TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column("read_user", Order = 4)]
        public bool Read_user { get; set; }

        [Column("update_user", Order = 5)]
        public bool Update_user { get; set; }

        [Column("create_user", Order = 6)]
        public bool Create_user { get; set; }

        [Column("delete_user", Order = 7)]
        public bool Delete_user { get; set; }

        [Column("read_group", Order = 8)]
        public bool Read_group { get; set; }

        [Column("update_group", Order = 9)]
        public bool Update_group { get; set; }

        [Column("create_group", Order = 10)]
        public bool Create_group { get; set; }

        [Column("delete_group", Order = 11)]
        public bool Delete_group { get; set; }

        [Column("read_permission", Order = 12)]
        public bool Read_permission { get; set; }

        [Column("update_permission", Order = 13)]
        public bool Update_permission { get; set; }

        [Column("create_permission", Order = 14)]
        public bool Create_permission { get; set; }

        [Column("delete_permission", Order = 15)]
        public bool Delete_permission { get; set; }

        [Column("status", Order = 16)]
        public bool Status { get; set; }

        [Column("edit_user", Order = 17)]
        public int? Edit_user { get; set; }

        [Column("edit_date", Order = 18)]
        public DateTime? Edit_date { get; set; }

        [Column("generate_user", Order = 19)]
        public int? Generate_user { get; set; }

        [Column("generate_date", Order = 20)]
        public DateTime? Generate_date { get; set; }

        [Column("remove_user", Order = 21)]
        public int? Remove_user { get; set; }

        [Column("remove_date", Order = 22)]
        public DateTime? Remove_date { get; set; }

        [Column("remove_status", Order = 23)]
        public bool? Remove_status { get; set; }

        public virtual ICollection<Tbl_Users> Tbl_Users { get; set; }
    }
}
