namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Profession", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Profession");
        }
    }
}
