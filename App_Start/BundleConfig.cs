using System.Web;
using System.Web.Optimization;

namespace Xaydung
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Resources/JS/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Resources/JS/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Resources/JS/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Resources/JS/Scripts/bootstrap.js",
                      "~/Resources/JS/Scripts/respond.js",
                      "~/Resources/JS/Scripts/umd/popper.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Resources/CSS/bootstrap/bootstrap.css",
                      "~/Resources/CSS/bootstrap/site.css"));

            bundles.Add(new StyleBundle("~/Content/Home").Include(
                      "~/Resources/CSS/Home/FixStyle.css"));

            bundles.Add(new StyleBundle("~/Content/Icon").Include(
                      "~/Resources/Icons/css/fontawesome-all.css"));

            bundles.Add(new ScriptBundle("~/bundles/select").Include(
                        "~/Resources/JS/Scripts/Select2/select2.min.js",
                        "~/Resources/JS/Scripts/Item/BootstrapSelect/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/itemfilter").Include(
                        "~/Resources/JS/Scripts/Item/Itemfilter.js"));

        }
    }
}
