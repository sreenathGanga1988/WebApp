using System.Web.Mvc;

namespace WebApp.Areas.CustomerLoans
{
    public class CustomerLoansAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CustomerLoans";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CustomerLoans_default",
                "CustomerLoans/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}