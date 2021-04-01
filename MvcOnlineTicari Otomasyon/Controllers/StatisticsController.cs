using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Currents.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Staffs.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.Products.Count(x => x.Stock<=20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = c.Products.Count(x => x.ProductName=="Buzdolabı" ).ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 =c.Products.Where(u=>u.ProductID== c.SalesActs
                                                            .GroupBy(x => x.ProductID)
                                                            .OrderByDescending(y => y.Count())
                                                            .Select(y => y.Key)
                                                            .FirstOrDefault())
                                                            .Select(k=>k.ProductName)
                                                            .FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SalesActs.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = deger14;

            DateTime now = DateTime.Today;
            var deger15 = c.SalesActs.Count(x => x.Date ==now).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SalesActs.Where(x => x.Date == now).Sum(x => x.TotalAmount).ToString();
            ViewBag.d16 = deger16;


            return View();
        }
        public ActionResult SimpleTables()
        {
            var sorgu = from x in c.Currents
                        group x by x.CurrentCity into g
                        select new ClassGroup
                        {
                            City = g.Key,
                            Number = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Staffs
                         group x by x.DepartmentID into g
                         select new ClassGroup2
                         {
                             Department = g.Key,
                             Number = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu3 = c.Currents.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial3()
        {
            var sorgu4 = c.Products.ToList();
            return PartialView(sorgu4);
        }
        public PartialViewResult Partial4()
        {
            var sorgu4 = from x in c.Products
                         group x by x.Brand into g
                         select new ClassGroup3
                         {
                             Brand = g.Key,
                             Number = g.Count()
                         };
            return PartialView(sorgu4.ToList());
        }
    }
}