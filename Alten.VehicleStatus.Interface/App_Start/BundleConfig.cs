using System.Web;
using System.Web.Optimization;

namespace Alten.VehicleStatus.Interface
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-ui-router.js"));
            bundles.Add(new ScriptBundle("~/bundles/mainApp").Include(
                        "~/JS/App.js",
                        "~/JS/Services/Common/common-client-service.js",
                        "~/JS/Services/Common/common-service.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

        }
    }
}
