namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Votings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Votes = c.Int(nullable: false),
                        RoomerId = c.Int(),
                        VotingId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roomers", t => t.RoomerId)
                .ForeignKey("dbo.Votings", t => t.VotingId)
                .Index(t => t.RoomerId)
                .Index(t => t.VotingId);
            
            CreateTable(
                "dbo.Votings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalVotes = c.Int(nullable: false),
                        HouseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.HouseId)
                .Index(t => t.HouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votings", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.Answers", "VotingId", "dbo.Votings");
            DropForeignKey("dbo.Answers", "RoomerId", "dbo.Roomers");
            DropIndex("dbo.Votings", new[] { "HouseId" });
            DropIndex("dbo.Answers", new[] { "VotingId" });
            DropIndex("dbo.Answers", new[] { "RoomerId" });
            DropTable("dbo.Votings");
            DropTable("dbo.Answers");
        }
    }
}
