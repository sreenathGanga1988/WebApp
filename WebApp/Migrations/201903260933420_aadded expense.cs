namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaddedexpense : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseDetails",
                c => new
                    {
                        ExpenseDetailID = c.Int(nullable: false, identity: true),
                        ExpenseItemID = c.Int(nullable: false),
                        ExpenseDetailRemark = c.String(nullable: false, maxLength: 450),
                        ExpenseDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(),
                        AddedUser = c.String(),
                        Deleteddate = c.DateTime(),
                        DeletedUser = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedUser = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseDetailID)
                .ForeignKey("dbo.ExpenseItems", t => t.ExpenseItemID)
                .Index(t => t.ExpenseItemID);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        ExpenseItemID = c.Int(nullable: false, identity: true),
                        ExpenseItemName = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => t.ExpenseItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDetails", "ExpenseItemID", "dbo.ExpenseItems");
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseItemID" });
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseDetails");
        }
    }
}
