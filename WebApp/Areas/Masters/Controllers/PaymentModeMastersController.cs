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
    public class PaymentModeMastersController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Masters/PaymentModeMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.PaymentModeMasters.ToListAsync());
        }

        // GET: Masters/PaymentModeMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModeMaster paymentModeMaster = await db.PaymentModeMasters.FindAsync(id);
            if (paymentModeMaster == null)
            {
                return HttpNotFound();
            }
            return View(paymentModeMaster);
        }

        // GET: Masters/PaymentModeMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/PaymentModeMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PaymentModeID,PaymentMode")] PaymentModeMaster paymentModeMaster)
        {
            if (ModelState.IsValid)
            {
                db.PaymentModeMasters.Add(paymentModeMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paymentModeMaster);
        }

        // GET: Masters/PaymentModeMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModeMaster paymentModeMaster = await db.PaymentModeMasters.FindAsync(id);
            if (paymentModeMaster == null)
            {
                return HttpNotFound();
            }
            return View(paymentModeMaster);
        }

        // POST: Masters/PaymentModeMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PaymentModeID,PaymentMode")] PaymentModeMaster paymentModeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentModeMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paymentModeMaster);
        }

        // GET: Masters/PaymentModeMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModeMaster paymentModeMaster = await db.PaymentModeMasters.FindAsync(id);
            if (paymentModeMaster == null)
            {
                return HttpNotFound();
            }
            return View(paymentModeMaster);
        }

        // POST: Masters/PaymentModeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PaymentModeMaster paymentModeMaster = await db.PaymentModeMasters.FindAsync(id);
            db.PaymentModeMasters.Remove(paymentModeMaster);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public PartialViewResult PaymentModeData()
        {


            var Customers = db.PaymentModeMasters.ToList();

            return PartialView("PaymentModeData", Customers);
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
