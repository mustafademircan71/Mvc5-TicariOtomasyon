using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        public DateTime History { get; set; }
        public decimal Amount { get; set; }
    }
}