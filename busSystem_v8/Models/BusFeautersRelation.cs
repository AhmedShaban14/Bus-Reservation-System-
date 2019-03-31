using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class BusFeautersRelation
    {
        ///************************************* Bus foreinKey **********************************************************
        [Key]
        [Column(Order =1)]
        public int Bus_Id { get; set; }

        [ForeignKey("Bus_Id")]
        public virtual Bus Buses { get; set; }


        ///************************************* BusFeatures foreinKey **********************************************************
        [Key]
        [Column(Order = 2)]
        public int BusFeatures_Id { get; set; }

        [ForeignKey("BusFeatures_Id")]
        public virtual BusFeature BusFeatures { get; set; }


    }
}