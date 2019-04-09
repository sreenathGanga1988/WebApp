using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApp.Repository;
using WebApp.Models.DBModels;
using System.Threading;
using WebApp.Models.IdentityStuffs;
using WebApp.Extensions;
namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var q = HttpContext.User.Identity.GetCurrentStoreID();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var tuple = new UserManager().IsvalidUser(username, password);

            if (tuple.Item1)
            {

                User usr = tuple.Item2;
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, username, ClaimValueTypes.String));
                claims.Add(new Claim(ClaimTypes.Role, "RoleName", ClaimValueTypes.String));
                claims.Add(new Claim(CustomClaimTypes.UserID, usr.UserID.ToString(), ClaimValueTypes.Integer));
                claims.Add(new Claim(CustomClaimTypes.StoreID, usr.StoreID.ToString(), ClaimValueTypes.Integer));





                Session["userid"] = usr.UserID;
                Session["storeid"] = usr.StoreID;
                Session["username"] = usr.UserName;





                var ident = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                var claimsPrincipal = new ClaimsPrincipal(ident);
                // Set current principal
                Thread.CurrentPrincipal = claimsPrincipal;
                return RedirectToAction("Index"); // auth succeed

            }
            else
            {
                ViewBag.NotValidUser = "invalid username or password";

            }
            // invalid username or password

            return View();

        }



        [HttpPost]
        public JsonResult LogOut()
        {
            bool status = false;
            Session.Remove("userid");
            Session.Remove("storeid");
            Session.Remove("username");


            status = true;
            return new JsonResult { Data = new { status = status } };
        }







    }
}