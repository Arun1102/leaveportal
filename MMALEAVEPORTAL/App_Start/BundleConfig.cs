using System.Web;
using System.Web.Optimization;

namespace MMALEAVEPORTAL
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/jquery-3.6.0.js", "~/Scripts/umd/popper.js", "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Styles/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Styles/site").Include("~/Content/Styles.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
