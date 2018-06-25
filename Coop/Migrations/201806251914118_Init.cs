namespace Coop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
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
                "dbo.Roomers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HouseRoomerId = c.Int(),
                        Number = c.Int(nullable: false),
                        House_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.House_Id)
                .ForeignKey("dbo.UserProfiles", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.House_Id);
            
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
                .ForeignKey("dbo.Roomers", t => t.RoomerId)
                .ForeignKey("dbo.Workers", t => t.WorkerId)
                .Index(t => t.HouseId)
                .Index(t => t.RoomerId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HouseWorkerId = c.Int(),
                        House_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.House_Id)
                .ForeignKey("dbo.UserProfiles", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.House_Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roomers", "Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Workers", "Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Managers", "Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Companies", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Workers", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.Tasks", "RoomerId", "dbo.Roomers");
            DropForeignKey("dbo.Tasks", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.Roomers", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.Houses", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Managers", new[] { "Id" });
            DropIndex("dbo.Workers", new[] { "House_Id" });
            DropIndex("dbo.Workers", new[] { "Id" });
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            DropIndex("dbo.Tasks", new[] { "RoomerId" });
            DropIndex("dbo.Tasks", new[] { "HouseId" });
            DropIndex("dbo.Roomers", new[] { "House_Id" });
            DropIndex("dbo.Roomers", new[] { "Id" });
            DropIndex("dbo.Houses", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "ManagerId" });
            DropTable("dbo.Managers");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Workers");
            DropTable("dbo.Tasks");
            DropTable("dbo.Roomers");
            DropTable("dbo.Houses");
            DropTable("dbo.Companies");
        }
    }
}
