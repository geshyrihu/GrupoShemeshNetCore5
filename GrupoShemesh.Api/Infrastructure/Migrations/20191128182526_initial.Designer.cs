﻿// <auto-generated />
using System;
using GrupoShemesh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Administration.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191128182526_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Administration.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Birth");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("IdCustomer");

                    b.Property<int>("IdProfession");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PhotoPath");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdProfession");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Administration.Models.CallAdmin", b =>
                {
                    b.Property<int>("IdCallAdmin")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateRequest")
                        .IsRequired();

                    b.Property<int>("IdCustomer");

                    b.Property<int>("IdDirectoryCondominium");

                    b.Property<int>("IdEmployee");

                    b.Property<int>("IdResponsibleArea");

                    b.Property<string>("Observations");

                    b.Property<string>("RequestService")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdCallAdmin");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdDirectoryCondominium");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdResponsibleArea");

                    b.HasIndex("applicationUserId");

                    b.ToTable("CallAdmin");
                });

            modelBuilder.Entity("Administration.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("NameCotegory")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("IdCategory");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Administration.Models.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Adreess")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneOne")
                        .IsRequired();

                    b.Property<string>("PhoneTwo")
                        .IsRequired();

                    b.Property<string>("PhotoPath");

                    b.Property<string>("RFC")
                        .IsRequired();

                    b.Property<DateTime?>("Register")
                        .IsRequired();

                    b.HasKey("IdCustomer");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Administration.Models.DirectoryCondominium", b =>
                {
                    b.Property<int>("IdDirectoryCondominium")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department");

                    b.Property<int>("IdCustomer");

                    b.Property<string>("NameDirectoryCondominium");

                    b.Property<string>("Tower");

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdDirectoryCondominium");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("applicationUserId");

                    b.ToTable("DirectoryCondominium");
                });

            modelBuilder.Entity("Administration.Models.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Area");

                    b.Property<DateTime>("Birth");

                    b.Property<int>("BloodType");

                    b.Property<string>("CellPhone")
                        .IsRequired();

                    b.Property<string>("Curp")
                        .IsRequired();

                    b.Property<DateTime>("DateAdmission");

                    b.Property<DateTime>("DateCreation");

                    b.Property<int>("EducationLevel");

                    b.Property<int>("IdCustomer");

                    b.Property<int>("IdProfession");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("LocalPhone")
                        .IsRequired();

                    b.Property<int>("MaritalStatus");

                    b.Property<string>("NSS")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Nationality")
                        .IsRequired();

                    b.Property<string>("PhotoPath");

                    b.Property<string>("RFC")
                        .IsRequired();

                    b.Property<decimal>("Salary")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Sex");

                    b.Property<int>("TypeContract");

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdEmployee");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdProfession");

                    b.HasIndex("applicationUserId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Administration.Models.Machinery", b =>
                {
                    b.Property<int>("IdMachinery")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("IdCustomer");

                    b.Property<string>("NameMachinery")
                        .IsRequired();

                    b.Property<string>("Observations")
                        .HasMaxLength(255);

                    b.Property<string>("PhotoPath")
                        .IsRequired();

                    b.Property<string>("Serie");

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdMachinery");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("applicationUserId");

                    b.ToTable("Machinery");
                });

            modelBuilder.Entity("Administration.Models.Profession", b =>
                {
                    b.Property<int>("IdProfession")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("NameProfession")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdProfession");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("Administration.Models.ReportSupervision", b =>
                {
                    b.Property<int>("IdReportSupervision")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activity")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdCustomer");

                    b.Property<string>("Observations")
                        .HasMaxLength(255);

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdReportSupervision");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("applicationUserId");

                    b.ToTable("ReportSupervision");
                });

            modelBuilder.Entity("Administration.Models.Request", b =>
                {
                    b.Property<int>("IdRequest")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameRequest")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdRequest");

                    b.HasIndex("applicationUserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Administration.Models.ResponsibleArea", b =>
                {
                    b.Property<int>("IdResponsibleArea")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameArea")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdResponsibleArea");

                    b.ToTable("ResponsibleAreas");
                });

            modelBuilder.Entity("Administration.Models.Tool", b =>
                {
                    b.Property<int>("IdTool")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("IdCustomer");

                    b.Property<string>("NameTool")
                        .IsRequired();

                    b.Property<string>("Observations")
                        .HasMaxLength(255);

                    b.Property<string>("PhotoPath")
                        .IsRequired();

                    b.Property<string>("Serie");

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdTool");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("applicationUserId");

                    b.ToTable("Tool");
                });

            modelBuilder.Entity("Administration.Models.WeeklyReport", b =>
                {
                    b.Property<int>("IdWeeklyReport")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activity")
                        .IsRequired();

                    b.Property<DateTime?>("DateFinished")
                        .IsRequired();

                    b.Property<DateTime?>("DateRequest")
                        .IsRequired();

                    b.Property<int>("IdCustomer");

                    b.Property<int>("IdRequest");

                    b.Property<int>("IdResponsibleArea");

                    b.Property<string>("Observations");

                    b.Property<string>("PhotoPathAfter");

                    b.Property<string>("PhotoPathBefore");

                    b.Property<int>("Priority");

                    b.Property<int>("Status");

                    b.Property<string>("UserId");

                    b.Property<string>("applicationUserId");

                    b.HasKey("IdWeeklyReport");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdRequest");

                    b.HasIndex("IdResponsibleArea");

                    b.HasIndex("UserId");

                    b.HasIndex("applicationUserId");

                    b.ToTable("WeeklyReport");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Administration.Models.ApplicationUser", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("IdProfession")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.CallAdmin", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.DirectoryCondominium", "DirectoryCondominium")
                        .WithMany()
                        .HasForeignKey("IdDirectoryCondominium")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ResponsibleArea", "ResponsibleArea")
                        .WithMany()
                        .HasForeignKey("IdResponsibleArea")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.Category", b =>
                {
                    b.HasOne("Administration.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.DirectoryCondominium", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.Employee", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("IdProfession")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.Machinery", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.ReportSupervision", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.Request", b =>
                {
                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.Tool", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Administration.Models.WeeklyReport", b =>
                {
                    b.HasOne("Administration.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("IdRequest")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ResponsibleArea", "ResponsibleArea")
                        .WithMany()
                        .HasForeignKey("IdResponsibleArea")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Administration.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Administration.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Administration.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Administration.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
