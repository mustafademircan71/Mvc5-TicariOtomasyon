using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string ProductPhoto { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<SalesAct> SalesActs { get; set; }
    }
}