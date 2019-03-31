using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Line
    {
        [Key]
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int NumOfBuses { get; set; }
        public int NumOfHours { get; set; }


        ///********************************* Line  has many Booking   L (1-m) B  *************************************************************

        public IEnumerable<Booking> Bookings { get; set; }



        ///********************************* PaymentTypes  has many Trips  L (1-m) B  *************************************************************
        public IEnumerable<Trip> trips { get; set; }
    }

}