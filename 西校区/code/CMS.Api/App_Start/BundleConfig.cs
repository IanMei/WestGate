using System.Web;
using System.Web.Optimization;

namespace ElementUI.Admin
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                "~/Scripts/vue.js", 
                "~/Scripts/vue-resource.js", 
                "~/Scripts/qs.js", 
                "~/Scripts/axios.js"));
            bundles.Add(new ScriptBundle("~/bundles/element").Include(
                            "~/Scripts/ElementUI/element-ui.js", "~/Scripts/http.js"));
            bundles.Add(new StyleBundle("~/Content/elementcss").Include(
                                  "~/Content/ElementUI/element-ui.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/js/bootstrap.js"));
            bundles.Add(new StyleBundle("~/bundles/bootstrapcss").Include(
                "~/css/bootstrap.css"));
            BundleTable.EnableOptimizations = false;  //是否打包压缩
        }
    }
}
