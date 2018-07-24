namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Roles", new[] { "UserProfileId" });
            AlterColumn("dbo.Roles", "UserProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Roles", "UserProfileId");
            AddForeignKey("dbo.Roles", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Roles", new[] { "UserProfileId" });
            AlterColumn("dbo.Roles", "UserProfileId", c => c.Int());
            CreateIndex("dbo.Roles", "UserProfileId");
            AddForeignKey("dbo.Roles", "UserProfileId", "dbo.UserProfiles", "Id");
        }
    }
}
