using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Administration.Web.Migrations
{
    public partial class _27_01_2020callcenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameDirectoryCondominium",
                table: "ListCondomino",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Habitant",
                table: "ListCondomino",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tower",
                table: "DirectoryCondominium",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "DirectoryCondominium",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameDirectoryCondominium",
                table: "ListCondomino",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Habitant",
                table: "ListCondomino",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Tower",
                table: "DirectoryCondominium",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "DirectoryCondominium",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
