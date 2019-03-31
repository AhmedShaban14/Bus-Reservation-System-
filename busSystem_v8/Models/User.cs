using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
      //  public string Gender { get; set; }
        public string Job { get; set; }
        public int Ssn { get; set; }
        public int Age { get; set; }
        public decimal wallet { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImgPath { get; set; }

        ///************************************* user type foreinKey **********************************************************
        public int? user_types_id { get; set; }

        [ForeignKey("user_types_id")]
        public virtual User_Type user_types { get; set; }
        ///************************************* user Status foreinKey **********************************************************
        public int? user_status_id { get; set; }

        [ForeignKey("user_status_id")]
        public virtual User_Status user_status { get; set; }
        ///************************************* user bus foreinKey **********************************************************
        public int? bus_id { get; set; }

        [ForeignKey("bus_id")]
        public virtual Bus bus { get; set; }

        ///********************************* user  has many notyfications   U (1-m) N  *************************************************************
        public IEnumerable<Notification_content> notifies { get; set; }

        ///********************************* user  has many Booking   U (1-m) B  *************************************************************
        public IEnumerable<Booking> bookings { get; set; }

    }
}