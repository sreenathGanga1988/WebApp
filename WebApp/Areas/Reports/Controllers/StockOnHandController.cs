using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Repository;

namespace WebApp.Areas.Reports.Controllers
{
    public class StockOnHandController : Controller
    {
        // GET: Reports/StockOnHand
        public ActionResult Index()
        {
            return View((new ReportDataRepo()).getStockReport());
        }

        public ActionResult CategoryWiseStock()
        {
            return View((new ReportDataRepo()).getStockReport());
        }
    }
}