namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                        StoreAddress = c.String(),
                        Street = c.String(),
                        Phone = c.String(),
                        StoreTaxId = c.String(),
                    })
                .PrimaryKey(t => t.StoreID);
            
            AddColumn("dbo.Products", "StoreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "StoreID");
            AddForeignKey("dbo.Products", "StoreID", "dbo.Stores", "StoreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "StoreID", "dbo.Stores");
            DropIndex("dbo.Products", new[] { "StoreID" });
            DropColumn("dbo.Products", "StoreID");
            DropTable("dbo.Stores");
        }
    }
}
