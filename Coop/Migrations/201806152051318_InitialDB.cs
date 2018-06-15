namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        HouseNumber = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurName = c.String(),
                        FirstName = c.String(),
                        Patronymic = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Role = c.String(),
                        Password = c.String(),
                        HouseRoomerId = c.Int(),
                        Number = c.Int(),
                        HouseWorkerId = c.Int(),
                        DOB = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        House_Id = c.Int(),
                        House_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.House_Id)
                .ForeignKey("dbo.Houses", t => t.House_Id1)
                .Index(t => t.House_Id)
                .Index(t => t.House_Id1);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(),
                        RoomerId = c.Int(),
                        WorkerId = c.Int(),
                        Description = c.String(),
                        TaskDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.HouseId)
                .ForeignKey("dbo.UserProfiles", t => t.RoomerId)
                .ForeignKey("dbo.UserProfiles", t => t.WorkerId)
                .Index(t => t.HouseId)
                .Index(t => t.RoomerId)
                .Index(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ManagerId", "dbo.UserProfiles");
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "House_Id1", "dbo.Houses");
            DropForeignKey("dbo.Tasks", "RoomerId", "dbo.UserProfiles");
            DropForeignKey("dbo.Tasks", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.UserProfiles", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.Houses", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            DropIndex("dbo.Tasks", new[] { "RoomerId" });
            DropIndex("dbo.Tasks", new[] { "HouseId" });
            DropIndex("dbo.UserProfiles", new[] { "House_Id1" });
            DropIndex("dbo.UserProfiles", new[] { "House_Id" });
            DropIndex("dbo.Houses", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "ManagerId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Houses");
            DropTable("dbo.Companies");
        }
    }
}
