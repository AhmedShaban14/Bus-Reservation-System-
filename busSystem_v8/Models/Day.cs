using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Day
    {
        [Key]
        public int DayID { get; set; }
        public string DayName { get; set; }


        ///********************************* Days  has many Trips   D (1-m) T  *************************************************************
        public IEnumerable<Trip> trips { get; set; }


    }
}