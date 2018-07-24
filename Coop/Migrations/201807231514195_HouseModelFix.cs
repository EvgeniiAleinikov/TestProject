namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HouseModelFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "Country", c => c.String());
            AddColumn("dbo.Houses", "City", c => c.String());
            AddColumn("dbo.Houses", "Street", c => c.String());
            AddColumn("dbo.Houses", "NumberOfApartments", c => c.Int(nullable: false));
            DropColumn("dbo.Houses", "Address");
            DropColumn("dbo.Houses", "NumberOfApartment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "NumberOfApartment", c => c.Int(nullable: false));
            AddColumn("dbo.Houses", "Address", c => c.String());
            DropColumn("dbo.Houses", "NumberOfApartments");
            DropColumn("dbo.Houses", "Street");
            DropColumn("dbo.Houses", "City");
            DropColumn("dbo.Houses", "Country");
        }
    }
}
