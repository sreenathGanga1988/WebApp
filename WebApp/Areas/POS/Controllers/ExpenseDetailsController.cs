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

namespace WebApp.Areas.POS.Controllers
{
    public class ExpenseDetailsController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: POS/ExpenseDetails
        public ActionResult Index()
        {
            var expenseDetails = db.ExpenseDetails.Include(e => e.ExpenseItem);
            return View(expenseDetails.ToList());
        }

        // GET: POS/ExpenseDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseDetail expenseDetail = db.ExpenseDetails.Find(id);
            if (expenseDetail == null)
            {
                return HttpNotFound();
            }
            return View(expenseDetail);
        }

        // GET: POS/ExpenseDetails/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ExpenseItemID", "ExpenseItemName");
            return View();
        }


        // GET: Masters/ExpenseDetails/Create
        public ActionResult CreateAsync()
        {
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ExpenseItemID", "ExpenseItemName");
            return View();
        }
        // POST: POS/ExpenseDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ExpenseDetailID,ExpenseItemID,ExpenseDetailRemark,ExpenseDate,AddedDate,AddedUser,Deleteddate,DeletedUser,ModifiedDate,ModifiedUser,IsDeleted")] ExpenseDetail expenseDetail)
        {

            expenseDetail.AddedUser = HttpContext.Session["username"].ToString();
            expenseDetail.IsDeleted = false;
            expenseDetail.AddedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ExpenseDetails.Add(expenseDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ExpenseItemID", "ExpenseItemName", expenseDetail.ExpenseItemID);
            return View(expenseDetail);
        }

        // GET: POS/ExpenseDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseDetail expenseDetail = db.ExpenseDetails.Find(id);
            if (expenseDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ExpenseItemID", "ExpenseItemName", expenseDetail.ExpenseItemID);
            return View(expenseDetail);
        }

        // POST: POS/ExpenseDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ExpenseDetailID,ExpenseItemID,ExpenseDetailRemark,ExpenseDate,AddedDate,AddedUser,Deleteddate,DeletedUser,ModifiedDate,ModifiedUser,IsDeleted")] ExpenseDetail expenseDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ExpenseItemID", "ExpenseItemName", expenseDetail.ExpenseItemID);
            return View(expenseDetail);
        }

        // GET: POS/ExpenseDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseDetail expenseDetail = db.ExpenseDetails.Find(id);
            if (expenseDetail == null)
            {
                return HttpNotFound();
            }
            return View(expenseDetail);
        }

        // POST: POS/ExpenseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseDetail expenseDetail = db.ExpenseDetails.Find(id);
            db.ExpenseDetails.Remove(expenseDetail);
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
