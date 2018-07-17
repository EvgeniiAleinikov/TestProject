namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Password");
        }
    }
}
