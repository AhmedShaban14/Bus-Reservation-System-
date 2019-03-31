using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Payment_Type
    {
        [Key]
        public int ID { get; set; }
        public string pay_type { get; set; }

        ///********************************* PaymentTypes  has many Booking   P_T (1-m) B  *************************************************************
        public IEnumerable<Booking> Bookings { get; set; }

        // we will get an object from cash or creadit class so we can insert ID of payment processing in booking table 

        
    }
}