using System.Web;
using System.Web.Optimization;

namespace CodeFirst_EF
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap-grid.min.css",
                     "~/Content/bootstrap-rtl.min.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/site.css"));

            
            bundles.Add(new Bundle("~/Scripts/jquery").Include("~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/modernizr-2.8.3.js",
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/jquery.validate*"
                      ));

            // مدل زیر ارور instance of object  میده
            /*bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/modernizr-2.8.3.js"
                      ));
           */
        }
    }
}
