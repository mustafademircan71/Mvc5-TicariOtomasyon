using MvcOnlineTicari_Otomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Invoices.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult NewInvoice()
        {
            return View();
        }
        public ActionResult NewInvoice(Invoice invoice)
        {
            c.Invoices.Add(invoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetails(int id)
        {
            var invoice = c.Invoices.Find(id);
            return View("InvoiceDetails", invoice);
        }
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var invc = c.Invoices.Find(invoice.InvoiceID);
            invc.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            invc.InvoiceOrderNumber = invoice.InvoiceOrderNumber;
            invc.TaxAdministration = invoice.TaxAdministration;
            invc.Clock = invoice.Clock;
            invc.Delivering = invoice.Delivering;
            invc.DeliveryArea = invoice.DeliveryArea;
            invc.InvoiceDate = invoice.InvoiceDate;
            invc.Total = invoice.Total;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailsInvoice(int id)
        {
            var degerler = c.InvoicePens.Where(x => x.InvoiceID == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewInvicePens()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewInvicePens(InvoicePen invoicePen)
        {
            c.InvoicePens.Add(invoicePen);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}