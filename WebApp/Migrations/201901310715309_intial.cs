namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Color = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Manufacturer = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SerialNum = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonTaxCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitSP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        DiscountForLocation = c.Decimal(precision: 18, scale: 2),
                        MinimumSPForLocation = c.Decimal(precision: 18, scale: 2),
                        Taxamount = c.Decimal(precision: 18, scale: 2),
                        CGSTpercent = c.Decimal(precision: 18, scale: 2),
                        SGSTPercent = c.Decimal(precision: 18, scale: 2),
                        Color = c.String(),
                        Image = c.String(),
                        IsAvailable = c.Boolean(),
                        Isactive = c.Boolean(),
                        IsRateChangable = c.Boolean(),
                        IsTodaySpecial = c.Boolean(),
                        DeliveredQty = c.Int(),
                        IsDelivered = c.Boolean(),
                        PurchaseInvoiceDetailID = c.Int(),
                        ItemNameId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.ItemNames", t => t.ItemNameId)
                .Index(t => t.CategoryId)
                .Index(t => t.ItemNameId);
            
            CreateTable(
                "dbo.ItemNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemDesc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ItemNameId", "dbo.ItemNames");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ItemNameId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.ItemNames");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
