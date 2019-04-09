using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApp.Areas.POS.Models;
using WebApp.Extensions;
using WebApp.Models;
using WebApp.Models.DBModels;

namespace WebApp.Areas.POS.Controllers
{
    [Authorize]
    public class PurchaseInvoicemastersController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: POS/PurchaseInvoicemasters
        public ActionResult Index()
        {
            var purchaseInvoicemasters = db.PurchaseInvoicemasters.Include(p => p.Customer).Include(p => p.Store);
            return View(purchaseInvoicemasters.ToList().OrderByDescending(u => u.PurchaseInvoicemasterID));
        }

        // GET: POS/PurchaseInvoicemasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoiceMaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
            if (purchaseInvoicemaster == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoicemaster);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName");
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.ItemNameID = new SelectList(db.ItemNames, "Id", "ItemDesc");
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

        // GET: POS/PurchaseInvoicemasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoiceMaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
            if (purchaseInvoicemaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.ItemNameID = new SelectList(db.ItemNames, "Id", "ItemDesc");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", purchaseInvoicemaster.CustomerID);
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", purchaseInvoicemaster.StoreID);
            return View(purchaseInvoicemaster);
        }

        // POST: POS/PurchaseInvoicemasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(PurchaseViewModel purchaseViewModel)
        {
            bool status = false;
            Repository.PurchaseInvoiceRepository purchaseInvoiceRepository = new Repository.PurchaseInvoiceRepository();
            purchaseInvoiceRepository.UpdatePurchaseInvoicemaster(purchaseViewModel);
            status = true;
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult Commit(int id = 0)
        {
            bool status = false;
            Repository.PurchaseInvoiceRepository purchaseInvoiceRepository = new Repository.PurchaseInvoiceRepository();
            purchaseInvoiceRepository.CommitAction(false, id);
            status = true;
            return new JsonResult { Data = new { status = status } };
        }

        // GET: POS/PurchaseInvoicemasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoiceMaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
            if (purchaseInvoicemaster == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoicemaster);
        }

        // POST: POS/PurchaseInvoicemasters/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseInvoiceMaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
            db.PurchaseInvoicemasters.Remove(purchaseInvoicemaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}