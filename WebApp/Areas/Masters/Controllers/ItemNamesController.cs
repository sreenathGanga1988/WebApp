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
    public class ItemNamesController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Masters/ItemNames
        public ActionResult Index()
        {
            var itemNames = db.ItemNames.Include(i => i.Category);
            return View(itemNames.ToList());
        }

        // GET: Masters/ItemNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemName itemName = db.ItemNames.Find(id);
            if (itemName == null)
            {
                return HttpNotFound();
            }
            return View(itemName);
        }

        // GET: Masters/ItemNames/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Masters/ItemNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemDesc,CategoryId,Isactive")] ItemName itemName)
        {
            if (ModelState.IsValid)
            {
                db.ItemNames.Add(itemName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", itemName.CategoryId);
            return View(itemName);
        }

        // GET: Masters/ItemNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemName itemName = db.ItemNames.Find(id);
            if (itemName == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", itemName.CategoryId);
            return View(itemName);
        }

        // POST: Masters/ItemNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemDesc,CategoryId,Isactive")] ItemName itemName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", itemName.CategoryId);
            return View(itemName);
        }

        // GET: Masters/ItemNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemName itemName = db.ItemNames.Find(id);
            if (itemName == null)
            {
                return HttpNotFound();
            }
            return View(itemName);
        }

        // POST: Masters/ItemNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemName itemName = db.ItemNames.Find(id);
            db.ItemNames.Remove(itemName);
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
