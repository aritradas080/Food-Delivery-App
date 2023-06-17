namespace Finalv1DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AllUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        UId = c.Int(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uid = c.Int(nullable: false),
                        DId = c.Int(nullable: false),
                        Msg = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deliverymen", t => t.DId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Uid, cascadeDelete: true)
                .Index(t => t.Uid)
                .Index(t => t.DId);
            
            CreateTable(
                "dbo.Deliverymen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Rating = c.Int(nullable: false),
                        Location = c.String(),
                        DeliveryManStatus = c.String(),
                        MobileNumber = c.String(),
                        dtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DeliverymanTypes", t => t.dtId, cascadeDelete: true)
                .Index(t => t.dtId);
            
            CreateTable(
                "dbo.DeliveryLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryId = c.Int(nullable: false),
                        Time = c.DateTime(),
                        Income = c.Single(nullable: false),
                        flag = c.Boolean(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deliverymen", t => t.DeliveryId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.DeliveryId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rid = c.Int(nullable: false),
                        Uid = c.Int(nullable: false),
                        RestaurantName = c.String(),
                        lat = c.Single(nullable: false),
                        lan = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OrderStatus = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Rid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Uid, cascadeDelete: true)
                .Index(t => t.Rid)
                .Index(t => t.Uid);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pid = c.Int(nullable: false),
                        Oid = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Oid, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Pid, cascadeDelete: true)
                .Index(t => t.Pid)
                .Index(t => t.Oid);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Rid = c.Int(nullable: false),
                        Cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cuisines", t => t.Cid, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Rid, cascadeDelete: false)
                .Index(t => t.Rid)
                .Index(t => t.Cid);
            
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price_Range = c.String(),
                        Spice_Level = c.String(),
                        Time_To_Prep = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.String(),
                        Rating = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(),
                        Gender = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliverymanTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MonthlyIncomes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        month = c.String(),
                        income = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tokens = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        ExpTime = c.DateTime(),
                        UId = c.Int(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "Uid", "dbo.Users");
            DropForeignKey("dbo.Chats", "DId", "dbo.Deliverymen");
            DropForeignKey("dbo.Deliverymen", "dtId", "dbo.DeliverymanTypes");
            DropForeignKey("dbo.DeliveryLogs", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Uid", "dbo.Users");
            DropForeignKey("dbo.Orders", "Rid", "dbo.Restaurants");
            DropForeignKey("dbo.OrderDetails", "Pid", "dbo.Products");
            DropForeignKey("dbo.Products", "Rid", "dbo.Restaurants");
            DropForeignKey("dbo.Products", "Cid", "dbo.Cuisines");
            DropForeignKey("dbo.OrderDetails", "Oid", "dbo.Orders");
            DropForeignKey("dbo.DeliveryLogs", "DeliveryId", "dbo.Deliverymen");
            DropIndex("dbo.Products", new[] { "Cid" });
            DropIndex("dbo.Products", new[] { "Rid" });
            DropIndex("dbo.OrderDetails", new[] { "Oid" });
            DropIndex("dbo.OrderDetails", new[] { "Pid" });
            DropIndex("dbo.Orders", new[] { "Uid" });
            DropIndex("dbo.Orders", new[] { "Rid" });
            DropIndex("dbo.DeliveryLogs", new[] { "OrderId" });
            DropIndex("dbo.DeliveryLogs", new[] { "DeliveryId" });
            DropIndex("dbo.Deliverymen", new[] { "dtId" });
            DropIndex("dbo.Chats", new[] { "DId" });
            DropIndex("dbo.Chats", new[] { "Uid" });
            DropTable("dbo.Tokens");
            DropTable("dbo.MonthlyIncomes");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.DeliverymanTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Cuisines");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.DeliveryLogs");
            DropTable("dbo.Deliverymen");
            DropTable("dbo.Chats");
            DropTable("dbo.AllUsers");
            DropTable("dbo.Admins");
        }
    }
}
