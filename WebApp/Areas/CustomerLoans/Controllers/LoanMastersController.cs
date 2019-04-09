using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DBModels;

namespace WebApp.Areas.CustomerLoans.Controllers
{
    [AllowAnonymous]
    public class LoanMastersController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: CustomerLoans/LoanMasters
        public ActionResult Index()
        {
            var loanMasters = db.LoanMasters.Include(l => l.Customer);
            return View(loanMasters.ToList());
        }

        // GET: CustomerLoans/LoanMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanMaster loanMaster = db.LoanMasters.Find(id);
            if (loanMaster == null)
            {
                return HttpNotFound();
            }
            return View(loanMaster);
        }

        // GET: CustomerLoans/LoanMasters/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");



            return View();
        }

        // POST: CustomerLoans/LoanMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "LoanID,LoanName,LoanDescription,LoanAmount,FromDate,InterestPercentage,CustomerID,AddedDate,AddedUser")] LoanMaster loanMaster)
        {
            if (ModelState.IsValid)
            {





                LoanPaymentDetail londet = new LoanPaymentDetail();
                londet.FromDate = loanMaster.FromDate;
                londet.BalanceAmount = loanMaster.LoanAmount;
                londet.IsCurrent = true;
                londet.InterestPercentage = loanMaster.InterestPercentage;





                loanMaster.LoanPaymentDetails.Add(londet);






                db.LoanMasters.Add(loanMaster);


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", loanMaster.CustomerID);
            return View(loanMaster);
        }

        // GET: CustomerLoans/LoanMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanMaster loanMaster = db.LoanMasters.Find(id);
            if (loanMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", loanMaster.CustomerID);
            return View(loanMaster);
        }

        // POST: CustomerLoans/LoanMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit([Bind(Include = "LoanID,LoanName,LoanDescription,LoanAmount,FromDate,InterestPercentage,CustomerID,AddedDate,AddedUser")] LoanMaster loanMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", loanMaster.CustomerID);
            return View(loanMaster);
        }

        // GET: CustomerLoans/LoanMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanMaster loanMaster = db.LoanMasters.Find(id);
            if (loanMaster == null)
            {
                return HttpNotFound();
            }
            return View(loanMaster);
        }

        // POST: CustomerLoans/LoanMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanMaster loanMaster = db.LoanMasters.Find(id);
            db.LoanMasters.Remove(loanMaster);
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
