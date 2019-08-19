using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Administrator.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_main = table.Column<int>(nullable: false),
                    group = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    read_user = table.Column<bool>(nullable: false),
                    update_user = table.Column<bool>(nullable: false),
                    create_user = table.Column<bool>(nullable: false),
                    delete_user = table.Column<bool>(nullable: false),
                    read_group = table.Column<bool>(nullable: false),
                    update_group = table.Column<bool>(nullable: false),
                    create_group = table.Column<bool>(nullable: false),
                    delete_group = table.Column<bool>(nullable: false),
                    read_permission = table.Column<bool>(nullable: false),
                    update_permission = table.Column<bool>(nullable: false),
                    create_permission = table.Column<bool>(nullable: false),
                    delete_permission = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_Groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_main = table.Column<int>(nullable: false),
                    id_group = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    photo = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    email = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    password = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    lastnamep = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    lastnamem = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    attemp = table.Column<int>(nullable: true),
                    cycle = table.Column<int>(nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_id_group",
                        column: x => x.id_group,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_group",
                table: "Users",
                column: "id_group");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
