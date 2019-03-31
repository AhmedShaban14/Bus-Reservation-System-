using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Notification_Type
    {
        [Key]
        public int NotifyTypeID { get; set; }
      
        public string Notify_type { get; set; }

        ///********************************* Notification_Type  has many notyfications   N_T (1-m) N  *************************************************************
        public IEnumerable<Notification_content> notifies { get; set; }
    }
}