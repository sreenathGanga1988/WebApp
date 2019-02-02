namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Isactive", c => c.Boolean());
            AddColumn("dbo.ItemNames", "Isactive", c => c.Boolean());
            AddColumn("dbo.Stores", "Isactive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "Isactive");
            DropColumn("dbo.ItemNames", "Isactive");
            DropColumn("dbo.Categories", "Isactive");
        }
    }
}
