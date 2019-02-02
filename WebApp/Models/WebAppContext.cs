using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApp.Models
{

    public class WebAppContext : DbContext
    {
        public WebAppContext()
            : base("WebAppContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebAppContext, WebApp.Migrations.Configuration>());

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

        public System.Data.Entity.DbSet<WebApp.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.PurchaseInvoiceMaster> PurchaseInvoicemasters { get; set; }
        public System.Data.Entity.DbSet<WebApp.Models.PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        
    }
}