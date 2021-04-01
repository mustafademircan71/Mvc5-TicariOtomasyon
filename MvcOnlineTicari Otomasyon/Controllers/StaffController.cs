using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Staffs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewStaff()
        {
            List<SelectListItem> deger1 =
                                        (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString()
                                         }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult NewStaff(Staff staff)
        {
            c.Staffs.Add(staff);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffDetails(int id)
        {
            List<SelectListItem> deger2 =
                                        (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString()
                                         }).ToList();
            ViewBag.dgr2 = deger2;
            var stf = c.Staffs.Find(id);

            return View("StaffDetails",stf);
        }
        public ActionResult UpdateStaff(Staff staff)
        {
            var stff = c.Staffs.Find(staff.StaffID);
            stff.StaffName = staff.StaffName;
            stff.StaffSurname = staff.StaffSurname;
            stff.StaffPhoto = staff.StaffPhoto;
            stff.DepartmentID = staff.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult StaffList()
        {
            var sorgu = c.Staffs.ToList();
            return View(sorgu);
        }
    }
}