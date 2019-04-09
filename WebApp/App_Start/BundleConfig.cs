using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
           "~/Scripts/bootstrap.js", "~/Scripts/bootstrap.bundle.js", "~/Scripts/bootbox.js", "~/Scripts/respond.js"));



            bundles.Add(new ScriptBundle("~/bundles/Choosen").Include(
           "~/Scripts/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/blockUI").Include(
           "~/Scripts/query.blockUI.js"));


            bundles.Add(new ScriptBundle("~/bundles/DatatAbles").Include(
          "~/Scripts/DataTables/jquery.dataTables.js"));






            bundles.Add(new ScriptBundle("~/bundles/SalesPos").Include(
       "~/Areas/POS/Script/Sales.js"));













            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css", "~/Content/simple-sidebar.css", "~/Content/chosen.css", "~/Content/themes/base/jquery-ui.min.css", "~/Content/DataTables/css/jquery.dataTables.css"));



        }
    }
}