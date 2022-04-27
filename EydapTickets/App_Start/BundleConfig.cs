using System.Collections.Generic;
using System.Web.Optimization;
using DevExpress.Printing.Native.PrintEditor;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(EydapTickets.App_Start.BundleConfig), "RegisterBundles")]

namespace EydapTickets.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles()
        {
            // Add @Styles.Render("~/Content/bootstrap") in the <head/> of your _Layout.cshtml view
            // For Bootstrap theme add @Styles.Render("~/Content/bootstrap-theme") in the <head/> of your _Layout.cshtml view
            // Add @Scripts.Render("~/Bundles/bootstrap") after jQuery in your _Layout.cshtml view
            // When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            BundleTable.Bundles.Add(new ScriptBundle("~/Bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap-theme").Include("~/Content/bootstrap-theme.css"));

            BundleCollection bundles = BundleTable.Bundles;

            ScriptBundle ljQuery = new ScriptBundle("~/Bundles/jquery");
            ljQuery.Include("~/Scripts/jquery-{version}.js");
            ljQuery.Include("~/Scripts/jquery-migrate-{version}.js");
            ljQuery.Include("~/Scripts/jquery.ba-throttle-debounce.js");

            if (DM.App.Library.Core.Configuration.Settings.EnableTimePickerUIControl())
            {
                ljQuery.Include("~/Scripts/wickedpicker.js");
            }

            bundles.Add(ljQuery);

            //"~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // jQuery Extensions Bundle
            bundles.Add(new ScriptBundle("~/Bundles/jQueryExtensions.Bundle").Include(
                "~/Scripts/jquery.ba-throttle-debounce.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/Bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Style.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));

            //bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
            //            "~/Content/themes/base/core.css",
            //            "~/Content/themes/base/resizable.css",
            //            "~/Content/themes/base/selectable.css",
            //            "~/Content/themes/base/accordion.css",
            //            "~/Content/themes/base/autocomplete.css",
            //            "~/Content/themes/base/button.css",
            //            "~/Content/themes/base/dialog.css",
            //            "~/Content/themes/base/slider.css",
            //            "~/Content/themes/base/tabs.css",
            //    //"~/Content/themes/base/datepicker.css",
            //            "~/Content/themes/base/progressbar.css",
            //            "~/Content/themes/base/theme.css"));

            bundles.Add(new ScriptBundle("~/Bundles/app").Include("~/Scripts/app.js"));

            DM.App.Library.Core.UILibSelector uiLib = DM.App.Library.Core.UILibSelector.GetUILibrary();

            {
                // Lib1 (MetroUI) CSS
                List<string> paths = new List<string>();
                paths.Add("~/Content/metro.css");
                paths.Add("~/Content/metro-icons.css");
                paths.Add("~/Content/metro-print.css");

                if (DM.App.Library.Core.Configuration.Settings.EnableJQueryUpload())
                    paths.Add("~/Content/jquery.uploadfile.css");

                bundles.Add(new ScriptBundle("~/Content/jslib1").Include(paths.ToArray()));

                // Lib1 (MetroUI) JS
                paths = new List<string>();
                if (DM.App.Library.Core.Configuration.Settings.EnableSelect2())
                    paths.Add("~/Scripts/select2.js");
                paths.Add("~/Scripts/metro.js");
                if (DM.App.Library.Core.Configuration.Settings.EnableCkeditor())
                {
                    paths.Add("~/Content/ckeditor/ckeditor.js");
                    paths.Add("~/Content/ckeditor/config.js");
                    paths.Add("~/Content/ckeditor/styles.js");
                }
                if (DM.App.Library.Core.Configuration.Settings.EnableJQueryUpload())
                {
                    paths.Add("~/Scripts/jquery.form.js");
                    paths.Add("~/Scripts/jquery.uploadfile.js");
                }
                paths.Add("~/Scripts/jquery.tmpl.js");

                bundles.Add(new ScriptBundle("~/Bundles/jslib1").Include(paths.ToArray()));
            }

            {
                // Lib2 (Bootstrap) CSS
                List<string> paths = new List<string>();
                //string[] altCss = App.Library.Core.Configuration.Settings.UILibraryAlternateCss();
                foreach (string theme in DM.App.Library.Core.Configuration.Settings.UILibraryAllowedThemes())
                {
                    if ("Classic".Equals(theme, System.StringComparison.InvariantCultureIgnoreCase))
                        paths.Add("~/Content/bootstrap.min.css");
                    else
                    {
                        string css = DM.App.Library.Core.UILibSelector.GetAlternateCss(uiLib.Library, theme);

                        paths.Add("~/Content/" + css);

                        // Custom: load print css.
                        if (css == "metro-bootstrap.css")
                        {
                            paths.Add("~/Content/metro-bootstrap.print.css");
                        }
                    }
                    if (!string.IsNullOrEmpty(uiLib.LibraryCss))
                        paths.Add("~/Content/" + uiLib.LibraryCss);

                    //paths.Add("~/Content/sb-admin-2.css");
                    //paths.Add("~/Content/metisMenu.min.css");
                    paths.Add("~/Content/font-awesome.min.css");
                    paths.Add("~/Content/bootstrap-switch.min.css");
                    paths.Add("~/Content/bootstrap-datepicker.min.css");
                    paths.Add("~/Content/bootstrap-slider.min.css");

                    if (DM.App.Library.Core.Configuration.Settings.EnableSelect2())
                        paths.Add("~/Content/select2.css");

                    if (DM.App.Library.Core.Configuration.Settings.EnableJQueryUpload())
                        paths.Add("~/Content/jquery.uploadfile.css");

                    if ("Classic".Equals(theme, System.StringComparison.InvariantCultureIgnoreCase))
                        bundles.Add(new StyleBundle("~/Content/csslib2").Include(paths.ToArray()));
                    else
                        bundles.Add(new StyleBundle("~/Content/csslib2-" + theme).Include(paths.ToArray()));
                    paths = new List<string>();
                }

                // Lib2 (Bootstrap) JS
                paths = new List<string>();
                paths.Add("~/Scripts/bootstrap.min.js");
                paths.Add("~/Scripts/bootstrap-switch.min.js");
                paths.Add("~/Scripts/bootstrap-datepicker.min.js");
                paths.Add("~/Scripts/bootstrap-slider.min.js");
                //paths.Add("~/Scripts/sb-admin-2.js");
                //paths.Add("~/Scripts/metisMenu.min.js");
                if (DM.App.Library.Core.Configuration.Settings.EnableSelect2())
                    paths.Add("~/Scripts/select2.js");

                if (DM.App.Library.Core.Configuration.Settings.EnableCkeditor())
                {
                    paths.Add("~/Content/ckeditor/ckeditor.js");
                    paths.Add("~/Content/ckeditor/config.js");
                    paths.Add("~/Content/ckeditor/styles.js");
                }
                if (DM.App.Library.Core.Configuration.Settings.EnableJQueryUpload())
                {
                    paths.Add("~/Scripts/jquery.form.js");
                    paths.Add("~/Scripts/jquery.uploadfile.js");
                }
                paths.Add("~/Scripts/jquery.tmpl.js");

                bundles.Add(new ScriptBundle("~/Bundles/jslib2").Include(paths.ToArray()));
            }

            // Legacy JS
            bundles.Add(new ScriptBundle("~/Bundles/jslegacy").Include(
                "~/Scripts/html5shiv.js",
                "~/Scripts/respond.js",
                "~/Scripts/json2.js"
                ));

            // Application Insights
            bundles.Add(new ScriptBundle("~/Bundles/application-insights").Include(
                "~/Scripts/ai.1.0.20-build00666.js"));

            // Overrides CSS
            {
                //bundles.Add(new StyleBundle("~/Content/css-overrides").Include(
                //    "~/Content/overrides.css"));
                List<string> paths = new List<string>();

                if (DM.App.Library.Core.Configuration.Settings.EnableTimePickerUIControl())
                {
                    paths.Add("~/Content/wickedpicker.css");
                }

                paths.Add("~/Content/overrides.css");

                //if (!string.IsNullOrEmpty(uiLib.LibraryTheme))
                //{
                //    string pathTheme = string.Format("Content/overrides-{0}-{1}.css", uiLib.Library.ToString(), uiLib.LibraryTheme.ToString());
                //    if (System.IO.File.Exists(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, pathTheme)))
                //        paths.Add("~/" + pathTheme);
                //}
                bundles.Add(new StyleBundle("~/Content/css-overrides").Include(paths.ToArray()));
            }

            // Main Style Bundle
            bundles.Add(new StyleBundle("~/Bundles/MainStyle.Bundle")
                .Include(
                    "~/Content/Site.css",
                    "~/Content/TicketingStyles.css"
                ));

            // Global Grid View Bundle
            bundles.Add(new ScriptBundle("~/Bundles/GlobalGridView.Bundle")
                .Include("~/Scripts/GlobalGridView.js"));

            // Incident Grid View Bundle
            bundles.Add(new ScriptBundle("~/Bundles/IncidentGridView.Bundle")
                .Include("~/Scripts/IncidentGridView.js"));

            // Task Grid View Bundle
            bundles.Add(new ScriptBundle("~/Bundles/TaskGridView.Bundle")
                .Include("~/Scripts/TaskGridView.js"));

            // Assignment Grid View Bundle
            bundles.Add(new ScriptBundle("~/Bundles/AssignmentGridView.Bundle")
                .Include("~/Scripts/AssignmentGridView.js"));

            // Correlated Grid View Bundle
            bundles.Add(new ScriptBundle("~/Bundles/CorrelatedGridView.Bundle")
                .Include("~/Scripts/CorrelatedGridView.js"));

            // Open Task Grid View Bundle
            bundles.Add(new ScriptBundle("~/Bundles/OpenTaskGridView.Bundle")
                .Include("~/Scripts/OpenTaskGridView.js"));
        }
    }
}
