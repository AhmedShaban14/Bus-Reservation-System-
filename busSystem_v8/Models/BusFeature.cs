using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class BusFeature
    {
        [Key]
        public int ID { get; set; }
        public bool wifi { get; set; }
        public bool Food { get; set; }
        public bool Drinks { get; set; }

        public bool Wc { get; set; }
        public bool TV { get; set; }
        public bool AirConditioner { get; set; }

        public virtual IEnumerable<BusFeautersRelation> BusFeautersRelations { get; set; }

    }
}