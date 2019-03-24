namespace Administrator.Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class store_group : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                CREATE PROCEDURE [dbo].[STR_CRUDGROUP]
                (
	                @token int,
	                @idgrupo int,
	                @name varchar(250),
	                @description varchar(250), 
                    @readuser bit,
                    @createuser bit, 
                    @updateuser bit, 
                    @deleteuser bit, 
                    @readgroup bit, 
                    @creategroup bit, 
                    @updategroup bit, 
                    @deletegroup bit, 
                    @readpermission bit, 
                    @createpermission bit, 
	                @updatepermission bit, 
	                @deletepermission bit, 
                    @reademail bit, 
                    @createemail bit, 
                    @updateemail bit,
                    @deleteemail bit, 
                    @status bit, 
                    @highUser bit 
                )
                AS

	                IF @token = 1
		                BEGIN
			                DECLARE @group_id INT;
		
			                INSERT INTO Tbl_Grupos
			                (
				                nombre_grupo,
				                descripcion_grupo,
				                activo_grupo,
				                altaU_grupo,
				                altaF_grupo
			                )
			                VALUES
			                (
				                @name,
				                @description,
				                1,
				                @highUser,
				                GETDATE()
			                );
			
			                SET @group_id = (SELECT id FROM Tbl_Grupos WHERE nombre_grupo = @name AND altaU_grupo = @highUser);
			
			                INSERT INTO Tbl_Permisos
			                (
				                id_grupo,
				                mostrarUsuario_permiso,
				                editarUsuario_permiso,
				                eliminarUsuario_permiso,
				                crearUsuario_permiso,
				                mostrarGrupo_permiso,
				                editarGrupo_permiso,
				                eliminarGrupo_permiso,
				                crearGrupo_permiso,
				                mostrarPermiso_permiso,
				                editarPermiso_permiso,
				                eliminarPermiso_permiso,
				                crearPermiso_permiso,
				                mostrarEmail_permiso,
				                editarEmail_permiso,
				                eliminarEmail_permiso,
				                crearEmail_permiso
			                )
			                VALUES
			                (
				                @group_id,
				                @readuser,
				                @updateuser, 
				                @deleteuser,
				                @createuser, 
				                @readgroup,
				                @updategroup, 
				                @deletegroup,
				                @creategroup, 
				                @readpermission,
				                @updatepermission, 
				                @deletepermission,
				                @createpermission, 
				                @reademail,
				                @updateemail, 
				                @deleteemail,
				                @createemail
			                );
		                END
		
	                IF @token = 2
		                BEGIN
			                UPDATE Tbl_Grupos
				                SET nombre_grupo = @name,
					                descripcion_grupo = @description,
					                activo_grupo = @status,
					                actualizaU_grupo = @highUser,
					                actualizaF_grupo = GETDATE()
			                WHERE id = @idgrupo;
			
			                UPDATE Tbl_Permisos
				                SET mostrarUsuario_permiso = @readuser,
					                editarUsuario_permiso = @updateuser,
					                eliminarUsuario_permiso = @deleteuser,
					                crearUsuario_permiso = @createuser,
					                mostrarGrupo_permiso = @readgroup,
					                editarGrupo_permiso = @updategroup,
					                eliminarGrupo_permiso = @deletegroup,
					                crearGrupo_permiso = @creategroup,
					                mostrarPermiso_permiso = @readpermission,
					                editarPermiso_permiso = @updatepermission,
					                eliminarPermiso_permiso = @deletepermission,
					                crearPermiso_permiso = @createpermission,
					                mostrarEmail_permiso = @reademail,
					                editarEmail_permiso = @updateemail,
					                eliminarEmail_permiso = @deleteemail,
					                crearEmail_permiso = @createemail
			                WHERE id_grupo = @idgrupo;
		                END
		
	                IF @token = 3
		                BEGIN
			                UPDATE Tbl_Grupos
				                SET activo_grupo = 0,
					                eliminaU_grupo = @highUser,
					                eliminaF_grupo = GETDATE()
			                WHERE id = @idgrupo;
		                END
                ");
        }

        public override void Down()
        {
            Sql("DROP PROCEDURE dbo.STR_CRUDGROUP");
        }
    }
}
