namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialadd : DbMigration
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
                        Isactive = c.Boolean(),
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
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.ItemNames", t => t.ItemNameId)
                .ForeignKey("dbo.PurchaseInvoiceDetails", t => t.PurchaseInvoiceDetailID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.CategoryId)
                .Index(t => t.PurchaseInvoiceDetailID)
                .Index(t => t.ItemNameId)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.ItemNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemDesc = c.String(),
                        Isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseInvoiceDetails",
                c => new
                    {
                        PurchaseInvoiceDetailID = c.Int(nullable: false, identity: true),
                        PurchaseInvoicemasterID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ItemNameId = c.Int(),
                        ProductName = c.String(),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SerialNum = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonTaxCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitSP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CGSTPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SGSTPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitCGSTCP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitSGSTSP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseInvoiceDetailID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.ItemNames", t => t.ItemNameId)
                .ForeignKey("dbo.PurchaseInvoiceMasters", t => t.PurchaseInvoicemasterID)
                .Index(t => t.PurchaseInvoicemasterID)
                .Index(t => t.CategoryID)
                .Index(t => t.ItemNameId);
            
            CreateTable(
                "dbo.PurchaseInvoiceMasters",
                c => new
                    {
                        PurchaseInvoicemasterID = c.Int(nullable: false, identity: true),
                        PurchaseInvoiceNum = c.String(),
                        StoreID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        TotalPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoundOffAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsCommited = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PurchaseInvoicemasterID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        CustomerDetails = c.String(),
                        BarcodeNum = c.String(),
                        PaymentDue = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        StoreID = c.Int(nullable: false),
                        AddedBy = c.String(),
                        AddedDate = c.String(),
                        Isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
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
                        Isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseInvoiceMasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.PurchaseInvoiceDetails", "PurchaseInvoicemasterID", "dbo.PurchaseInvoiceMasters");
            DropForeignKey("dbo.PurchaseInvoiceMasters", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Products", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Products", "PurchaseInvoiceDetailID", "dbo.PurchaseInvoiceDetails");
            DropForeignKey("dbo.PurchaseInvoiceDetails", "ItemNameId", "dbo.ItemNames");
            DropForeignKey("dbo.PurchaseInvoiceDetails", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "ItemNameId", "dbo.ItemNames");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Customers", new[] { "StoreID" });
            DropIndex("dbo.PurchaseInvoiceMasters", new[] { "CustomerID" });
            DropIndex("dbo.PurchaseInvoiceMasters", new[] { "StoreID" });
            DropIndex("dbo.PurchaseInvoiceDetails", new[] { "ItemNameId" });
            DropIndex("dbo.PurchaseInvoiceDetails", new[] { "CategoryID" });
            DropIndex("dbo.PurchaseInvoiceDetails", new[] { "PurchaseInvoicemasterID" });
            DropIndex("dbo.Products", new[] { "StoreID" });
            DropIndex("dbo.Products", new[] { "ItemNameId" });
            DropIndex("dbo.Products", new[] { "PurchaseInvoiceDetailID" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Customers");
            DropTable("dbo.PurchaseInvoiceMasters");
            DropTable("dbo.PurchaseInvoiceDetails");
            DropTable("dbo.ItemNames");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
