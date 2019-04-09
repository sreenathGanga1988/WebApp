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

namespace WebApp.Areas.Masters.Controllers
{
    public class ExpenseItemsController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Masters/ExpenseItems
        public ActionResult Index()
        {
            return View(db.ExpenseItems.ToList());
        }

        // GET: Masters/ExpenseItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return View(expenseItem);
        }

        // GET: Masters/ExpenseItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/ExpenseItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ExpenseItemID,ExpenseItemName")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseItems.Add(expenseItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseItem);
        }

        // GET: Masters/ExpenseItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return View(expenseItem);
        }

        // POST: Masters/ExpenseItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ExpenseItemID,ExpenseItemName")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseItem);
        }

        // GET: Masters/ExpenseItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return View(expenseItem);
        }

        // POST: Masters/ExpenseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            db.ExpenseItems.Remove(expenseItem);
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
