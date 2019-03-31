using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class BusSystemDB : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<User_Type> user_type { get; set; }
        public DbSet<Line> lines { get; set; }
        public DbSet<Day> days { get; set; }
        public DbSet<Trip> trip { get; set; }
        public DbSet<Bus> buses { get; set; }
        public DbSet<BusFeature> busFeatures { get; set; }
        public DbSet<BusFeautersRelation> busFeautersRelations { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<Notification_Type> notification_type { get; set; }
        public DbSet<Notification_content> notification_content { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<Cash> cash { get; set; }
        public DbSet<Credit> credit { get; set; }
        public DbSet<Payment_Type> payment_Type { get; set; }

        public BusSystemDB():base("DbBusSystemConnection")
        {

        }

        public System.Data.Entity.DbSet<busSystem_v8.Models.User_Status> User_Status { get; set; }
    }
}