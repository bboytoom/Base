using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Administrator.Database.Migrations
{
    public partial class Create_cat_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_main = table.Column<int>(nullable: false),
                    type_user = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    status = table.Column<bool>(nullable: false),
                    edit_user = table.Column<int>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    generate_user = table.Column<int>(nullable: true),
                    generate_date = table.Column<DateTime>(nullable: true),
                    remove_user = table.Column<int>(nullable: true),
                    remove_date = table.Column<DateTime>(nullable: true),
                    remove_status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_type",
                table: "Users",
                column: "type");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cat_Users_type",
                table: "Users",
                column: "type",
                principalTable: "Cat_Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cat_Users_type",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Cat_Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_type",
                table: "Users");
        }
    }
}
