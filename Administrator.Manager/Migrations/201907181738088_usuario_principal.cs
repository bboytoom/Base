namespace Administrator.Manager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class usuario_principal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Emails", "MainU_email", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Users", "MainU_user", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Groups", "MainU_group", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Tbl_Groups", "MainU_group");
            DropColumn("dbo.Tbl_Users", "MainU_user");
            DropColumn("dbo.Tbl_Emails", "MainU_email");
        }
    }
}
