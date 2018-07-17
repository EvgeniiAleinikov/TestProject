namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixManagerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "ManagerId", "dbo.Managers");
            DropIndex("dbo.Companies", new[] { "ManagerId" });
            AlterColumn("dbo.Companies", "ManagerId", c => c.Int());
            CreateIndex("dbo.Companies", "ManagerId");
            AddForeignKey("dbo.Companies", "ManagerId", "dbo.Managers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ManagerId", "dbo.Managers");
            DropIndex("dbo.Companies", new[] { "ManagerId" });
            AlterColumn("dbo.Companies", "ManagerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "ManagerId");
            AddForeignKey("dbo.Companies", "ManagerId", "dbo.Managers", "Id", cascadeDelete: true);
        }
    }
}
