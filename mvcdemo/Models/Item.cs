using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Item   
    {
       [Key]
        public int ItemId { get; set; }    

        public string ItemName { get; set; }
        [Required(ErrorMessage = "*required*")]

        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Units { get; set; }
    }
}