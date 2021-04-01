using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class ToDoList
    {
        [Key]
        public int ToDoListID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Header { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        
    }
}