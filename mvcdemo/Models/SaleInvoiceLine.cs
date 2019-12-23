using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
     public class SaleInvoiceLine
    {
        [Key]
        public int SaleLineId { get; set; }
        public int SaleId { get; set; }   
        public int ItemId { get; set; }
        [Required(ErrorMessage = "*required")]
        [Range(typeof(Decimal), "1", "9999", ErrorMessage = "required valid qty")]
        public decimal Qty { get; set; }
        [Required(ErrorMessage = "*required")]
        [Range(typeof(Decimal), "1", "9999", ErrorMessage = "Rate xx.xx")]
        public decimal Rate { get; set; }
        [ForeignKey("ItemId")]
        public virtual SaleInvoiceLine SaleInvoiceLines { get; set; }
        [ForeignKey("SaleId")]
        public virtual SaleInvoiceHeader SalesInvoiceHeaders { get; set; }
    }
}