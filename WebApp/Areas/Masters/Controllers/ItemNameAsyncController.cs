using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DBModels;
namespace WebApp.Areas.Masters.Controllers
{
    public class ItemNameAsyncController : Controller
    {
        private WebAppContext db = new WebAppContext();
        // GET: Masters/ItemNameAsync
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ItemNameAddPartial()
        {
            //return PartialView("CustomerAddPartial");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        [HttpGet]
        public JsonResult GetCategory(int Id = 0)
        {


            SelectList ourstyleitem = new SelectList(db.Categories.Where(o => o.Isactive == true), "Id", "CategoryName");


            JsonResult jsd = Json(ourstyleitem, JsonRequestBehavior.AllowGet);

            return jsd;

        }

        [HttpPost]
        public JsonResult CreateItemName(ItemName ItemName)
        {
            bool status = false;

            if (ModelState.IsValid)
            {


                db.ItemNames.Add(ItemName);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}