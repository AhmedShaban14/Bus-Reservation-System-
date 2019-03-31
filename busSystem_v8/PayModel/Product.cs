using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busSystem_v8.PayModel
{
    public class Product
    {
        [Required(ErrorMessage = "required")]
        [RegularExpression("\\d+", ErrorMessage = "more")]
        [Range(1000, 2000, ErrorMessage = "ID must be from 1000-2000")]
        public int item_number { get; set; }

        [Required(ErrorMessage = "required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "between 5 to 100")]
        public string item_name { get; set; }

        [Required(ErrorMessage = "required")]
        [Range(1.0, 100.0, ErrorMessage = "amount from 1-100 USD")]
        public double amount { get; set; }
        /*
        [Required(ErrorMessage = "required")]
        [RegularExpression("\\d+", ErrorMessage = "more")]
        [Range(1, 100, ErrorMessage = "quantity must be  1-100")]
        public int quantity { get; set; }
        */
    }
}
