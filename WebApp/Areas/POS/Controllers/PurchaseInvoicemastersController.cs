using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Areas.POS.Controllers
{
    public class PurchaseInvoicemastersController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: POS/PurchaseInvoicemasters
        public ActionResult Index()
        {
            var purchaseInvoicemasters = db.PurchaseInvoicemasters.Include(p => p.Customer).Include(p => p.Store);
            return View(purchaseInvoicemasters.ToList());
        }

        // GET: POS/PurchaseInvoicemasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoicemaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
            if (purchaseInvoicemaster == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoicemaster);
        }

        // GET: POS/PurchaseInvoicemasters/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName");
            return View();
        }

        // POST: POS/PurchaseInvoicemasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseInvoicemasterID,PurchaseInvoiceNum,StoreID,CustomerID,InvoiceDate,PurchaseDate,TotalPaid,TotalBill,TotalDiscount,RoundOffAmount,IsCommited,IsDeleted,DeletedBy,DeletedDate")] PurchaseInvoicemaster purchaseInvoicemaster)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseInvoicemasters.Add(purchaseInvoicemaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", purchaseInvoicemaster.CustomerID);
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", purchaseInvoicemaster.StoreID);
            return View(purchaseInvoicemaster);
        }

        // GET: POS/PurchaseInvoicemasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoicemaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
            if (purchaseInvoicemaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", purchaseInvoicemaster.CustomerID);
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", purchaseInvoicemaster.StoreID);
            return View(purchaseInvoicemaster);
        }

        // POST: POS/PurchaseInvoicemasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseInvoicemasterID,PurchaseInvoiceNum,StoreID,CustomerID,InvoiceDate,PurchaseDate,TotalPaid,TotalBill,TotalDiscount,RoundOffAmount,IsCommited,IsDeleted,DeletedBy,DeletedDate")] PurchaseInvoicemaster purchaseInvoicemaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseInvoicemaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", purchaseInvoicemaster.CustomerID);
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", purchaseInvoicemaster.StoreID);
            return View(purchaseInvoicemaster);
        }

        // GET: POS/PurchaseInvoicemasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoicemaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
            if (purchaseInvoicemaster == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoicemaster);
        }

        // POST: POS/PurchaseInvoicemasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseInvoicemaster purchaseInvoicemaster = db.PurchaseInvoicemasters.Find(id);
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
