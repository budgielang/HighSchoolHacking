using System.Web;
using System.Web.Optimization;

namespace HighSchoolHacking
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    "~/Scripts/sliding.js",
                    "~/Scripts/prism.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/positioning.css",
                "~/Content/styling.css",
                "~/Content/home.css",
                "~/Content/prism.css"
            ));
        }
    }
}
