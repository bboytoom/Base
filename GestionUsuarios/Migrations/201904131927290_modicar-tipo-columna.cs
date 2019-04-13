namespace GestionUsuarios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modicartipocolumna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Correos", "elimina_status_correo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Usuarios", "elimina_status_usuario", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Grupos", "elimina_status_grupo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_Correos", "email_correo", c => c.String(nullable: false, maxLength: 80, unicode: false));
            AlterColumn("dbo.Tbl_Correos", "descripcion_correo", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Tbl_Usuarios", "foto_usuario", c => c.String(maxLength: 60, unicode: false));
            AlterColumn("dbo.Tbl_Usuarios", "password_usuario", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Tbl_Usuarios", "curp_usuario", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Tbl_Usuarios", "rfc_usuario", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Tbl_Usuarios", "nombre_usuario", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Tbl_Usuarios", "apellidoP_usuario", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Tbl_Usuarios", "apellidoM_usuario", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Tbl_Grupos", "nombre_grupo", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Tbl_Grupos", "descripcion_grupo", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Grupos", "descripcion_grupo", c => c.String(maxLength: 200));
            AlterColumn("dbo.Tbl_Grupos", "nombre_grupo", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Tbl_Usuarios", "apellidoM_usuario", c => c.String(maxLength: 30));
            AlterColumn("dbo.Tbl_Usuarios", "apellidoP_usuario", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Tbl_Usuarios", "nombre_usuario", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tbl_Usuarios", "rfc_usuario", c => c.String(maxLength: 20));
            AlterColumn("dbo.Tbl_Usuarios", "curp_usuario", c => c.String(maxLength: 20));
            AlterColumn("dbo.Tbl_Usuarios", "password_usuario", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Tbl_Usuarios", "foto_usuario", c => c.String(maxLength: 60));
            AlterColumn("dbo.Tbl_Correos", "descripcion_correo", c => c.String(maxLength: 200));
            AlterColumn("dbo.Tbl_Correos", "email_correo", c => c.String(nullable: false, maxLength: 80));
            DropColumn("dbo.Tbl_Grupos", "elimina_status_grupo");
            DropColumn("dbo.Tbl_Usuarios", "elimina_status_usuario");
            DropColumn("dbo.Tbl_Correos", "elimina_status_correo");
        }
    }
}
