namespace WebApp.Migrations
{
    using System.Data.Entity.Migrations;
    using WebApp.Models.DBModels;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Models.WebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebApp.Models.WebAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            //context.Stores.AddOrUpdate(p => p.StoreID,
            //    new Store { StoreID = 1, StoreName = "NPCC", Isactive = true }

            //    );

            //context.Users.AddOrUpdate(p => p.UserID,
            //  new User { UserID = 1, UserName = "Admin", Password = "Admin", StoreID = 1, IsDeleted = false }

            //  );


            context.PaymentModeMasters.AddOrUpdate(
              p => p.PaymentModeID,
              new PaymentModeMaster { PaymentModeID = 1, PaymentMode = "Cash" },
              new PaymentModeMaster { PaymentModeID = 2, PaymentMode = "Card" },
              new PaymentModeMaster { PaymentModeID = 3, PaymentMode = "Bank Transfer" },
               new PaymentModeMaster { PaymentModeID = 4, PaymentMode = "Cheque" },
                new PaymentModeMaster { PaymentModeID = 5, PaymentMode = "Credit" }
            );

        }
    }
}