using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari_Otomasyon.Models.Classes;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Currents.Where(x=>x.Status==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCurrent(Current current)
        {
            current.Status = true;
            c.Currents.Add(current);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var curr = c.Currents.Find(id);
            curr.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDetails(int id)
        {
            var curr = c.Currents.Find(id);
            return View(curr);
        }
        public ActionResult UpdateCurrent(Current current)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentDetails");
            }
            var cari = c.Currents.Find(current.CurrentID);
            cari.CurrentName = current.CurrentName;
            cari.CurrentSurname = current.CurrentSurname;
            cari.CurrentMail = current.CurrentMail;
            cari.CurrentCity = current.CurrentCity;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentSalesAct(int id)
        {
            var degerler = c.SalesActs.Where(x => x.CurrentID == id).ToList();
            var cr = c.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.current = cr;
            return View(degerler);
        }
    }
}