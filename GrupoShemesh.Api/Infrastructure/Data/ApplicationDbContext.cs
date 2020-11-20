using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrupoShemesh.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            System.Collections.Generic.IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableForeignKey> cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            base.OnModelCreating(modelBuilder);

            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableForeignKey foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CallAdmin> CallAdmin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ContactEmployee> ContactEmployee { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DirectoryCondominium> DirectoryCondominium { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ListCondomino> ListCondomino { get; set; }
        public DbSet<Machinery> Machinery { get; set; }
        public DbSet<MaintenanceCalendar> MaintenanceCalendars { get; set; }
        public DbSet<MaintenanceOrder> MaintenanceOrders { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingDetails> MeetingDetails { get; set; }
        public DbSet<MeetingParticipants> MeetingParticipants { get; set; }
        public DbSet<MeetingPosition> MeetingPositions { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ReportSupervision> ReportSupervision { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ResponsibleArea> ResponsibleAreas { get; set; }
        public DbSet<Tool> Tool { get; set; }
        public DbSet<WeeklyReport> WeeklyReport { get; set; }


        // ... Nuevas Entidades

        public DbSet<BudgetCard> BudgetCards { get; set; }
        public DbSet<BudgetCardDetail> BudgetCardDetails { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<ComparativeChart> ComparativeCharts { get; set; }
        public DbSet<MeetingSupervision> MeetingSupervisions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOutlet> ProductOutlets { get; set; }
        public DbSet<ProductsInventory> ProductsInventories { get; set; }
        public DbSet<ProductsInventoryDetail> ProductsInventoryDetails { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestDetail> PurchaseRequestDetails { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<UseCFDI> UseCFDIs { get; set; }
        public DbSet<WayToPay> WayToPays { get; set; }



    }
}
