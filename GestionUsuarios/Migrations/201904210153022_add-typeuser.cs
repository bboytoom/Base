namespace GestionUsuarios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtypeuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Usuarios", "userType_usuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Usuarios", "userType_usuario");
        }
    }
}
