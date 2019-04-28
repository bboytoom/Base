namespace GestionUsuarios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnasdecontroldeacceso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Usuarios", "ciclos_usuario", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Usuarios", "intentos_usuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Usuarios", "intentos_usuario");
            DropColumn("dbo.Tbl_Usuarios", "ciclos_usuario");
        }
    }
}
