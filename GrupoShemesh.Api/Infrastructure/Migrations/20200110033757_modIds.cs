using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Web.Migrations
{
    public partial class modIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_IdCustomer",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Professions_IdProfession",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_Customers_IdCustomer",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_DirectoryCondominium_IdDirectoryCondominium",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_Employee_IdEmployee",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_ResponsibleAreas_IdResponsibleArea",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_AspNetUsers_applicationUserId",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_ApplicationUserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectoryCondominium_Customers_IdCustomer",
                table: "DirectoryCondominium");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectoryCondominium_AspNetUsers_applicationUserId",
                table: "DirectoryCondominium");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Customers_IdCustomer",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Professions_IdProfession",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_applicationUserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Machinery_Customers_IdCustomer",
                table: "Machinery");

            migrationBuilder.DropForeignKey(
                name: "FK_Machinery_AspNetUsers_applicationUserId",
                table: "Machinery");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportSupervision_Customers_IdCustomer",
                table: "ReportSupervision");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportSupervision_AspNetUsers_applicationUserId",
                table: "ReportSupervision");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_applicationUserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_Customers_IdCustomer",
                table: "Tool");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_AspNetUsers_applicationUserId",
                table: "Tool");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyReport_Customers_IdCustomer",
                table: "WeeklyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyReport_Requests_IdRequest",
                table: "WeeklyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyReport_ResponsibleAreas_IdResponsibleArea",
                table: "WeeklyReport");

            migrationBuilder.RenameColumn(
                name: "IdResponsibleArea",
                table: "WeeklyReport",
                newName: "ResponsibleAreaId");

            migrationBuilder.RenameColumn(
                name: "IdRequest",
                table: "WeeklyReport",
                newName: "RequestId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "WeeklyReport",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdWeeklyReport",
                table: "WeeklyReport",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyReport_IdResponsibleArea",
                table: "WeeklyReport",
                newName: "IX_WeeklyReport_ResponsibleAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyReport_IdRequest",
                table: "WeeklyReport",
                newName: "IX_WeeklyReport_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyReport_IdCustomer",
                table: "WeeklyReport",
                newName: "IX_WeeklyReport_CustomerId");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "Tool",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Tool",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdTool",
                table: "Tool",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_applicationUserId",
                table: "Tool",
                newName: "IX_Tool_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_IdCustomer",
                table: "Tool",
                newName: "IX_Tool_CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdResponsibleArea",
                table: "ResponsibleAreas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "Requests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdRequest",
                table: "Requests",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_applicationUserId",
                table: "Requests",
                newName: "IX_Requests_UserId");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "ReportSupervision",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "ReportSupervision",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdReportSupervision",
                table: "ReportSupervision",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSupervision_applicationUserId",
                table: "ReportSupervision",
                newName: "IX_ReportSupervision_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSupervision_IdCustomer",
                table: "ReportSupervision",
                newName: "IX_ReportSupervision_CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdProfession",
                table: "Professions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "Machinery",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Machinery",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdMachinery",
                table: "Machinery",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Machinery_applicationUserId",
                table: "Machinery",
                newName: "IX_Machinery_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Machinery_IdCustomer",
                table: "Machinery",
                newName: "IX_Machinery_CustomerId");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "Employee",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdProfession",
                table: "Employee",
                newName: "ProfessionId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Employee",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdEmployee",
                table: "Employee",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_applicationUserId",
                table: "Employee",
                newName: "IX_Employee_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_IdProfession",
                table: "Employee",
                newName: "IX_Employee_ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_IdCustomer",
                table: "Employee",
                newName: "IX_Employee_CustomerId");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "DirectoryCondominium",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "DirectoryCondominium",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdDirectoryCondominium",
                table: "DirectoryCondominium",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DirectoryCondominium_applicationUserId",
                table: "DirectoryCondominium",
                newName: "IX_DirectoryCondominium_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectoryCondominium_IdCustomer",
                table: "DirectoryCondominium",
                newName: "IX_DirectoryCondominium_CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Category",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Category",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ApplicationUserId",
                table: "Category",
                newName: "IX_Category_UserId");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "CallAdmin",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdResponsibleArea",
                table: "CallAdmin",
                newName: "ResponsibleAreaId");

            migrationBuilder.RenameColumn(
                name: "IdEmployee",
                table: "CallAdmin",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "IdDirectoryCondominium",
                table: "CallAdmin",
                newName: "DirectoryCondominiumId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "CallAdmin",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdCallAdmin",
                table: "CallAdmin",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_applicationUserId",
                table: "CallAdmin",
                newName: "IX_CallAdmin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_IdResponsibleArea",
                table: "CallAdmin",
                newName: "IX_CallAdmin_ResponsibleAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_IdEmployee",
                table: "CallAdmin",
                newName: "IX_CallAdmin_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_IdDirectoryCondominium",
                table: "CallAdmin",
                newName: "IX_CallAdmin_DirectoryCondominiumId");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_IdCustomer",
                table: "CallAdmin",
                newName: "IX_CallAdmin_CustomerId");

            migrationBuilder.RenameColumn(
                name: "IdProfession",
                table: "AspNetUsers",
                newName: "ProfessionId");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "AspNetUsers",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdProfession",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdCustomer",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Professions_ProfessionId",
                table: "AspNetUsers",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_Customers_CustomerId",
                table: "CallAdmin",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_DirectoryCondominium_DirectoryCondominiumId",
                table: "CallAdmin",
                column: "DirectoryCondominiumId",
                principalTable: "DirectoryCondominium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_Employee_EmployeeId",
                table: "CallAdmin",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_ResponsibleAreas_ResponsibleAreaId",
                table: "CallAdmin",
                column: "ResponsibleAreaId",
                principalTable: "ResponsibleAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_AspNetUsers_UserId",
                table: "CallAdmin",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_UserId",
                table: "Category",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoryCondominium_Customers_CustomerId",
                table: "DirectoryCondominium",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoryCondominium_AspNetUsers_UserId",
                table: "DirectoryCondominium",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Customers_CustomerId",
                table: "Employee",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Professions_ProfessionId",
                table: "Employee",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machinery_Customers_CustomerId",
                table: "Machinery",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machinery_AspNetUsers_UserId",
                table: "Machinery",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSupervision_Customers_CustomerId",
                table: "ReportSupervision",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSupervision_AspNetUsers_UserId",
                table: "ReportSupervision",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_Customers_CustomerId",
                table: "Tool",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_AspNetUsers_UserId",
                table: "Tool",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyReport_Customers_CustomerId",
                table: "WeeklyReport",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyReport_Requests_RequestId",
                table: "WeeklyReport",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyReport_ResponsibleAreas_ResponsibleAreaId",
                table: "WeeklyReport",
                column: "ResponsibleAreaId",
                principalTable: "ResponsibleAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Professions_ProfessionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_Customers_CustomerId",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_DirectoryCondominium_DirectoryCondominiumId",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_Employee_EmployeeId",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_ResponsibleAreas_ResponsibleAreaId",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CallAdmin_AspNetUsers_UserId",
                table: "CallAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_UserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectoryCondominium_Customers_CustomerId",
                table: "DirectoryCondominium");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectoryCondominium_AspNetUsers_UserId",
                table: "DirectoryCondominium");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Customers_CustomerId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Professions_ProfessionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Machinery_Customers_CustomerId",
                table: "Machinery");

            migrationBuilder.DropForeignKey(
                name: "FK_Machinery_AspNetUsers_UserId",
                table: "Machinery");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportSupervision_Customers_CustomerId",
                table: "ReportSupervision");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportSupervision_AspNetUsers_UserId",
                table: "ReportSupervision");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_UserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_Customers_CustomerId",
                table: "Tool");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_AspNetUsers_UserId",
                table: "Tool");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyReport_Customers_CustomerId",
                table: "WeeklyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyReport_Requests_RequestId",
                table: "WeeklyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyReport_ResponsibleAreas_ResponsibleAreaId",
                table: "WeeklyReport");

            migrationBuilder.RenameColumn(
                name: "ResponsibleAreaId",
                table: "WeeklyReport",
                newName: "IdResponsibleArea");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "WeeklyReport",
                newName: "IdRequest");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "WeeklyReport",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WeeklyReport",
                newName: "IdWeeklyReport");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyReport_ResponsibleAreaId",
                table: "WeeklyReport",
                newName: "IX_WeeklyReport_IdResponsibleArea");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyReport_RequestId",
                table: "WeeklyReport",
                newName: "IX_WeeklyReport_IdRequest");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyReport_CustomerId",
                table: "WeeklyReport",
                newName: "IX_WeeklyReport_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tool",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Tool",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tool",
                newName: "IdTool");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_UserId",
                table: "Tool",
                newName: "IX_Tool_applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_CustomerId",
                table: "Tool",
                newName: "IX_Tool_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ResponsibleAreas",
                newName: "IdResponsibleArea");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Requests",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Requests",
                newName: "IdRequest");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                newName: "IX_Requests_applicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ReportSupervision",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ReportSupervision",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReportSupervision",
                newName: "IdReportSupervision");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSupervision_UserId",
                table: "ReportSupervision",
                newName: "IX_ReportSupervision_applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSupervision_CustomerId",
                table: "ReportSupervision",
                newName: "IX_ReportSupervision_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Professions",
                newName: "IdProfession");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Machinery",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Machinery",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Machinery",
                newName: "IdMachinery");

            migrationBuilder.RenameIndex(
                name: "IX_Machinery_UserId",
                table: "Machinery",
                newName: "IX_Machinery_applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Machinery_CustomerId",
                table: "Machinery",
                newName: "IX_Machinery_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employee",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "ProfessionId",
                table: "Employee",
                newName: "IdProfession");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Employee",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "IdEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_UserId",
                table: "Employee",
                newName: "IX_Employee_applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ProfessionId",
                table: "Employee",
                newName: "IX_Employee_IdProfession");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CustomerId",
                table: "Employee",
                newName: "IX_Employee_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DirectoryCondominium",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "DirectoryCondominium",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DirectoryCondominium",
                newName: "IdDirectoryCondominium");

            migrationBuilder.RenameIndex(
                name: "IX_DirectoryCondominium_UserId",
                table: "DirectoryCondominium",
                newName: "IX_DirectoryCondominium_applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectoryCondominium_CustomerId",
                table: "DirectoryCondominium",
                newName: "IX_DirectoryCondominium_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Category",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "IdCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Category_UserId",
                table: "Category",
                newName: "IX_Category_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CallAdmin",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "ResponsibleAreaId",
                table: "CallAdmin",
                newName: "IdResponsibleArea");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "CallAdmin",
                newName: "IdEmployee");

            migrationBuilder.RenameColumn(
                name: "DirectoryCondominiumId",
                table: "CallAdmin",
                newName: "IdDirectoryCondominium");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CallAdmin",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CallAdmin",
                newName: "IdCallAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_UserId",
                table: "CallAdmin",
                newName: "IX_CallAdmin_applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_ResponsibleAreaId",
                table: "CallAdmin",
                newName: "IX_CallAdmin_IdResponsibleArea");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_EmployeeId",
                table: "CallAdmin",
                newName: "IX_CallAdmin_IdEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_DirectoryCondominiumId",
                table: "CallAdmin",
                newName: "IX_CallAdmin_IdDirectoryCondominium");

            migrationBuilder.RenameIndex(
                name: "IX_CallAdmin_CustomerId",
                table: "CallAdmin",
                newName: "IX_CallAdmin_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "ProfessionId",
                table: "AspNetUsers",
                newName: "IdProfession");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "AspNetUsers",
                newName: "IdCustomer");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ProfessionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdProfession");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_IdCustomer",
                table: "AspNetUsers",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Professions_IdProfession",
                table: "AspNetUsers",
                column: "IdProfession",
                principalTable: "Professions",
                principalColumn: "IdProfession",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_Customers_IdCustomer",
                table: "CallAdmin",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_DirectoryCondominium_IdDirectoryCondominium",
                table: "CallAdmin",
                column: "IdDirectoryCondominium",
                principalTable: "DirectoryCondominium",
                principalColumn: "IdDirectoryCondominium",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_Employee_IdEmployee",
                table: "CallAdmin",
                column: "IdEmployee",
                principalTable: "Employee",
                principalColumn: "IdEmployee",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_ResponsibleAreas_IdResponsibleArea",
                table: "CallAdmin",
                column: "IdResponsibleArea",
                principalTable: "ResponsibleAreas",
                principalColumn: "IdResponsibleArea",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallAdmin_AspNetUsers_applicationUserId",
                table: "CallAdmin",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_ApplicationUserId",
                table: "Category",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoryCondominium_Customers_IdCustomer",
                table: "DirectoryCondominium",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoryCondominium_AspNetUsers_applicationUserId",
                table: "DirectoryCondominium",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Customers_IdCustomer",
                table: "Employee",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Professions_IdProfession",
                table: "Employee",
                column: "IdProfession",
                principalTable: "Professions",
                principalColumn: "IdProfession",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_applicationUserId",
                table: "Employee",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machinery_Customers_IdCustomer",
                table: "Machinery",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machinery_AspNetUsers_applicationUserId",
                table: "Machinery",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSupervision_Customers_IdCustomer",
                table: "ReportSupervision",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSupervision_AspNetUsers_applicationUserId",
                table: "ReportSupervision",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_applicationUserId",
                table: "Requests",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_Customers_IdCustomer",
                table: "Tool",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_AspNetUsers_applicationUserId",
                table: "Tool",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyReport_Customers_IdCustomer",
                table: "WeeklyReport",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyReport_Requests_IdRequest",
                table: "WeeklyReport",
                column: "IdRequest",
                principalTable: "Requests",
                principalColumn: "IdRequest",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyReport_ResponsibleAreas_IdResponsibleArea",
                table: "WeeklyReport",
                column: "IdResponsibleArea",
                principalTable: "ResponsibleAreas",
                principalColumn: "IdResponsibleArea",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
