using System.Web;
using System.Web.Optimization;

namespace Saas.Office.Auto.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            ResetIgnorePatterns(bundles.IgnoreList);
            //脚本
            bundles.Add(new ScriptBundle("~/Content/js/core").Include(
                //"~/Content/metronic/assets/global/plugins/jquery.min.js",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Content/js/json2.min.js",
                "~/Content/js/utils.js",
                "~/Content/js/common.js",
                "~/Content/js/knockout-2.2.1.js",
                "~/Content/js/knockout.mapping-2.4.1.js",
                "~/Content/js/knockout.bindings.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/js.cookie.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/jquery.blockui.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/jquery-ui/jquery-ui.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Content/js/login").Include(
                "~/Content/Saas.Office.Auto/assets/global/plugins/jquery-validation/js/additional-methods.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/select2/js/select2.full.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/backstretch/jquery.backstretch.min.js",
                "~/Content/Saas.Office.Auto/assets/pages/scripts/login-5.js"
                ));
            bundles.Add(new ScriptBundle("~/Content/js/global").Include(
                "~/Content/Saas.Office.Auto/assets/global/scripts/app.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Content/js/layout").Include(
                "~/Content/Saas.Office.Auto/assets/layouts/layout2/scripts/layout.min.js",
                "~/Content/Saas.Office.Auto/assets/layouts/layout2/scripts/demo.min.js",
                "~/Content/Saas.Office.Auto/assets/layouts/global/scripts/quick-sidebar.min.js",
                "~/Content/Saas.Office.Auto/assets/layouts/global/scripts/quick-nav.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Content/js/plugins/datatables").Include(
                "~/Content/Saas.Office.Auto/assets/global/scripts/datatable.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/datatables/datatables.min.js",
                "~/Content/Saas.Office.Auto/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js",
                "~/Content/Saas.Office.Auto/assets/pages/scripts/table-datatables-managed.js"
                ));

            bundles.Add(new ScriptBundle("~/Content/js/plugins/model").Include(
                "~/Content/Saas.Office.Auto/assets/pages/scripts/ui-modals.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Content/js/plugins/mvcpager").Include(
                "~/Content/plugins/MvcPager.js"
                ));
            //样式
            bundles.Add(new StyleBundle("~/Content/css/global").Include(
                      "~/Content/Saas.Office.Auto/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/Saas.Office.Auto/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                      "~/Content/Saas.Office.Auto/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/Saas.Office.Auto/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"));

            bundles.Add(new StyleBundle("~/Content/css/global/style").Include(
                      "~/Content/Saas.Office.Auto/assets/global/css/components.min.css",
                      "~/Content/Saas.Office.Auto/assets/global/css/plugins.min.css",
                      "~/Content/Saas.Office.Auto/assets/pages/css/about.min.css"));

            bundles.Add(new StyleBundle("~/Content/css/global/layout").Include(
                      "~/Content/Saas.Office.Auto/assets/layouts/layout2/css/layout.min.css",
                      "~/Content/Saas.Office.Auto/assets/layouts/layout2/css/themes/light.min.css",
                      "~/Content/Saas.Office.Auto/assets/layouts/layout2/css/custom.min.css"));
            bundles.Add(new StyleBundle("~/Content/css/plugins/datatables").Include(
                     //"~/Content/metronic/assets/global/plugins/datatables/datatables.min.css",   
                     "~/Content/Saas.Office.Auto/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new StyleBundle("~/Content/css/login").Include(
                "~/Content/Saas.Office.Auto/assets/global/plugins/select2/css/select2.min.css",
                "~/Content/Saas.Office.Auto/assets/global/plugins/select2/css/select2-bootstrap.min.css",
                "~/Content/Saas.Office.Auto/assets/pages/css/login-5.min.css"
                ));
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
        public static void ResetIgnorePatterns(IgnoreList ignoreList)
        {
            ignoreList.Clear();
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}
