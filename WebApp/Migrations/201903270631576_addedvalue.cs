namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseDetails", "ExpenseValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseDetails", "ExpenseValue");
        }
    }
}
