using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DBModels;

namespace WebApp.Areas.Masters.Controllers
{
    public class CategoryAsyncController : Controller
    {
        private WebAppContext db = new WebAppContext();
        // GET: Masters/CategoryAsync
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CategoryAddPartial()
        {
            //return PartialView("CustomerAddPartial");

            return View();
        }


        [HttpPost]
        public JsonResult CreateCategory(Category category)
        {
            bool status = false;

            if (ModelState.IsValid)
            {


                db.Categories.Add(category);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}