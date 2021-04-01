using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class InvoicePen
    {
        [Key]
        public int InvoicePenID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}