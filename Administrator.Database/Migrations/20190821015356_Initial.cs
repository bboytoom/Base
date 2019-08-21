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
                    table.ForeignKey(
                        name: "FK_Users_Cat_Users_type",
                        column: x => x.type,
                        principalTable: "Cat_Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_user = table.Column<int>(nullable: false),
                    fullname = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    browser = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    entry_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entry_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cat_Users",
                columns: new[] { "id", "description", "edit_date", "edit_user", "generate_date", "generate_user", "id_main", "type_user", "remove_date", "remove_status", "remove_user", "status" },
                values: new object[,]
                {
                    { 1, "Usuario con todos los privilegios", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 79, DateTimeKind.Local).AddTicks(9640), 1, 1, "ROOT", null, null, null, true },
                    { 2, "Usuario de apoyo", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 80, DateTimeKind.Local).AddTicks(380), 1, 1, "STAFF", null, null, null, true },
                    { 3, "Usuario de apoyo", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 80, DateTimeKind.Local).AddTicks(400), 1, 1, "ADMINISTRADOR", null, null, null, true },
                    { 4, "Usuario de apoyo para el administrador", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 80, DateTimeKind.Local).AddTicks(410), 1, 1, "USUARIO", null, null, null, true },
                    { 5, "Cliente del administrador", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 80, DateTimeKind.Local).AddTicks(420), 1, 1, "CLIENTE", null, null, null, true },
                    { 6, "Proveedor del administrador", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 80, DateTimeKind.Local).AddTicks(420), 1, 1, "PROVEEDOR", null, null, null, true },
                    { 7, "contador del administrador", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 80, DateTimeKind.Local).AddTicks(430), 1, 1, "CONTADOR", null, null, null, true }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "id", "create_group", "create_permission", "create_user", "delete_group", "delete_permission", "delete_user", "description", "edit_date", "edit_user", "generate_date", "generate_user", "group", "id_main", "read_group", "read_permission", "read_user", "remove_date", "remove_status", "remove_user", "status", "update_group", "update_permission", "update_user" },
                values: new object[,]
                {
                    { 1, true, true, true, true, true, true, "Grupo del Administrador General", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 72, DateTimeKind.Local).AddTicks(9790), 1, "Root", 1, true, true, true, null, null, null, true, true, true, true },
                    { 2, true, false, true, false, false, false, "Grupo de apoyo para el administrador general", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 77, DateTimeKind.Local).AddTicks(5860), 1, "Staff", 1, true, false, true, null, null, null, true, false, false, true },
                    { 3, true, true, true, true, true, true, "Grupo del administrador de la cuenta", null, null, new DateTime(2019, 8, 20, 20, 53, 56, 77, DateTimeKind.Local).AddTicks(5880), 1, "Administrador", 1, true, true, true, null, null, null, true, true, true, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "attemp", "cycle", "edit_date", "edit_user", "email", "generate_date", "generate_user", "id_group", "id_main", "lastnamem", "lastnamep", "name", "password", "photo", "remove_date", "remove_status", "remove_user", "status", "type" },
                values: new object[] { 1, 0, 0, null, null, "root@hotmail.es", new DateTime(2019, 8, 20, 20, 53, 56, 81, DateTimeKind.Local).AddTicks(610), 1, 1, 1, "materno", "paterno", "soy root", "6859F96680702A57A951EABE43FEC49964EA51DDE72DF97E43A1FCF6F8B41B89A51CAE8F3162C0CBB3E7FD0850577759AA653E25C4BDFD57264015FA6588360F", "default.png", null, null, null, true, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "attemp", "cycle", "edit_date", "edit_user", "email", "generate_date", "generate_user", "id_group", "id_main", "lastnamem", "lastnamep", "name", "password", "photo", "remove_date", "remove_status", "remove_user", "status", "type" },
                values: new object[] { 2, 0, 0, null, null, "administrador@hotmail.es", new DateTime(2019, 8, 20, 20, 53, 56, 81, DateTimeKind.Local).AddTicks(1350), 1, 3, 1, "adminmaterno", "adminpaterno", "soy admin", "CFBD3E3A8ADC49B9E0061ADE86C84B499012048C903185821F9428DD981C4610B6D660D484A88641BF81B5B840422EA9E3A5DA29C12821EED60B0D281E5F43DB", "default.png", null, null, null, true, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_id_user",
                table: "Entry",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_group",
                table: "Users",
                column: "id_group");

            migrationBuilder.CreateIndex(
                name: "IX_Users_type",
                table: "Users",
                column: "type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Cat_Users");
        }
    }
}
