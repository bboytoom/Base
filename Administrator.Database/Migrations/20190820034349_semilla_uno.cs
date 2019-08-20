using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Administrator.Database.Migrations
{
    public partial class semilla_uno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cat_Users",
                columns: new[] { "id", "description", "edit_date", "edit_user", "generate_date", "generate_user", "id_main", "type_user", "remove_date", "remove_status", "remove_user", "status" },
                values: new object[,]
                {
                    { 1, "Usuario con todos los privilegios", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 546, DateTimeKind.Local).AddTicks(5059), 1, 1, "ROOT", null, null, null, true },
                    { 2, "Usuario de apoyo", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 546, DateTimeKind.Local).AddTicks(6800), 1, 1, "STAFF", null, null, null, true },
                    { 3, "Usuario de apoyo", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 546, DateTimeKind.Local).AddTicks(6844), 1, 1, "ADMINISTRADOR", null, null, null, true },
                    { 4, "Usuario de apoyo para el administrador", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 546, DateTimeKind.Local).AddTicks(6860), 1, 1, "USUARIO", null, null, null, true },
                    { 5, "Cliente del administrador", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 546, DateTimeKind.Local).AddTicks(6880), 1, 1, "CLIENTE", null, null, null, true },
                    { 6, "Proveedor del administrador", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 546, DateTimeKind.Local).AddTicks(6895), 1, 1, "PROVEEDOR", null, null, null, true },
                    { 7, "contador del administrador", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 546, DateTimeKind.Local).AddTicks(6916), 1, 1, "CONTADOR", null, null, null, true }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "id", "create_group", "create_permission", "create_user", "delete_group", "delete_permission", "delete_user", "description", "edit_date", "edit_user", "generate_date", "generate_user", "group", "id_main", "read_group", "read_permission", "read_user", "remove_date", "remove_status", "remove_user", "status", "update_group", "update_permission", "update_user" },
                values: new object[,]
                {
                    { 1, true, true, true, true, true, true, "Grupo del Administrador General", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 534, DateTimeKind.Local).AddTicks(9977), 1, "Root", 1, true, true, true, null, null, null, true, true, true, true },
                    { 2, true, false, true, false, false, false, "Grupo de apoyo para el administrador general", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 540, DateTimeKind.Local).AddTicks(8263), 1, "Staff", 1, true, false, true, null, null, null, true, false, false, true },
                    { 3, true, true, true, true, true, true, "Grupo del administrador de la cuenta", null, null, new DateTime(2019, 8, 19, 22, 43, 47, 540, DateTimeKind.Local).AddTicks(8312), 1, "Administrador", 1, true, true, true, null, null, null, true, true, true, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "attemp", "cycle", "edit_date", "edit_user", "email", "generate_date", "generate_user", "id_group", "id_main", "lastnamem", "lastnamep", "name", "password", "photo", "remove_date", "remove_status", "remove_user", "status", "type" },
                values: new object[] { 1, null, null, null, null, "root@hotmail.es", new DateTime(2019, 8, 19, 22, 43, 47, 548, DateTimeKind.Local).AddTicks(4570), 1, 1, 1, "materno", "paterno", "soy root", "6859F96680702A57A951EABE43FEC49964EA51DDE72DF97E43A1FCF6F8B41B89A51CAE8F3162C0CBB3E7FD0850577759AA653E25C4BDFD57264015FA6588360F", "default.png", null, null, null, true, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "attemp", "cycle", "edit_date", "edit_user", "email", "generate_date", "generate_user", "id_group", "id_main", "lastnamem", "lastnamep", "name", "password", "photo", "remove_date", "remove_status", "remove_user", "status", "type" },
                values: new object[] { 2, null, null, null, null, "administrador@hotmail.es", new DateTime(2019, 8, 19, 22, 43, 47, 548, DateTimeKind.Local).AddTicks(6948), 1, 3, 1, "adminmaterno", "adminpaterno", "soy admin", "CFBD3E3A8ADC49B9E0061ADE86C84B499012048C903185821F9428DD981C4610B6D660D484A88641BF81B5B840422EA9E3A5DA29C12821EED60B0D281E5F43DB", "default.png", null, null, null, true, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cat_Users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cat_Users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cat_Users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cat_Users",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cat_Users",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cat_Users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cat_Users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
