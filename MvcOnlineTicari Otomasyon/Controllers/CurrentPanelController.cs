using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var currentMail = (string)Session["CurrentMail"];
            var degerler = c.Currents.FirstOrDefault(x => x.CurrentMail == currentMail);
            
            return View(degerler);
        }
    }
}