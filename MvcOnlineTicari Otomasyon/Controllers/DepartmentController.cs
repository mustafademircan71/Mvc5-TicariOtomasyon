using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari_Otomasyon.Models.Classes;
namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departments.Where(x=>x.Status==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDepartment(Department department)
        {
            c.Departments.Add(department);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDelete(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailsDepatment(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("DetailsDepatment", dpt);

        }
        public ActionResult UpdateDeaprtment(Department department)
        {
            var dept = c.Departments.Find(department.DepartmentID);
            dept.DepartmentName = department.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetails(int id)
        {
            var deger = c.Staffs.Where(x => x.DepartmentID == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(deger);
        } 
        public ActionResult DepartmentStaffSelectAct(int id)
        {
            var degerler = c.SalesActs.Where(x => x.StaffID == id).ToList();
            var per = c.Staffs.Where(x => x.StaffID == id).Select(y => y.StaffName +" "+ y.StaffSurname).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }

    }
}