namespace Administrator.Manager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_group { get; set; }

        public bool Read_user_permission { get; set; }

        public bool Update_user_permission { get; set; }

        public bool Create_user_permission { get; set; }

        public bool Delete_user_permission { get; set; }

        public bool Read_group_permission { get; set; }

        public bool Update_group_permission { get; set; }

        public bool Create_group_permission { get; set; }

        public bool Delete_group_permission { get; set; }

        public bool Read_permission_permission { get; set; }

        public bool Update_permission_permission { get; set; }

        public bool Create_permission_permission { get; set; }

        public bool Delete_permission_permission { get; set; }

        public bool Read_email_permission { get; set; }

        public bool Update_email_permission { get; set; }

        public bool Create_email_permission { get; set; }

        public bool Delete_email_permission { get; set; }

        public virtual Tbl_Groups Tbl_Groups { get; set; }
    }
}
