using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Current current)
        {
            c.Currents.Add(current);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin1(Current current)
        {
            var bilgiler = c.Currents.FirstOrDefault(x => x.CurrentMail == current.CurrentMail && current.Password == current.Password);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CurrentMail, false);
                Session["CurrentMail"] = bilgiler.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return View();
            }
        }
    }
}