using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DM.App.Library.Core
{
    public enum UIExtensions
    {
        Select2 = 1,
        Ckeditor
    }

    public class UILibSelector
    {
        public enum UILibs
        {
            PlainMvc = 1,
            Metro,
            Bootstrap
        }

        private const string UI_LIBRARY_COOKIE_NAME = "UILib";
        private const string UI_LIBRARY_THEME_COOKIE_NAME = "UILib.Theme";

        private static UILibSelector _uiLibrary = null;

        public UILibs Library { get; set; }
        public string LibraryCss { get; set; }
        public string LibraryAlternateCss { get; set; }
        public string LibraryTheme { get; set; }

        protected UILibSelector(UILibs lib)
        {
            this.Library = lib;
            this.LibraryCss = "";
            this.LibraryAlternateCss = "";
            this.LibraryTheme = "";
        }

        public static UILibSelector GetUILibrary()
        {
            return GetUILibrary(null);
        }

        public static UILibSelector GetUILibrary(HttpRequestBase request)
        {
            if (_uiLibrary == null)
            {
                string tmp = Configuration.Settings.UILibrary();
                UILibs uiLib = UILibs.Bootstrap;
                if (!Enum.TryParse<UILibs>(tmp, out uiLib))
                    uiLib = UILibs.Bootstrap;
                _uiLibrary = new UILibSelector(uiLib);

                tmp = Configuration.Settings.UILibraryTheme();
                if (!string.IsNullOrEmpty(tmp))
                    _uiLibrary.LibraryTheme = tmp;

                if (request != null)
                {
                    if (request.Cookies.AllKeys.Contains(UI_LIBRARY_COOKIE_NAME))
                    {
                        HttpCookie cookie = request.Cookies[UI_LIBRARY_COOKIE_NAME];
                        if (!string.IsNullOrEmpty(cookie.Value))
                        {
                            if (Enum.TryParse<UILibs>(cookie.Value, out uiLib))
                            {
                                _uiLibrary = new UILibSelector(uiLib);

                                if (request.Cookies.AllKeys.Contains(UI_LIBRARY_THEME_COOKIE_NAME))
                                {
                                    HttpCookie cookie1 = request.Cookies[UI_LIBRARY_THEME_COOKIE_NAME];
                                    if (!string.IsNullOrEmpty(cookie1.Value))
                                    {
                                        // add theme
                                        _uiLibrary.LibraryTheme = cookie1.Value;
                                    }
                                }
                            }
                        }
                    }
                }

                tmp = Configuration.Settings.UILibraryCss();
                if (!string.IsNullOrEmpty(tmp))
                    _uiLibrary.LibraryCss = tmp;
                _uiLibrary.LibraryAlternateCss = GetAlternateCss(_uiLibrary);
            }
            return _uiLibrary;
        }

        public string GetClass(string key, int cellsInRow)
        {
            string value = key;

            switch (key)
            {
                //case "readonly":
                //    value = "readonly";
                //    break;
                case "cell":
                    if (this.Library == UILibs.Bootstrap)
                    {
                        if (cellsInRow > 12)
                            cellsInRow = 12;
                        //value = "col-sm-" + (12 / cellsInRow) + " col-md-" + (12 / cellsInRow) + " col-lg-" + (12 / cellsInRow);
                        value = " col-md-" + (12 / cellsInRow) + " col-lg-" + (12 / cellsInRow);
                    }
                    else
                        value = "cell";
                    break;
                default:
                    break;
            }

            return value;
        }

        public bool RequireGridRowSize()
        {
            switch (this.Library)
            {
                case UILibs.PlainMvc:
                    return false;
                case UILibs.Metro:
                    return true;
                case UILibs.Bootstrap:
                    return false;
                default:
                    break;
            }
            return false;
        }

        public HtmlLibHelper GetHtmlHelper()
        {
            HtmlLibHelper helper = null;
            switch (this.Library)
            {
                case UILibs.PlainMvc:
                    helper = new HtmlLibMetroHelper();
                    break;
                case UILibs.Metro:
                    helper = new HtmlLibMetroHelper();
                    break;
                case UILibs.Bootstrap:
                    helper = new HtmlLibBootstrapHelper();
                    break;
                default:
                    helper = new HtmlLibMetroHelper();
                    break;
            }
            helper.UseEntityNamePrefix = Configuration.Settings.UseEntityNamePrefix();

            if (Configuration.Settings.EnableSelect2())
                helper.RegisterUiExtension(UIExtensions.Select2);
            if (Configuration.Settings.EnableCkeditor())
                helper.RegisterUiExtension(UIExtensions.Ckeditor);

            return helper;
        }

        public static UILibs SwitchUILibrary(HttpResponseBase response, string library = null, string theme = null)
        {
            UILibs lib = GetUILibrary().Library;
            string[] allowedLibs = Configuration.Settings.UILibraryAllowedLibs();
            string[] allowedThemes = Configuration.Settings.UILibraryAllowedThemes();

            if (string.IsNullOrEmpty(library))
            {
                if (lib == UILibs.Bootstrap && allowedLibs.Contains(UILibs.Metro.ToString()))
                    GetUILibrary().Library = UILibs.Metro;
                else if (lib == UILibs.Metro && allowedLibs.Contains(UILibs.Bootstrap.ToString()))
                    GetUILibrary().Library = UILibs.Bootstrap;
            }
            else
            {
                if (allowedLibs.Contains(library))
                {
                    UILibs uiLibTemp = UILibs.PlainMvc;
                    if (Enum.TryParse<UILibs>(library, out uiLibTemp))
                    {
                        GetUILibrary().Library = uiLibTemp;
                        if (allowedThemes.Contains(theme))
                        {
                            GetUILibrary().LibraryTheme = theme;
                        }
                        GetUILibrary().LibraryAlternateCss = GetAlternateCss(GetUILibrary());
                    }
                }
            }

            response.SetCookie(new HttpCookie(UI_LIBRARY_COOKIE_NAME, GetUILibrary().Library.ToString()));
            response.SetCookie(new HttpCookie(UI_LIBRARY_THEME_COOKIE_NAME, GetUILibrary().LibraryTheme));

            return GetUILibrary().Library;
        }

        private static string GetAlternateCss(UILibSelector uiLib)
        {
            // Bootstrap-Flat:metro-bootstrap.css

            //string[] values = Configuration.Settings.UILibraryAlternateCss();
            //if (values.Length > 0)
            //{
            //    //string[] arr = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        string key = uiLib.Library.ToString();
            //        if (!string.IsNullOrEmpty(uiLib.LibraryTheme))
            //            key = key + "-" + uiLib.LibraryTheme;
            //        key = key + ":";
            //        if (values[i].IndexOf(key, StringComparison.InvariantCultureIgnoreCase) > -1)
            //        {
            //            string css = values[i].Replace(key, "");
            //            return css;
            //        }
            //    }
            //}
            //return "";
            return GetAlternateCss(uiLib.Library, uiLib.LibraryTheme);
        }

        public static string GetAlternateCss(UILibs library, string theme)
        {
            // Bootstrap-Flat:metro-bootstrap.css

            string[] values = Configuration.Settings.UILibraryAlternateCss();
            if (values.Length > 0)
            {
                //string[] arr = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < values.Length; i++)
                {
                    string key = library.ToString();
                    if (!string.IsNullOrEmpty(theme))
                        key = key + "-" + theme;
                    key = key + ":";
                    if (values[i].IndexOf(key, StringComparison.InvariantCultureIgnoreCase) > -1)
                    {
                        string css = values[i].Replace(key, "");
                        return css;
                    }
                }
            }
            return "";
        }

        public string FormatAlternateCssKey(UILibs library, string theme)
        {
            return library.ToString() + "-" + theme;
        }
    }
}
