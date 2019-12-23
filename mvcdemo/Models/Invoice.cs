using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Invoice
    {
        [Key]
        public string InvoiceNo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "*required*")]
        [MaxLength(50)]
        public string Customer { get; set; }

        [Required(ErrorMessage = "*required*")]
        [MaxLength(50)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "*required")]
        [Range(typeof(Decimal), "1", "9999", ErrorMessage = "Requried valid Quantity")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "*required")]
        [Range(typeof(Decimal), "1", "9999", ErrorMessage = "Rate xx.xx")]
        public Decimal Rate { get; set; }
        public int Unit { get; set; }

        [Required(ErrorMessage = "*required")]
        [Range(typeof(Decimal), "1", "9999", ErrorMessage = "Required Valid Amount")]
        public Decimal Amount { get; set; }

    }
}