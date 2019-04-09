using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.POS.Models;
using WebApp.Extensions;
using WebApp.Models;
using WebApp.Models.DBModels;
using WebApp.Repository;

namespace WebApp.Areas.POS.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: POS/Sales
        public ActionResult Index()
        {

            var Invoicemasters = db.InvoiceMasters.OrderByDescending(u => u.InvoicemasterID);
            return View(Invoicemasters.ToList());
        }

        // GET: POS/Sales
        public ActionResult SalesPos()
        {
            SalesViewModal mdl = (new SalesRepo()).GetSalesModel(0);


            return View(mdl);
        }


        [HttpGet]
        public JsonResult GetProductList(int Id = 0)
        {
            List<ProductListViewModel> mdlist = (new SalesRepo()).GetProducts(Id);


            return Json(new { mdlist = mdlist }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductData(int Id = 0)
        {
            ProductListViewModel mdl = (new SalesRepo()).GetProductData(Id);


            return Json(new { mdlist = mdl }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult CreateInvoice(InvoiceMasterViewModel order)
        {
            bool status = false;

            order = (new InvoiceRepository()).AddinvoiceMaster(order);
            status = true;
            return new JsonResult { Data = new { status = status, model = order } };
        }

        [HttpGet]
        public ActionResult InvoiceReport(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesViewModal mdl = (new SalesRepo()).GetSalesModel(id);
            if (mdl.InvoiceMaster == null)
            {
                return HttpNotFound();
            }


            return View(mdl);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesViewModal mdl = (new SalesRepo()).GetSalesModel(id);
            if (mdl.InvoiceMaster == null)
            {
                return HttpNotFound();
            }


            return View(mdl);
        }


        [HttpPost]
        public JsonResult Commit(int id = 0)
        {
            bool status = false;
            (new InvoiceRepository()).CommitAction(false, id);
            status = true;
            return new JsonResult { Data = new { status = status } };
        }
    }
}