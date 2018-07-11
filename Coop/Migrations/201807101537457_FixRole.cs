namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRole : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Roles", name: "UserProfile_Id", newName: "UserProfileId");
            RenameIndex(table: "dbo.Roles", name: "IX_UserProfile_Id", newName: "IX_UserProfileId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Roles", name: "IX_UserProfileId", newName: "IX_UserProfile_Id");
            RenameColumn(table: "dbo.Roles", name: "UserProfileId", newName: "UserProfile_Id");
        }
    }
}
