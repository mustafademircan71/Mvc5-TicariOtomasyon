using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string StaffPhoto { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<SalesAct> SalesActs { get; set; }
    }
}