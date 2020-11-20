using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Administration.Web.Migrations
{
    public partial class DeleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyReport_AspNetUsers_applicationUserId",
                table: "WeeklyReport");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyReport_applicationUserId",
                table: "WeeklyReport");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "WeeklyReport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "WeeklyReport",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_applicationUserId",
                table: "WeeklyReport",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyReport_AspNetUsers_applicationUserId",
                table: "WeeklyReport",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
