namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addedpurchase : DbMigration
    {
        public override void Up()
        {
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
                "dbo.PurchaseInvoicemasters",
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
                "dbo.PurchaseInvoiceDetails",
                c => new
                    {
                        PurchaseInvoiceDetailID = c.Int(nullable: false, identity: true),
                        PurchaseInvoicemasterID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
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
                .ForeignKey("dbo.PurchaseInvoicemasters", t => t.PurchaseInvoicemasterID)
                .Index(t => t.PurchaseInvoicemasterID)
                .Index(t => t.CategoryID);

            CreateIndex("dbo.Products", "PurchaseInvoiceDetailID");
            AddForeignKey("dbo.Products", "PurchaseInvoiceDetailID", "dbo.PurchaseInvoiceDetails", "PurchaseInvoiceDetailID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.PurchaseInvoicemasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.PurchaseInvoiceDetails", "PurchaseInvoicemasterID", "dbo.PurchaseInvoicemasters");
            DropForeignKey("dbo.Products", "PurchaseInvoiceDetailID", "dbo.PurchaseInvoiceDetails");
            DropForeignKey("dbo.PurchaseInvoiceDetails", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.PurchaseInvoicemasters", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "StoreID", "dbo.Stores");
            DropIndex("dbo.PurchaseInvoiceDetails", new[] { "CategoryID" });
            DropIndex("dbo.PurchaseInvoiceDetails", new[] { "PurchaseInvoicemasterID" });
            DropIndex("dbo.PurchaseInvoicemasters", new[] { "CustomerID" });
            DropIndex("dbo.PurchaseInvoicemasters", new[] { "StoreID" });
            DropIndex("dbo.Customers", new[] { "StoreID" });
            DropIndex("dbo.Products", new[] { "PurchaseInvoiceDetailID" });
            DropTable("dbo.PurchaseInvoiceDetails");
            DropTable("dbo.PurchaseInvoicemasters");
            DropTable("dbo.Customers");
        }
    }
}
