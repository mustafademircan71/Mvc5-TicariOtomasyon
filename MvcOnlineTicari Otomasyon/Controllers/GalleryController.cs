using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Products.ToList();
            return View(degerler);
        }
    }
}