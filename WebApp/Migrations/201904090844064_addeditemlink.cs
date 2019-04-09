namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeditemlink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemNames", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemNames", "CategoryId");
            AddForeignKey("dbo.ItemNames", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemNames", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ItemNames", new[] { "CategoryId" });
            DropColumn("dbo.ItemNames", "CategoryId");
        }
    }
}
