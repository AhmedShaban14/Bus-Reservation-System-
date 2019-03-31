using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Bus
    {
        [Key]
        public int BusID { get; set; }
        public int BusNumber { get; set; }
        public string DriverName { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public int NumOfSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int NumOfBags { get; set; }
        public string Color { get; set; }

        ///********************************* Bus  has many Booking   B (1-m) B  *************************************************************

        public IEnumerable<Booking> Bookings { get; set; }


        ///********************************* Bus  has many BusFeautersRelation   B (1-m) BFR  *************************************************************

        public IEnumerable<BusFeautersRelation> BusFeautersRelations { get; set; }


        ///********************************* Bus  has many BusFeauters  B (1-m) BF *************************************************************

        public IEnumerable<BusFeature> BusFeauters { get; set; }

        ///********************************* Bus  has one trip *************************************************************
        public int? trip_id{ get; set; }
        [ForeignKey("trip_id")]
        public virtual Trip Trip { get; set; }

    }
}