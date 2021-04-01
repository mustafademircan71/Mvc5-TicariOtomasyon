using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler = c.Products.Where(x => x.ProductID == 1).ToList();
            cs.Deger1 = c.Products.Where(x => x.ProductID == 1).ToList();
            cs.Deger2 = c.Details.Where(y => y.DetailsID == 2).ToList();
            return View(cs);
        }
    }
}