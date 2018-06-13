namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        data = c.DateTime(nullable: false),
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
                        Password = c.String(),
                        HouseId = c.Int(),
                        Number = c.Int(),
                        HouseId1 = c.Int(),
                        DOB = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.HouseId)
                .ForeignKey("dbo.Houses", t => t.HouseId1)
                .Index(t => t.HouseId)
                .Index(t => t.HouseId1);
            
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
            DropForeignKey("dbo.UserProfiles", "HouseId1", "dbo.Houses");
            DropForeignKey("dbo.Tasks", "RoomerId", "dbo.UserProfiles");
            DropForeignKey("dbo.Tasks", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.UserProfiles", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.Houses", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Companies", new[] { "ManagerId" });
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            DropIndex("dbo.UserProfiles", new[] { "HouseId1" });
            DropIndex("dbo.Tasks", new[] { "RoomerId" });
            DropIndex("dbo.Tasks", new[] { "HouseId" });
            DropIndex("dbo.UserProfiles", new[] { "HouseId" });
            DropIndex("dbo.Houses", new[] { "CompanyId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Houses");
            DropTable("dbo.Companies");
        }
    }
}
