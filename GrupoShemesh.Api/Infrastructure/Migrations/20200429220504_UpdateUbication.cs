using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Web.Migrations
{
    public partial class UpdateUbication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ubication",
                table: "Machinery",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubication",
                table: "Machinery");
        }
    }
}
