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
                .ForeignKey("dbo.Managers", t => t.ManagerId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Hauses",
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurName = c.String(),
                        FirstName = c.String(),
                        Patronymic = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.Hauses", t => t.HouseId)
                .ForeignKey("dbo.Roomers", t => t.RoomerId)
                .ForeignKey("dbo.Workers", t => t.WorkerId)
                .Index(t => t.HouseId)
                .Index(t => t.RoomerId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Roomers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        House_Id = c.Int(),
                        HouseRoomerId = c.Int(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Hauses", t => t.House_Id)
                .Index(t => t.Id)
                .Index(t => t.House_Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        House_Id = c.Int(),
                        HouseWorkerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Hauses", t => t.House_Id)
                .Index(t => t.Id)
                .Index(t => t.House_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "House_Id", "dbo.Hauses");
            DropForeignKey("dbo.Workers", "Id", "dbo.Users");
            DropForeignKey("dbo.Roomers", "House_Id", "dbo.Hauses");
            DropForeignKey("dbo.Roomers", "Id", "dbo.Users");
            DropForeignKey("dbo.Managers", "Id", "dbo.Users");
            DropForeignKey("dbo.Companies", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Tasks", "RoomerId", "dbo.Roomers");
            DropForeignKey("dbo.Tasks", "HouseId", "dbo.Hauses");
            DropForeignKey("dbo.Hauses", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Workers", new[] { "House_Id" });
            DropIndex("dbo.Workers", new[] { "Id" });
            DropIndex("dbo.Roomers", new[] { "House_Id" });
            DropIndex("dbo.Roomers", new[] { "Id" });
            DropIndex("dbo.Managers", new[] { "Id" });
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            DropIndex("dbo.Tasks", new[] { "RoomerId" });
            DropIndex("dbo.Tasks", new[] { "HouseId" });
            DropIndex("dbo.Hauses", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "ManagerId" });
            DropTable("dbo.Workers");
            DropTable("dbo.Roomers");
            DropTable("dbo.Managers");
            DropTable("dbo.Tasks");
            DropTable("dbo.Users");
            DropTable("dbo.Hauses");
            DropTable("dbo.Companies");
        }
    }
}
