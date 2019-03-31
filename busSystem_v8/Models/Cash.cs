using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Cash
    {
        [Key]
        public int Id { get; set; }
        public decimal CashMoney { get; set; }

       
    }
}