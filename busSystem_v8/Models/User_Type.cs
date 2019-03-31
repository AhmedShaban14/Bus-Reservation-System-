using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace busSystem_v8.Models
{
    public class User_Type
    {
        [Key]
        public int User_type_ID { get; set; }
        public string type { get; set; }

        ///********************************* User type  has many Admins   U_T (1-m) A  ****************************
        public IEnumerable<Admin> admins { get; set; }
        ///********************************* User type  has many Users   U_T (1-m) U  ***************************
        public IEnumerable<User> users { get; set; }

    }
}