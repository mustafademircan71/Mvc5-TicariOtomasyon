using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class SalesAct
    {
        [Key]
        public int SalesActID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        
        public int ProductID { get; set; }
        public int CurrentID { get; set; }
        public int StaffID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Staff Staff { get; set; }
    }
}