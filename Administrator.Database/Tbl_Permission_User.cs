using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administrator.Database
{
    [Table("Permission_User")]
    public class Tbl_Permission_User
    {
        [Column("id_group", Order = 0)]
        public int Id { get; set; }

        [Column("read_user", Order = 1)]
        public bool Read_user { get; set; }

        [Column("update_user", Order = 2)]
        public bool Update_user { get; set; }

        [Column("create_user", Order = 3)]
        public bool Create_user { get; set; }

        [Column("delete_user", Order = 4)]
        public bool Delete_user { get; set; }

        [Column("read_group", Order = 5)]
        public bool Read_group { get; set; }

        [Column("update_group", Order = 6)]
        public bool Update_group { get; set; }

        [Column("create_group", Order = 7)]
        public bool Create_group { get; set; }

        [Column("delete_group", Order = 8)]
        public bool Delete_group { get; set; }

        [Column("read_permission", Order = 9)]
        public bool Read_permission { get; set; }

        [Column("update_permission", Order = 10)]
        public bool Update_permission { get; set; }

        [Column("create_permission", Order = 11)]
        public bool Create_permission { get; set; }

        [Column("delete_permission", Order = 12)]
        public bool Delete_permission { get; set; }

        public Tbl_Groups Tbl_Groups { get; set; }
    }
}
