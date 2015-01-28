using System.Web;
using System.Web.Optimization;

namespace HighSchoolHacking
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/prism").Include(
                        "~/Scripts/prism.js"));

            bundles.Add(new ScriptBundle("~/bundles/sliding").Include(
                        "~/Scripts/sliding.ts"));

            bundles.Add(new StyleBundle("~/Content/prism").Include(
                "~/Content/prism.css"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/positioning.scss",
                "~/Content/styling.scss"
            ));
        }
    }
}
