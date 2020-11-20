using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameCustomer = table.Column<string>(maxLength: 50, nullable: false),
                    RFC = table.Column<string>(nullable: false),
                    PhoneOne = table.Column<string>(nullable: false),
                    PhoneTwo = table.Column<string>(nullable: false),
                    Adreess = table.Column<string>(maxLength: 255, nullable: false),
                    Register = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    IdProfession = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameProfession = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.IdProfession);
                });

            migrationBuilder.CreateTable(
                name: "ResponsibleAreas",
                columns: table => new
                {
                    IdResponsibleArea = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameArea = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibleAreas", x => x.IdResponsibleArea);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Birth = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IdProfession = table.Column<int>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Professions_IdProfession",
                        column: x => x.IdProfession,
                        principalTable: "Professions",
                        principalColumn: "IdProfession",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameCotegory = table.Column<string>(maxLength: 20, nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                    table.ForeignKey(
                        name: "FK_Category_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DirectoryCondominium",
                columns: table => new
                {
                    IdDirectoryCondominium = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameDirectoryCondominium = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Tower = table.Column<string>(nullable: true),
                    IdCustomer = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryCondominium", x => x.IdDirectoryCondominium);
                    table.ForeignKey(
                        name: "FK_DirectoryCondominium_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DirectoryCondominium_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Birth = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TypeContract = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    Curp = table.Column<string>(nullable: false),
                    RFC = table.Column<string>(nullable: false),
                    NSS = table.Column<string>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    DateAdmission = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    CellPhone = table.Column<string>(nullable: false),
                    LocalPhone = table.Column<string>(nullable: false),
                    BloodType = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    EducationLevel = table.Column<int>(nullable: false),
                    Area = table.Column<int>(nullable: false),
                    IdProfession = table.Column<int>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employee_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Professions_IdProfession",
                        column: x => x.IdProfession,
                        principalTable: "Professions",
                        principalColumn: "IdProfession",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machinery",
                columns: table => new
                {
                    IdMachinery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameMachinery = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Serie = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: false),
                    Observations = table.Column<string>(maxLength: 255, nullable: true),
                    IdCustomer = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machinery", x => x.IdMachinery);
                    table.ForeignKey(
                        name: "FK_Machinery_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machinery_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportSupervision",
                columns: table => new
                {
                    IdReportSupervision = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Activity = table.Column<string>(maxLength: 255, nullable: true),
                    Observations = table.Column<string>(maxLength: 255, nullable: true),
                    IdCustomer = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSupervision", x => x.IdReportSupervision);
                    table.ForeignKey(
                        name: "FK_ReportSupervision_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportSupervision_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    IdRequest = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameRequest = table.Column<string>(maxLength: 255, nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.IdRequest);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tool",
                columns: table => new
                {
                    IdTool = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameTool = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Serie = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: false),
                    Observations = table.Column<string>(maxLength: 255, nullable: true),
                    IdCustomer = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tool", x => x.IdTool);
                    table.ForeignKey(
                        name: "FK_Tool_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tool_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CallAdmin",
                columns: table => new
                {
                    IdCallAdmin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateRequest = table.Column<DateTime>(nullable: false),
                    IdDirectoryCondominium = table.Column<int>(nullable: false),
                    RequestService = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IdResponsibleArea = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    Observations = table.Column<string>(nullable: true),
                    IdCustomer = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallAdmin", x => x.IdCallAdmin);
                    table.ForeignKey(
                        name: "FK_CallAdmin_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CallAdmin_DirectoryCondominium_IdDirectoryCondominium",
                        column: x => x.IdDirectoryCondominium,
                        principalTable: "DirectoryCondominium",
                        principalColumn: "IdDirectoryCondominium",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CallAdmin_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CallAdmin_ResponsibleAreas_IdResponsibleArea",
                        column: x => x.IdResponsibleArea,
                        principalTable: "ResponsibleAreas",
                        principalColumn: "IdResponsibleArea",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CallAdmin_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyReport",
                columns: table => new
                {
                    IdWeeklyReport = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoPathBefore = table.Column<string>(nullable: true),
                    PhotoPathAfter = table.Column<string>(nullable: true),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    DateRequest = table.Column<DateTime>(nullable: false),
                    Activity = table.Column<string>(nullable: false),
                    Observations = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    IdCustomer = table.Column<int>(nullable: false),
                    IdResponsibleArea = table.Column<int>(nullable: false),
                    IdRequest = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyReport", x => x.IdWeeklyReport);
                    table.ForeignKey(
                        name: "FK_WeeklyReport_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyReport_Requests_IdRequest",
                        column: x => x.IdRequest,
                        principalTable: "Requests",
                        principalColumn: "IdRequest",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyReport_ResponsibleAreas_IdResponsibleArea",
                        column: x => x.IdResponsibleArea,
                        principalTable: "ResponsibleAreas",
                        principalColumn: "IdResponsibleArea",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyReport_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyReport_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdCustomer",
                table: "AspNetUsers",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdProfession",
                table: "AspNetUsers",
                column: "IdProfession");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CallAdmin_IdCustomer",
                table: "CallAdmin",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CallAdmin_IdDirectoryCondominium",
                table: "CallAdmin",
                column: "IdDirectoryCondominium");

            migrationBuilder.CreateIndex(
                name: "IX_CallAdmin_IdEmployee",
                table: "CallAdmin",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_CallAdmin_IdResponsibleArea",
                table: "CallAdmin",
                column: "IdResponsibleArea");

            migrationBuilder.CreateIndex(
                name: "IX_CallAdmin_applicationUserId",
                table: "CallAdmin",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ApplicationUserId",
                table: "Category",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryCondominium_IdCustomer",
                table: "DirectoryCondominium",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryCondominium_applicationUserId",
                table: "DirectoryCondominium",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdCustomer",
                table: "Employee",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdProfession",
                table: "Employee",
                column: "IdProfession");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_applicationUserId",
                table: "Employee",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Machinery_IdCustomer",
                table: "Machinery",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Machinery_applicationUserId",
                table: "Machinery",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSupervision_IdCustomer",
                table: "ReportSupervision",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSupervision_applicationUserId",
                table: "ReportSupervision",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_applicationUserId",
                table: "Requests",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tool_IdCustomer",
                table: "Tool",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Tool_applicationUserId",
                table: "Tool",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_IdCustomer",
                table: "WeeklyReport",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_IdRequest",
                table: "WeeklyReport",
                column: "IdRequest");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_IdResponsibleArea",
                table: "WeeklyReport",
                column: "IdResponsibleArea");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_UserId",
                table: "WeeklyReport",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReport_applicationUserId",
                table: "WeeklyReport",
                column: "applicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CallAdmin");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Machinery");

            migrationBuilder.DropTable(
                name: "ReportSupervision");

            migrationBuilder.DropTable(
                name: "Tool");

            migrationBuilder.DropTable(
                name: "WeeklyReport");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DirectoryCondominium");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "ResponsibleAreas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Professions");
        }
    }
}
