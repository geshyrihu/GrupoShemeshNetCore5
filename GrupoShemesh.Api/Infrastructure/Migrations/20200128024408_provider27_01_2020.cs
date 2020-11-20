using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Administration.Web.Migrations
{
    public partial class provider27_01_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    shortName = table.Column<string>(nullable: true),
                    LargeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    NameProvider = table.Column<string>(nullable: false),
                    Rfc = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PathPhoto = table.Column<string>(nullable: true),
                    Sales = table.Column<bool>(nullable: false),
                    Repair = table.Column<bool>(nullable: false),
                    phoneOne = table.Column<string>(nullable: true),
                    phoneTwo = table.Column<string>(nullable: true),
                    WebPage = table.Column<string>(nullable: true),
                    ContactOne = table.Column<string>(nullable: true),
                    PositionOne = table.Column<string>(nullable: true),
                    CellPhoneOne = table.Column<string>(nullable: true),
                    EmailOne = table.Column<string>(nullable: true),
                    ContactTwo = table.Column<string>(nullable: true),
                    PositionTwo = table.Column<string>(nullable: true),
                    CellPhoneTwo = table.Column<string>(nullable: true),
                    EmailTwo = table.Column<string>(nullable: true),
                    NameCheck = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    PaymentAccount = table.Column<string>(nullable: true),
                    InterbankCode = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Providers_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Providers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_BankId",
                table: "Providers",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CategoryId",
                table: "Providers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_UserId",
                table: "Providers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
