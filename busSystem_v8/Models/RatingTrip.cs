using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class RatingTrip
    {
        [Key]
        public int NumOfStars { get; set; }
        public string Description { get; set; }
        ///************************************* user  foreinKey **********************************************************
        public int userID { get; set; }

        [ForeignKey("userID")]
        public virtual User users { get; set; }
        ///************************************* Bus  foreinKey **********************************************************
        public int BusID { get; set; }

        [ForeignKey("BusID")]
        public virtual Bus buses { get; set; }

        ///************************************* Line  foreinKey **********************************************************
        public int LineID { get; set; }

        [ForeignKey("LineID")]
        public virtual Line lines { get; set; }

    }
}