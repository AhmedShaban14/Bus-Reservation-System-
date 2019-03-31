using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class User_Status
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusType { get; set; }
    }
}