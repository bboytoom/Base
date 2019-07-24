namespace Administrator.Manager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Emails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Id_user = c.Int(nullable: false),
                    Type_email = c.Int(nullable: false),
                    Email_email = c.String(nullable: false, maxLength: 80, unicode: false),
                    Description_email = c.String(maxLength: 200, unicode: false),
                    Active_email = c.Boolean(nullable: false),
                    UpdateU_email = c.Int(),
                    UpdateD_email = c.DateTime(),
                    CreateU_email = c.Int(),
                    CreateD_email = c.DateTime(),
                    DeleteU_email = c.Int(),
                    DeleteD_email = c.DateTime(),
                    Delete_stautus_email = c.Boolean(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Users", t => t.Id_user, cascadeDelete: true)
                .Index(t => t.Id_user);

            CreateTable(
                "dbo.Tbl_Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Id_group = c.Int(nullable: false),
                    Type_user = c.Int(nullable: false),
                    Photo_user = c.String(maxLength: 60, unicode: false),
                    Email_user = c.String(nullable: false, maxLength: 80, unicode: false),
                    Password_user = c.String(nullable: false, maxLength: 250, unicode: false),
                    Name_user = c.String(nullable: false, maxLength: 50, unicode: false),
                    LnameP_user = c.String(nullable: false, maxLength: 30, unicode: false),
                    LnameM_user = c.String(maxLength: 30, unicode: false),
                    Active_user = c.Boolean(nullable: false),
                    UpdateU_user = c.Int(),
                    UpdateD_user = c.DateTime(),
                    CreateU_user = c.Int(),
                    CreateD_user = c.DateTime(),
                    DeleteU_user = c.Int(),
                    DeleteD_user = c.DateTime(),
                    Delete_stautus_user = c.Boolean(),
                    Attemp_user = c.Int(),
                    Cycle_user = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Groups", t => t.Id_group, cascadeDelete: true)
                .Index(t => t.Id_group);

            CreateTable(
                "dbo.Tbl_Groups",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name_group = c.String(nullable: false, maxLength: 30, unicode: false),
                    Description_group = c.String(maxLength: 200, unicode: false),
                    Active_group = c.Boolean(nullable: false),
                    UpdateU_group = c.Int(),
                    UpdateD_group = c.DateTime(),
                    CreateU_group = c.Int(),
                    CreateD_group = c.DateTime(),
                    DeleteU_group = c.Int(),
                    DeleteD_group = c.DateTime(),
                    Delete_stautus_group = c.Boolean(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tbl_Permissions",
                c => new
                {
                    Id_group = c.Int(nullable: false),
                    Read_user_permission = c.Boolean(nullable: false),
                    Update_user_permission = c.Boolean(nullable: false),
                    Create_user_permission = c.Boolean(nullable: false),
                    Delete_user_permission = c.Boolean(nullable: false),
                    Read_group_permission = c.Boolean(nullable: false),
                    Update_group_permission = c.Boolean(nullable: false),
                    Create_group_permission = c.Boolean(nullable: false),
                    Delete_group_permission = c.Boolean(nullable: false),
                    Read_permission_permission = c.Boolean(nullable: false),
                    Update_permission_permission = c.Boolean(nullable: false),
                    Create_permission_permission = c.Boolean(nullable: false),
                    Delete_permission_permission = c.Boolean(nullable: false),
                    Read_email_permission = c.Boolean(nullable: false),
                    Update_email_permission = c.Boolean(nullable: false),
                    Create_email_permission = c.Boolean(nullable: false),
                    Delete_email_permission = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id_group)
                .ForeignKey("dbo.Tbl_Groups", t => t.Id_group)
                .Index(t => t.Id_group);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Users", "Id_group", "dbo.Tbl_Groups");
            DropForeignKey("dbo.Tbl_Permissions", "Id_group", "dbo.Tbl_Groups");
            DropForeignKey("dbo.Tbl_Emails", "Id_user", "dbo.Tbl_Users");
            DropIndex("dbo.Tbl_Permissions", new[] { "Id_group" });
            DropIndex("dbo.Tbl_Users", new[] { "Id_group" });
            DropIndex("dbo.Tbl_Emails", new[] { "Id_user" });
            DropTable("dbo.Tbl_Permissions");
            DropTable("dbo.Tbl_Groups");
            DropTable("dbo.Tbl_Users");
            DropTable("dbo.Tbl_Emails");
        }
    }
}
