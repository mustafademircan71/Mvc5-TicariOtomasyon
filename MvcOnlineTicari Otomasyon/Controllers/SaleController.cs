using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SalesActs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewSalesAct()
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            
            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName+" "+x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName+" "+x.StaffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSalesAct(SalesAct salesAct)
        {
            salesAct.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesActs.Add(salesAct);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesActDetails(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SalesActs.Find(id);
            return View("SalesActDetails", deger);
        }
        public ActionResult UpdateSalesAct(SalesAct salesAct)
        {
            var sal = c.SalesActs.Find(salesAct.SalesActID);
            sal.ProductID = salesAct.ProductID;
            sal.CurrentID = salesAct.CurrentID;
            sal.StaffID = salesAct.StaffID;
            sal.Quantity = salesAct.Quantity;
            sal.UnitPrice = salesAct.UnitPrice;
            sal.TotalAmount = salesAct.TotalAmount;
            sal.Date = salesAct.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailsSalesAct(int id)
        {
            var degerler = c.SalesActs.Where(x => x.SalesActID == id).ToList();
            return View(degerler);

        }
    }
}