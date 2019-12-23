using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        [Required(ErrorMessage = "*required*")]
        public string UnitName { get; set; }
       }
}