using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApp.Models.DBModels;

namespace WebApp.Models
{
    public class WebAppContext : DbContext
    {
        public WebAppContext()
            : base("WebAppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebAppContext, WebApp.Migrations.Configuration>());

            //Database.SetInitializer<WebAppContext>(
            //new MigrateDatabaseToLatestVersion<WebAppContext, System.Data.Entity.Migrations.Configuration>());
            //Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ItemName> ItemNames { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<PaymentModeMaster> PaymentModeMasters { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<PurchaseInvoiceMaster> PurchaseInvoicemasters { get; set; }
        public DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuotationMaster> QuotationMasters { get; set; }
        public DbSet<QuotationDetail> QuotationDetails { get; set; }
        public DbSet<InvoiceMaster> InvoiceMasters { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<LoanMaster> LoanMasters { get; set; }
        public DbSet<LoanPaymentDetail> LoanPaymentDetails { get; set; }
        public DbSet<ExpenseDetail> ExpenseDetails { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }


    }
}