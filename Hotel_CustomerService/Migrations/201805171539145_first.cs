namespace Hotel_CustomerService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmorItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        RoomName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Armor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armors", t => t.Armor_Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.Armor_Id);
            
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ArmorStatus = c.Int(nullable: false),
                        priceAll = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerF = c.String(nullable: false),
                        CustomerI = c.String(nullable: false),
                        CustomerLogin = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClearName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room_Clear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        ClearId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clears", t => t.ClearId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.ClearId);
            
            CreateTable(
                "dbo.StorageClears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        ClearId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clears", t => t.ClearId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.ClearId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorageClears", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StorageClears", "ClearId", "dbo.Clears");
            DropForeignKey("dbo.Room_Clear", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Room_Clear", "ClearId", "dbo.Clears");
            DropForeignKey("dbo.ArmorItems", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Armors", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ArmorItems", "Armor_Id", "dbo.Armors");
            DropIndex("dbo.StorageClears", new[] { "ClearId" });
            DropIndex("dbo.StorageClears", new[] { "StorageId" });
            DropIndex("dbo.Room_Clear", new[] { "ClearId" });
            DropIndex("dbo.Room_Clear", new[] { "RoomId" });
            DropIndex("dbo.Armors", new[] { "CustomerId" });
            DropIndex("dbo.ArmorItems", new[] { "Armor_Id" });
            DropIndex("dbo.ArmorItems", new[] { "RoomId" });
            DropTable("dbo.Storages");
            DropTable("dbo.StorageClears");
            DropTable("dbo.Room_Clear");
            DropTable("dbo.Clears");
            DropTable("dbo.Rooms");
            DropTable("dbo.Customers");
            DropTable("dbo.Armors");
            DropTable("dbo.ArmorItems");
        }
    }
}
