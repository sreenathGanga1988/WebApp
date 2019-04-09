using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Areas.Reports.Controllers
{
    public class SalesReportController : Controller
    {
        WebAppContext cntxt = new WebAppContext();
        // GET: Reports/SalesReport
        public ActionResult Index()
        {

            var product = cntxt.Products.Where(u => u.IsDelivered == false).ToList();
            return View(product);
        }
    }
}