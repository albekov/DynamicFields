using System.Web.Optimization;

namespace DynamicFields
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Assets/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Assets/Styles/main.css"));
        }
    }
}