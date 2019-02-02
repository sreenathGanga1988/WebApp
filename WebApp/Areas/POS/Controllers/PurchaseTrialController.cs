using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.POS.Models;
using WebApp.Models;

namespace WebApp.Areas.POS.Controllers
{
    public class PurchaseTrialController : Controller
    {
        private WebAppContext db = new WebAppContext();
        // GET: POS/PurchaseTrial
        public ActionResult Index()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName");
            ViewBag.CategoryID = new SelectList(db.Categories , "Id", "CategoryName");
            ViewBag.ItemNameID = new SelectList(db.ItemNames , "Id", "ItemDesc");
            Models.PurchaseViewModel mdl = new Models.PurchaseViewModel();
            return View(mdl);
        }

        [HttpPost]
        public JsonResult Create(Models.PurchaseViewModel order)
        {

            bool status = false;
            Repository.PurchaseInvoiceRepository purchaseInvoiceRepository = new Repository.PurchaseInvoiceRepository();

            purchaseInvoiceRepository.AddPurchaseInvoicemaster(order);
            
              status = true;


            return new JsonResult { Data = new { status = status } };
        }

    }
}