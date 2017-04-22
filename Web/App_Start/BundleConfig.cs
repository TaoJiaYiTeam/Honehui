using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/inspiniaCore").Include(
                      "~/Library/js/jquery-2.1.1.js",
                      "~/Library/js/jquery-ui.custom.min.js",
                      "~/Library/js/bootstrap.min.js", 
                      "~/Library/Vue/vue.min.js",
                      "~/Library/js/plugins/metisMenu/jquery.metisMenu.js",
                      "~/Library/js/plugins/slimscroll/jquery.slimscroll.min.js",
                      "~/Library/js/plugins/jeditable/jquery.jeditable.js",
                      "~/Library/js/plugins/dataTables/datatables.min.js",
                      "~/Library/js/plugins/sweetalert/sweetalert.min.js",
                      "~/Library/js/plugins/iCheck/icheck.min.js",
                      "~/Library/js/plugins/bootstrap-markdown/bootstrap-markdown.js",
                      "~/Library/js/plugins/bootstrap-markdown/markdown.js",
                      "~/Library/js/plugins/select2/select2.full.min.js",
                      "~/Library/js/plugins/duallistbox/jquery.bootstrap-duallistbox.min.js",
                      "~/Library/js/plugins/toastr/toastr.min.js",
                      "~/Library/js/inspinia.js",
                      "~/Library/js/plugins/pace/pace.min.js",
                      "~/Library/js/plugins/datapicker/bootstrap-datepicker.js",
                      "~/Library/js/plugins/fullcalendar/moment.min.js",
                      "~/Library/js/plugins/fullcalendar/fullcalendar.min.js",
                      "~/Library/js/plugins/ladda/spin.min.js",
                      "~/Library/js/plugins/ladda/ladda.min.js",
                      "~/Library/js/plugins/ladda/ladda.jquery.min.js",
                      "~/Library/bootstrapTable/bootstrap-table.min.js",
                      "~/Library/bootstrapTable/locale/bootstrap-table-zh-CN.min.js",
                      "~/Scripts/main.js"
                ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Library/css/bootstrap.min.css",
                     "~/Library/font-awesome/css/font-awesome.css",
                     "~/Library/css/animate.css",
                     "~/Library/css/style.css",
                     "~/Library/css/plugins/sweetalert/sweetalert.css",
                     "~/Library/css/plugins/iCheck/custom.css",
                     "~/Library/css/plugins/bootstrap-markdown/bootstrap-markdown.min.css",
                     "~/Library/css/plugins/select2/select2.min.css",
                     "~/Library/css/plugins/duallistbox/bootstrap-duallistbox.min.css",
                     "~/Library/css/plugins/toastr/toastr.min.css",
                     "~/Library/css/plugins/fullcalendar/fullcalendar.css",
                     "~/Library/css/plugins/ladda/ladda-themeless.min.css",
                     "~/Library/bootstrapTable/bootstrap-table.css",
                     "~/Content/main.css"));

        }
    }
}
