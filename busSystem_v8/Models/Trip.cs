using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal tripCost { get; set; }
        ///********************************* Trip  has many Booking   T (1-m) B  *************************************************************

        public IEnumerable<Booking> Bookings { get; set; }



        ///************************************* Lines foreinKey **********************************************************
        public int? Lines_Id { get; set; }

        [ForeignKey("Lines_Id")]
        public virtual Line lines { get; set; }

        ///************************************* Dayes foreinKey **********************************************************
        public int Dayes_Id { get; set; }

        [ForeignKey("Dayes_Id")]
        public virtual Day days { get; set; }
    }
}