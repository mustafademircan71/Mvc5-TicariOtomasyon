using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string  InvoiceSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string InvoiceOrderNumber { get; set; }
        
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Clock { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivering { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryArea { get; set; }

        public decimal Total { get; set; }
        public virtual ICollection<InvoicePen> InvoicePens { get; set; } = new HashSet<InvoicePen>();
    }   
}