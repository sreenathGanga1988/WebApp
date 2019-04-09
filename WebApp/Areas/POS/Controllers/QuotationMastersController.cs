using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApp.Areas.POS.Models;
using WebApp.Extensions;
using WebApp.Models;
using WebApp.Models.DBModels;

namespace WebApp.Areas.POS.Controllers
{
    [Authorize]
    public class QuotationMastersController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: POS/QuotationMasters
        public ActionResult Index()
        {
            var quotationMasters = (new Repository.QuotationRepository()).GetQuotationListAsync();
            return View(quotationMasters);
        }

        // GET: POS/QuotationMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotationMaster quotationMaster = await db.QuotationMasters.FindAsync(id);
            if (quotationMaster == null)
            {
                return HttpNotFound();
            }
            return View(quotationMaster);
        }

        // GET: POS/QuotationMasters/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName");
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.ItemNameID = new SelectList(db.ItemNames, "Id", "ItemDesc");
            Models.QuotationMasterViewModel mdl = new Models.QuotationMasterViewModel();
            return View(mdl);
        }

        [HttpPost]
        public JsonResult Create(Models.QuotationMasterViewModel order)
        {
            bool status = false;
            Repository.QuotationRepository quotrepo = new Repository.QuotationRepository();
            quotrepo.AddQuotationMaster(order);
            status = true;
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotationMaster quotmaster = db.QuotationMasters.Find(id);
            if (quotmaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.ItemNameID = new SelectList(db.ItemNames, "Id", "ItemDesc");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", quotmaster.CustomerID);
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", quotmaster.StoreID);
            return View(quotmaster);
        }

        // POST: POS/PurchaseInvoicemasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(QuotationMasterViewModel Quotmasterviewmodel)
        {
            bool status = false;
            Repository.QuotationRepository quotrepo = new Repository.QuotationRepository();
            quotrepo.UpdateQuotationMaster(Quotmasterviewmodel);
            status = true;
            return new JsonResult { Data = new { status = status } };
        }

        // GET: POS/QuotationMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotationMaster quotationMaster = await db.QuotationMasters.FindAsync(id);
            if (quotationMaster == null)
            {
                return HttpNotFound();
            }
            return View(quotationMaster);
        }

        // POST: POS/QuotationMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuotationMaster quotationMaster = await db.QuotationMasters.FindAsync(id);
            db.QuotationMasters.Remove(quotationMaster);
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