using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace busSystem_v8.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        ///************************************* user type foreinKey **********************************************************

        public int user_types_id { get; set; }

        [ForeignKey("user_types_id")]
        public virtual User_Type user_types { get; set; }


        ///********************************* Admin  has many Notyfications   A (1-m) N  *************************************************************
        public IEnumerable<Notification_content> notifies { get; set; }

        ///********************************* Admin  has many Report   A (1-m) R  *************************************************************
        public IEnumerable<Report> reports { get; set; }




    }
}