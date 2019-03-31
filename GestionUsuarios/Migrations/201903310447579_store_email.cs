namespace GestionUsuarios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class store_email : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                CREATE PROCEDURE [dbo].[STR_CRUDEMAIL]
                (
	                @token int,
	                @Id int,
	                @Iduser int,
	                @Mainemail bit,
	                @Email nvarchar(80),
	                @Description nvarchar(200),
	                @Status bit,
	                @HighUser int
                )
                AS

                IF @token = 1
		            BEGIN
			            INSERT INTO Tbl_Correos
			            (
				            id_usuario,
				            principal_correo,
				            email_correo,
				            descripcion_correo,
				            activo_correo,
				            altaU_correo,
				            altaF_correo
			            )
			            VALUES
			            (
				            @Iduser,
				            @Mainemail,
				            @Email,
				            @Description,
				            1,
				            @HighUser,
				            GETDATE()
			            );
		            END

	            IF @token = 2
		            BEGIN
			            UPDATE Tbl_Correos
				            SET id_usuario = @Iduser,
					            principal_correo = @Mainemail,
					            email_correo = @Email,
					            descripcion_correo = @Description,
					            activo_correo = @Status,
					            actualizaU_correo = @HighUser,
					            actualizaF_correo = GETDATE()
			            WHERE id = @Id
		            END
		
	            IF @token = 3
		            BEGIN
			            UPDATE Tbl_Correos
				            SET principal_correo = 0,
					            activo_correo = 0,
					            eliminaU_correo = @HighUser,
					            eliminaF_correo = GETDATE()
			            WHERE id = @Id
		            END
            ");
        }
        
        public override void Down()
        {
            Sql(@"DROP PROCEDURE dbo.STR_CRUDEMAIL");
        }
    }
}
