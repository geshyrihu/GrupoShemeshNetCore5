using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Web.Migrations
{
    public partial class DirectoryCondominium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameDirectoryCondominium",
                table: "DirectoryCondominium");

            migrationBuilder.AddColumn<int>(
                name: "Request",
                table: "CallAdmin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeRequest",
                table: "CallAdmin",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ListCondomino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Habitant = table.Column<int>(nullable: true),
                    NameDirectoryCondominium = table.Column<string>(nullable: true),
                    Extencion = table.Column<string>(nullable: true),
                    FixedPhone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    DirectoryCondominiumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListCondomino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListCondomino_DirectoryCondominium_DirectoryCondominiumId",
                        column: x => x.DirectoryCondominiumId,
                        principalTable: "DirectoryCondominium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListCondomino_DirectoryCondominiumId",
                table: "ListCondomino",
                column: "DirectoryCondominiumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListCondomino");

            migrationBuilder.DropColumn(
                name: "Request",
                table: "CallAdmin");

            migrationBuilder.DropColumn(
                name: "TimeRequest",
                table: "CallAdmin");

            migrationBuilder.AddColumn<string>(
                name: "NameDirectoryCondominium",
                table: "DirectoryCondominium",
                nullable: true);
        }
    }
}
