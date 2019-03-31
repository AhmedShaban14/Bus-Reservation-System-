using busSystem_v8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.View_Models
{
    public class UserBooking
    {

        public Booking books { get; set; }

        public User user { get; set; }

        public IEnumerable<Line> lines { get; set; }

        public IEnumerable<Trip> trips { get; set; }

        public IEnumerable<Bus> buses { get; set; }

        public IEnumerable<Payment_Type> payment_Types { get; set; }

    }
}