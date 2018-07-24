namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProfileModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Roomers", name: "House_Id", newName: "HouseId");
            RenameColumn(table: "dbo.Workers", name: "House_Id", newName: "HouseId");
            RenameIndex(table: "dbo.Roomers", name: "IX_House_Id", newName: "IX_HouseId");
            RenameIndex(table: "dbo.Workers", name: "IX_House_Id", newName: "IX_HouseId");
            DropColumn("dbo.Roomers", "HouseRoomerId");
            DropColumn("dbo.Workers", "HouseWorkerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "HouseWorkerId", c => c.Int());
            AddColumn("dbo.Roomers", "HouseRoomerId", c => c.Int());
            RenameIndex(table: "dbo.Workers", name: "IX_HouseId", newName: "IX_House_Id");
            RenameIndex(table: "dbo.Roomers", name: "IX_HouseId", newName: "IX_House_Id");
            RenameColumn(table: "dbo.Workers", name: "HouseId", newName: "House_Id");
            RenameColumn(table: "dbo.Roomers", name: "HouseId", newName: "House_Id");
        }
    }
}
