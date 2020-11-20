using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Web.Migrations
{
    public partial class inventory26022020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Tool",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Tool",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Tool",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPurchase",
                table: "Tool",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Tool",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Tool",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalSpecifications",
                table: "Tool",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Machinery",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Machinery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPurchase",
                table: "Machinery",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Machinery",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Machinery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalSpecifications",
                table: "Machinery",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaintenanceCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineryId = table.Column<int>(nullable: false),
                    TypeMaintance = table.Column<int>(nullable: false),
                    Recurrence = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Activity = table.Column<string>(nullable: false),
                    Observation = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceCalendars_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceCalendars_Machinery_MachineryId",
                        column: x => x.MachineryId,
                        principalTable: "Machinery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceCalendars_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceCalendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceCalendarId = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    ExecutionDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceOrders_MaintenanceCalendars_MaintenanceCalendarId",
                        column: x => x.MaintenanceCalendarId,
                        principalTable: "MaintenanceCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceOrders_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tool_CategoryId",
                table: "Tool",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Machinery_CategoryId",
                table: "Machinery",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCalendars_CustomerId",
                table: "MaintenanceCalendars",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCalendars_MachineryId",
                table: "MaintenanceCalendars",
                column: "MachineryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCalendars_ProviderId",
                table: "MaintenanceCalendars",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCalendars_UserId",
                table: "MaintenanceCalendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceOrders_CustomerId",
                table: "MaintenanceOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceOrders_MaintenanceCalendarId",
                table: "MaintenanceOrders",
                column: "MaintenanceCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceOrders_ProviderId",
                table: "MaintenanceOrders",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceOrders_UserId",
                table: "MaintenanceOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machinery_Category_CategoryId",
                table: "Machinery",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_Category_CategoryId",
                table: "Tool",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machinery_Category_CategoryId",
                table: "Machinery");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_Category_CategoryId",
                table: "Tool");

            migrationBuilder.DropTable(
                name: "MaintenanceOrders");

            migrationBuilder.DropTable(
                name: "MaintenanceCalendars");

            migrationBuilder.DropIndex(
                name: "IX_Tool_CategoryId",
                table: "Tool");

            migrationBuilder.DropIndex(
                name: "IX_Machinery_CategoryId",
                table: "Machinery");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "TechnicalSpecifications",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Machinery");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Machinery");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Machinery");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Machinery");

            migrationBuilder.DropColumn(
                name: "TechnicalSpecifications",
                table: "Machinery");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Tool",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Tool",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Machinery",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
