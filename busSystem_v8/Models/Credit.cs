using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class Credit
    {
        [Key]
        public int Id { get; set; }
        public decimal CreditMoney { get; set; }


        // ba2y el details lma n3ml seaech 



    }
}