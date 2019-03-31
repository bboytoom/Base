namespace GestionUsuarios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Correos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_usuario = c.Int(nullable: false),
                        principal_correo = c.Boolean(nullable: false),
                        email_correo = c.String(nullable: false, maxLength: 80),
                        descripcion_correo = c.String(maxLength: 200),
                        activo_correo = c.Boolean(nullable: false),
                        actualizaU_correo = c.Int(),
                        actualizaF_correo = c.DateTime(),
                        altaU_correo = c.Int(),
                        altaF_correo = c.DateTime(),
                        eliminaU_correo = c.Int(),
                        eliminaF_correo = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tbl_Usuarios", t => t.id_usuario, cascadeDelete: true)
                .Index(t => t.id_usuario);
            
            CreateTable(
                "dbo.Tbl_Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_grupo = c.Int(nullable: false),
                        foto_usuario = c.String(maxLength: 60),
                        password_usuario = c.String(nullable: false, maxLength: 250),
                        curp_usuario = c.String(maxLength: 20),
                        rfc_usuario = c.String(maxLength: 20),
                        nombre_usuario = c.String(nullable: false, maxLength: 50),
                        apellidoP_usuario = c.String(nullable: false, maxLength: 30),
                        apellidoM_usuario = c.String(maxLength: 30),
                        nacimientoF_usuario = c.DateTime(storeType: "date"),
                        activo_usuario = c.Boolean(nullable: false),
                        actualizaU_usuario = c.Int(),
                        actualizaF_usuario = c.DateTime(),
                        altaU_usuario = c.Int(),
                        altaF_usuario = c.DateTime(),
                        eliminaU_usuario = c.Int(),
                        eliminaF_usuario = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tbl_Grupos", t => t.id_grupo, cascadeDelete: true)
                .Index(t => t.id_grupo);
            
            CreateTable(
                "dbo.Tbl_Grupos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre_grupo = c.String(nullable: false, maxLength: 30),
                        descripcion_grupo = c.String(maxLength: 200),
                        activo_grupo = c.Boolean(nullable: false),
                        actualizaU_grupo = c.Int(),
                        actualizaF_grupo = c.DateTime(),
                        altaU_grupo = c.Int(),
                        altaF_grupo = c.DateTime(),
                        eliminaU_grupo = c.Int(),
                        eliminaF_grupo = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tbl_Permisos",
                c => new
                    {
                        id_grupo = c.Int(nullable: false),
                        mostrarUsuario_permiso = c.Boolean(nullable: false),
                        editarUsuario_permiso = c.Boolean(nullable: false),
                        crearUsuario_permiso = c.Boolean(nullable: false),
                        eliminarUsuario_permiso = c.Boolean(nullable: false),
                        mostrarGrupo_permiso = c.Boolean(nullable: false),
                        editarGrupo_permiso = c.Boolean(nullable: false),
                        crearGrupo_permiso = c.Boolean(nullable: false),
                        eliminarGrupo_permiso = c.Boolean(nullable: false),
                        mostrarPermiso_permiso = c.Boolean(nullable: false),
                        editarPermiso_permiso = c.Boolean(nullable: false),
                        crearPermiso_permiso = c.Boolean(nullable: false),
                        eliminarPermiso_permiso = c.Boolean(nullable: false),
                        mostrarEmail_permiso = c.Boolean(nullable: false),
                        editarEmail_permiso = c.Boolean(nullable: false),
                        crearEmail_permiso = c.Boolean(nullable: false),
                        eliminarEmail_permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_grupo)
                .ForeignKey("dbo.Tbl_Grupos", t => t.id_grupo)
                .Index(t => t.id_grupo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Usuarios", "id_grupo", "dbo.Tbl_Grupos");
            DropForeignKey("dbo.Tbl_Permisos", "id_grupo", "dbo.Tbl_Grupos");
            DropForeignKey("dbo.Tbl_Correos", "id_usuario", "dbo.Tbl_Usuarios");
            DropIndex("dbo.Tbl_Permisos", new[] { "id_grupo" });
            DropIndex("dbo.Tbl_Usuarios", new[] { "id_grupo" });
            DropIndex("dbo.Tbl_Correos", new[] { "id_usuario" });
            DropTable("dbo.Tbl_Permisos");
            DropTable("dbo.Tbl_Grupos");
            DropTable("dbo.Tbl_Usuarios");
            DropTable("dbo.Tbl_Correos");
        }
    }
}
