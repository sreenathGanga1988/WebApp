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
using WebApp.Models.DBModels;

namespace WebApp.Areas.Masters.Controllers
{
    public class UsersController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Masters/Users
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.Store);
            return View(await users.ToListAsync());
        }

        // GET: Masters/Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Masters/Users/Create
        public ActionResult Create()
        {
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName");
            return View();
        }

        // POST: Masters/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<ActionResult> Create([Bind(Include = "UserID,UserName,Password,CreateDate,CreateUser,ModifyDate,ModifyUser,IsDeleted,DeletedUser,StoreID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", user.StoreID);
            return View(user);
        }

        // GET: Masters/Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", user.StoreID);
            return View(user);
        }

        // POST: Masters/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<ActionResult> Edit([Bind(Include = "UserID,UserName,Password,CreateDate,CreateUser,ModifyDate,ModifyUser,IsDeleted,DeletedUser,StoreID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", user.StoreID);
            return View(user);
        }

        // GET: Masters/Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Masters/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
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
