using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari_Otomasyon.Models.Classes;
namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Include("Category").Where(x => x.Status == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> deger1 = 
                                         (from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                            Text = x.CategoryName,
                                            Value=x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var deger = c.Products.Find(id);
            deger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDetails(int id)
        {
            List<SelectListItem> deger1 =
                                        (from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Products.Find(id);
            return View("ProductDetails", urundeger);

        }
        public ActionResult UpdateProduct(Product product)
        {
            var urn = c.Products.Find(product.ProductID);
            urn.PurchasePrice = product.PurchasePrice;
            urn.Status = true;
            urn.CategoryID = product.CategoryID;
            urn.Brand = product.Brand;
            urn.SalePrice = product.SalePrice;
            urn.Stock = product.Stock;
            urn.ProductName = product.ProductName;
            urn.ProductPhoto = product.ProductPhoto;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var degerler = c.Products.ToList();
            return View(degerler);
        }
    }
}