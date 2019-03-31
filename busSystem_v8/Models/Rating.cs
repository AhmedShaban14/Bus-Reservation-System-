using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Rating
    {
        [Key]
        public int RaingID { get; set; }
        public int NumOfStars { get; set; }
        ///************************************* user foreinKey **********************************************************
        public int? user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User user_ids { get; set; }
        ///************************************* Bus foreinKey **********************************************************
        public int? bus_id { get; set; }

        [ForeignKey("bus_id")]
        public virtual Bus bus_ids { get; set; }
        ///************************************* Lines foreinKey **********************************************************
        public int? lines_id { get; set; }

        [ForeignKey("lines_id")]
        public virtual Line lines_ids { get; set; }

    }
}