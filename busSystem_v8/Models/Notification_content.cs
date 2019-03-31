using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace busSystem_v8.Models
{
    public class Notification_content
    {
        [Key]
        public int NotificationID { get; set; }
        public string Description { get; set; }

        ///************************************* Notification_Type foreinKey **********************************************************
        public int Notification_Type { get; set; }

        [ForeignKey("Notification_Type")]
        public virtual Notification_Type notification_types { get; set; }


        ///************************************* Admin foreinKey **********************************************************
        public int Admin_Id { get; set; }

        [ForeignKey("Admin_Id")]
        public virtual Admin admin_ids { get; set; }

        ///************************************* User foreinKey **********************************************************
        public int User_id { get; set; }

        [ForeignKey("User_id")]
        public virtual User users { get; set; }


    }
}