using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Marauder.Web.App_Start
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapplugin").Include(
                      "~/Scripts/moment-with-locales.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-dialog.js",
                      "~/Scripts/bootstrap-select.js",
                      "~/Scripts/bootstrap-select-zh_CN.js",
                      "~/Scripts/bootstrap-table.js",
                      "~/Scripts/bootstrap-table-zh-CN.js",
                      "~/Scripts/bootstrap-treeview.js",
                      "~/Scripts/jquery.twbsPagination.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapplugincss").Include(
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/bootstrap-dialog.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/bootstrap-table.css",
                      "~/Content/bootstrap-treeview.css"));

            bundles.Add(new StyleBundle("~/Content/controlcss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/StyleControl.css"));
        }
    }
}