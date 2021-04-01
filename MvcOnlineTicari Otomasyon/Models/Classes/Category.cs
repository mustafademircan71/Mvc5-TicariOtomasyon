using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}