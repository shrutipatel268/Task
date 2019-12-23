using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Customer
    { 
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "*required*")]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        
        [Required(ErrorMessage = "*required*")]
        public string Address { get; set; }
       
        [Required(ErrorMessage = "*required*")]
        public string City { get; set; }    
    }
}