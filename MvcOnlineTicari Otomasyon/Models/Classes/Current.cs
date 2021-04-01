using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="Cari Adı En Fazla 30 Karakter yazabilirsiniz")]
        [Required(ErrorMessage ="Bu alanı Boş Geçemezsiniz!")]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Password { get; set; }

        public bool Status { get; set; }
        public virtual ICollection<SalesAct> SalesActs { get; set; }

    }
}