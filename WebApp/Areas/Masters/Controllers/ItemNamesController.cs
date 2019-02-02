using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Areas.Masters.Controllers
{
    public class ItemNamesController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Masters/ItemNames
        public async Task<ActionResult> Index()
        {
            return View(await db.ItemNames.ToListAsync());
        }

        // GET: Masters/ItemNames/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemName itemName = await db.ItemNames.FindAsync(id);
            if (itemName == null)
            {
                return HttpNotFound();
            }
            return View(itemName);
        }

        // GET: Masters/ItemNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/ItemNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ItemDesc,Isactive")] ItemName itemName)
        {
            if (ModelState.IsValid)
            {
                db.ItemNames.Add(itemName);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(itemName);
        }

        // GET: Masters/ItemNames/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemName itemName = await db.ItemNames.FindAsync(id);
            if (itemName == null)
            {
                return HttpNotFound();
            }
            return View(itemName);
        }

        // POST: Masters/ItemNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ItemDesc,Isactive")] ItemName itemName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemName).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(itemName);
        }

        // GET: Masters/ItemNames/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemName itemName = await db.ItemNames.FindAsync(id);
            if (itemName == null)
            {
                return HttpNotFound();
            }
            return View(itemName);
        }

        // POST: Masters/ItemNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemName itemName = await db.ItemNames.FindAsync(id);
            db.ItemNames.Remove(itemName);
            await db.SaveChangesAsync();
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
