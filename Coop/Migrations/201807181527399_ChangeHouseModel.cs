namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeHouseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "NumberOfApartment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Houses", "NumberOfApartment");
        }
    }
}
