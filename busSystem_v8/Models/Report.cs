using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Report
    {
        [Key]
        public int ReporID { get; set; }
        public DateTime ReporDate { get; set; }
        public string ReportPath { get; set; }
        ///************************************* Admin foreinKey **********************************************************
        public int Admin_id { get; set; }

        [ForeignKey("Admin_id")]
        public virtual Admin admins { get; set; }

    }
}