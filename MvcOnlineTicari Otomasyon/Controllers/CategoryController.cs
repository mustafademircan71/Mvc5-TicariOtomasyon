using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari_Otomasyon.Models.Classes;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Categories.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult NewCategory(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteCategory(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDetails(int id)
        {
            var category = c.Categories.Find(id);
            return View("CategoryDetails", category);
        }
        public ActionResult UpdateCategory(Category category)
        {
            var ctg = c.Categories.Find(category.CategoryID);
            ctg.CategoryName = category.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}