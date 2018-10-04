using System.Web;
using System.Web.Optimization;

namespace FitnessMeal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            bundles.IgnoreList.Clear();
            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                        "~/Scripts/core/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/core/popper.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/others").Include(
                "~/Scripts/plugins/perfect-scrollbarjquery.js",
                "~/Scripts/plugins/bootstrap-notify.js",
                "~/Scripts/plugins/chartjs.js",
                "~/Scripts/plugins/moment.min.js",
                "~/Scripts/plugins/bootstrap-switch.js"

                ));
            bundles.Add(new ScriptBundle("~/bundles/paperdash").Include(
                                "~/Scripts/paper-dashboard.js"
                                ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //          "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/core/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/paper-dashboard.css",
                      "~/Content/sidebar.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/custom.css"
                      ));
        }
    }
}
