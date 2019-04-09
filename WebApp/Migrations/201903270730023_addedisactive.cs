namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addedisactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseItems", "Isactive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Categories", "Isactive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ItemNames", "Isactive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "Isactive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Stores", "Isactive", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Stores", "Isactive", c => c.Boolean());
            AlterColumn("dbo.Customers", "Isactive", c => c.Boolean());
            AlterColumn("dbo.ItemNames", "Isactive", c => c.Boolean());
            AlterColumn("dbo.Categories", "Isactive", c => c.Boolean());
            DropColumn("dbo.ExpenseItems", "Isactive");
        }
    }
}
