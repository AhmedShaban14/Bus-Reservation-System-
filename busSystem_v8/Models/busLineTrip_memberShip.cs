using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class busLineTrip_memberShip
    {
        public Line line { get; set; }
        public Bus bus { get; set; }
        public Trip trip { get; set; }
        public IEnumerable<Day> day { get; set; }
    }
}