using System.Data.Entity;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DBModels;
using System.Linq;
namespace WebApp.Areas.Masters.Controllers
{
    public class CustomerAsyncController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Masters/CustomerAsync
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CustomerAddPartial()
        {
            return PartialView("CustomerAddPartial");
        }


        [HttpGet]
        public PartialViewResult CustomerData()
        {


            var Customers = db.Customers.Where(u => u.Isactive == true).ToList();

            return PartialView("CustomerData", Customers);
        }


        [HttpPost]
        public JsonResult CreateCustomer(Customer customer)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                customer.StoreID = int.Parse(System.Web.HttpContext.Current.Session["storeid"].ToString());

                db.Customers.Add(customer);
                db.SaveChanges();
                status = true;
            }
            //Repository.PurchaseInvoiceRepository purchaseInvoiceRepository = new Repository.PurchaseInvoiceRepository();
            //purchaseInvoiceRepository.AddPurchaseInvoicemaster(order);
            //status = true;
            //Thread.Sleep(200000);
            return new JsonResult { Data = new { status = status } };
        }



    }
}