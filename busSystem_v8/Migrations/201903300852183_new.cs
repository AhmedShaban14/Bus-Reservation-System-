namespace busSystem_v8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        user_types_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID)
                .ForeignKey("dbo.User_Type", t => t.user_types_id, cascadeDelete: true)
                .Index(t => t.user_types_id);
            
            CreateTable(
                "dbo.User_Type",
                c => new
                    {
                        User_type_ID = c.Int(nullable: false, identity: true),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.User_type_ID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BokkingID = c.Int(nullable: false, identity: true),
                        chosenChairs = c.Int(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_id = c.Int(nullable: false),
                        Line_Id = c.Int(nullable: false),
                        Trip_ID = c.Int(nullable: false),
                        Bus_Id = c.Int(nullable: false),
                        Payment_Type_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BokkingID)
                .ForeignKey("dbo.Buses", t => t.Bus_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lines", t => t.Line_Id, cascadeDelete: true)
                .ForeignKey("dbo.Payment_Type", t => t.Payment_Type_Id, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.Trip_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id)
                .Index(t => t.Line_Id)
                .Index(t => t.Trip_ID)
                .Index(t => t.Bus_Id)
                .Index(t => t.Payment_Type_Id);
            
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        BusID = c.Int(nullable: false, identity: true),
                        BusNumber = c.Int(nullable: false),
                        DriverName = c.String(),
                        CompanyName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumOfSeats = c.Int(nullable: false),
                        AvailableSeats = c.Int(nullable: false),
                        NumOfBags = c.Int(nullable: false),
                        Color = c.String(),
                        trip_id = c.Int(),
                    })
                .PrimaryKey(t => t.BusID)
                .ForeignKey("dbo.Trips", t => t.trip_id)
                .Index(t => t.trip_id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        tripCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lines_Id = c.Int(),
                        Dayes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.Dayes_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lines", t => t.Lines_Id)
                .Index(t => t.Lines_Id)
                .Index(t => t.Dayes_Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayID = c.Int(nullable: false, identity: true),
                        DayName = c.String(),
                    })
                .PrimaryKey(t => t.DayID);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                        NumOfBuses = c.Int(nullable: false),
                        NumOfHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payment_Type",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        pay_type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Job = c.String(),
                        Ssn = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        wallet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BirthDate = c.DateTime(nullable: false),
                        ImgPath = c.String(),
                        user_types_id = c.Int(),
                        user_status_id = c.Int(),
                        bus_id = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Buses", t => t.bus_id)
                .ForeignKey("dbo.User_Status", t => t.user_status_id)
                .ForeignKey("dbo.User_Type", t => t.user_types_id)
                .Index(t => t.user_types_id)
                .Index(t => t.user_status_id)
                .Index(t => t.bus_id);
            
            CreateTable(
                "dbo.User_Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusType = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.BusFeatures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        wifi = c.Boolean(nullable: false),
                        Food = c.Boolean(nullable: false),
                        Drinks = c.Boolean(nullable: false),
                        Wc = c.Boolean(nullable: false),
                        TV = c.Boolean(nullable: false),
                        AirConditioner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusFeautersRelations",
                c => new
                    {
                        Bus_Id = c.Int(nullable: false),
                        BusFeatures_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bus_Id, t.BusFeatures_Id })
                .ForeignKey("dbo.Buses", t => t.Bus_Id, cascadeDelete: true)
                .ForeignKey("dbo.BusFeatures", t => t.BusFeatures_Id, cascadeDelete: true)
                .Index(t => t.Bus_Id)
                .Index(t => t.BusFeatures_Id);
            
            CreateTable(
                "dbo.Cashes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notification_content",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Notification_Type = c.Int(nullable: false),
                        Admin_Id = c.Int(nullable: false),
                        User_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Admins", t => t.Admin_Id, cascadeDelete: true)
                .ForeignKey("dbo.Notification_Type", t => t.Notification_Type, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.Notification_Type)
                .Index(t => t.Admin_Id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Notification_Type",
                c => new
                    {
                        NotifyTypeID = c.Int(nullable: false, identity: true),
                        Notify_type = c.String(),
                    })
                .PrimaryKey(t => t.NotifyTypeID);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReporID = c.Int(nullable: false, identity: true),
                        ReporDate = c.DateTime(nullable: false),
                        ReportPath = c.String(),
                        Admin_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReporID)
                .ForeignKey("dbo.Admins", t => t.Admin_id, cascadeDelete: true)
                .Index(t => t.Admin_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "Admin_id", "dbo.Admins");
            DropForeignKey("dbo.Notification_content", "User_id", "dbo.Users");
            DropForeignKey("dbo.Notification_content", "Notification_Type", "dbo.Notification_Type");
            DropForeignKey("dbo.Notification_content", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.BusFeautersRelations", "BusFeatures_Id", "dbo.BusFeatures");
            DropForeignKey("dbo.BusFeautersRelations", "Bus_Id", "dbo.Buses");
            DropForeignKey("dbo.Bookings", "User_id", "dbo.Users");
            DropForeignKey("dbo.Users", "user_types_id", "dbo.User_Type");
            DropForeignKey("dbo.Users", "user_status_id", "dbo.User_Status");
            DropForeignKey("dbo.Users", "bus_id", "dbo.Buses");
            DropForeignKey("dbo.Bookings", "Trip_ID", "dbo.Trips");
            DropForeignKey("dbo.Bookings", "Payment_Type_Id", "dbo.Payment_Type");
            DropForeignKey("dbo.Bookings", "Line_Id", "dbo.Lines");
            DropForeignKey("dbo.Bookings", "Bus_Id", "dbo.Buses");
            DropForeignKey("dbo.Buses", "trip_id", "dbo.Trips");
            DropForeignKey("dbo.Trips", "Lines_Id", "dbo.Lines");
            DropForeignKey("dbo.Trips", "Dayes_Id", "dbo.Days");
            DropForeignKey("dbo.Admins", "user_types_id", "dbo.User_Type");
            DropIndex("dbo.Reports", new[] { "Admin_id" });
            DropIndex("dbo.Notification_content", new[] { "User_id" });
            DropIndex("dbo.Notification_content", new[] { "Admin_Id" });
            DropIndex("dbo.Notification_content", new[] { "Notification_Type" });
            DropIndex("dbo.BusFeautersRelations", new[] { "BusFeatures_Id" });
            DropIndex("dbo.BusFeautersRelations", new[] { "Bus_Id" });
            DropIndex("dbo.Users", new[] { "bus_id" });
            DropIndex("dbo.Users", new[] { "user_status_id" });
            DropIndex("dbo.Users", new[] { "user_types_id" });
            DropIndex("dbo.Trips", new[] { "Dayes_Id" });
            DropIndex("dbo.Trips", new[] { "Lines_Id" });
            DropIndex("dbo.Buses", new[] { "trip_id" });
            DropIndex("dbo.Bookings", new[] { "Payment_Type_Id" });
            DropIndex("dbo.Bookings", new[] { "Bus_Id" });
            DropIndex("dbo.Bookings", new[] { "Trip_ID" });
            DropIndex("dbo.Bookings", new[] { "Line_Id" });
            DropIndex("dbo.Bookings", new[] { "User_id" });
            DropIndex("dbo.Admins", new[] { "user_types_id" });
            DropTable("dbo.Reports");
            DropTable("dbo.Notification_Type");
            DropTable("dbo.Notification_content");
            DropTable("dbo.Credits");
            DropTable("dbo.Cashes");
            DropTable("dbo.BusFeautersRelations");
            DropTable("dbo.BusFeatures");
            DropTable("dbo.User_Status");
            DropTable("dbo.Users");
            DropTable("dbo.Payment_Type");
            DropTable("dbo.Lines");
            DropTable("dbo.Days");
            DropTable("dbo.Trips");
            DropTable("dbo.Buses");
            DropTable("dbo.Bookings");
            DropTable("dbo.User_Type");
            DropTable("dbo.Admins");
        }
    }
}
