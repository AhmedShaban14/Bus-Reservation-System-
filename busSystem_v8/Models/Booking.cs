using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Booking
    {
        [Key]
        public int BokkingID { get; set; }
        public int chosenChairs { get; set; }
        public decimal TotalCost { get; set; }

        ///************************************* User foreinKey **********************************************************
        public int User_id { get; set; }

        [ForeignKey("User_id")]
        public virtual User users { get; set; }


        ///************************************* Line foreinKey **********************************************************
        public int Line_Id { get; set; }

        [ForeignKey("Line_Id")]
        public virtual Line lines { get; set; }



        ///************************************* Trip foreinKey **********************************************************
        public int Trip_ID { get; set; }

        [ForeignKey("Trip_ID")]
        public virtual Trip trips { get; set; }


        ///************************************* Bus foreinKey **********************************************************
        public int Bus_Id { get; set; }

        [ForeignKey("Bus_Id")]
        public virtual Bus Buses { get; set; }


        ///************************************* PaymentTypes foreinKey **********************************************************
        public int Payment_Type_Id { get; set; }

        [ForeignKey("Payment_Type_Id")]
        public virtual Payment_Type payment_types { get; set; }



    }
}