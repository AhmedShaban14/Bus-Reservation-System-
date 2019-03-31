using busSystem_v8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace busSystem_v8.ViewModel
{
    public class Trip_line_Day_View_Model
    {
        public Trip tr { get; set; }
        public IEnumerable<Line> lin { get; set; }

        public IEnumerable<Day> dy { get; set; }
        public IEnumerable<Bus> buslist { get; set; }
        public Bus bus { get; set; }



        //public string fron_to { get; set; }
    }
}