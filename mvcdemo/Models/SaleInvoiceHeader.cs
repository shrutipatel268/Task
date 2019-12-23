using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class SaleInvoiceHeader
    {
        [Key]
        public int SaleId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "*required valid date*")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SaleDate { get; set; } 
        public int CustomerId { get; set; }

        public string InvoiceNo { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customers { get; set;  }
    }
}