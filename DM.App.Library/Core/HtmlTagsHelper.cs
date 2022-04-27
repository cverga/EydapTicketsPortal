using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc.Html;
using DM.App.Library.Models;

namespace DM.App.Library.Core
{
    public static class HtmlTagsHelper
    {
        public static int MapFieldStateToFormState(Enums.FormStates state, int stateInNew, int stateInEdit, int stateInView, int stateInList)
        {
            int fieldState = -1;
            if (state == Enums.FormStates.New)
            {
                fieldState = stateInNew;
            }
            else if (state == Enums.FormStates.Edit)
            {
                fieldState = stateInEdit;
            }
            else if (state == Enums.FormStates.View || state == Enums.FormStates.ViewEmbedded)
            {
                fieldState = stateInView;
            }
            else if (state == Enums.FormStates.List)
            {
                fieldState = stateInList;
            }
            return fieldState;
        }

        public static string MapFieldControlToFormState(Enums.FormStates state, string controlInNew, string controlInEdit, string controlInView, string controlInList)
        {
            string fieldControl = HtmlLibHelper.CONTROL_TEXTBOX;
            if (state == Enums.FormStates.New)
            {
                fieldControl = controlInNew;
            }
            else if (state == Enums.FormStates.Edit)
            {
                fieldControl = controlInEdit;
            }
            else if (state == Enums.FormStates.View || state == Enums.FormStates.ViewEmbedded)
            {
                fieldControl = controlInView;
            }
            else if (state == Enums.FormStates.List)
            {
                fieldControl = controlInList;
            }
            return fieldControl;
        }

        public static string CreateOpenTag(string tag, string attributes)
        {
            return string.Format("<{0} {1}>{2}", tag, attributes, Environment.NewLine);
        }


        public static string CreateCloseTag(string tag)
        {
            return string.Format("</{0}>{1}", tag, Environment.NewLine);
        }

        public static string CreateOpenDiv(string classNames, string attributes)
        {
            if (string.IsNullOrEmpty(classNames))
                return CreateOpenTag("div", attributes);
            else
                return CreateOpenTag("div", "class=\"" + classNames + "\" " + attributes);
        }


        public static string CreateCloseDiv()
        {
            return CreateCloseTag("div");
        }

        public static string CreateOpenDivRow(int cells)
        {
            if (cells > 12)
                cells = 12;
            if (UILibSelector.GetUILibrary().RequireGridRowSize())
                return CreateOpenDivRow(cells, "row cells" + cells, null);
            else
                return "<!-- UILib - no support for row div -->";
        }

        public static string CreateOpenDivRow(int cells, string classNames, string attributes)
        {
            if (cells > 12)
                cells = 12;
            if (UILibSelector.GetUILibrary().RequireGridRowSize())
            {
                if (string.IsNullOrEmpty(classNames))
                    classNames = "row cells" + cells;
                return CreateOpenTag("div", "class=\"" + classNames + "\" " + attributes);
            }
            else
                return "<!-- UILib - no support for row div -->";
        }

        public static string CreateOpenDivCell(int cellsInRow)
        {
            return CreateOpenDivCell(UILibSelector.GetUILibrary().GetClass("cell", cellsInRow), null);
        }

        public static string CreateOpenDivCell(string classNames, string attributes)
        {
            if (string.IsNullOrEmpty(classNames))
                classNames = "cell";
            return CreateOpenTag("div", "class=\"" + classNames + "\" " + attributes);
        }

        public static bool ShowFieldInFullRow(Models.Interfaces.ICategoryField categoryField)
        {
            return (categoryField.LayoutOrder == -1);
        }

        public static bool ShowFieldInRowWithEmptyCell(Models.Interfaces.ICategoryField categoryField)
        {
            return (categoryField.LayoutOrder == -2);
        }

        public static IHtmlString CreateControlForField(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldPrefix, string fieldTitle, string controlType, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            IHtmlString htmlString = null;
            StringBuilder sb = new StringBuilder();

            sb.Append(UILibSelector.GetUILibrary().GetHtmlHelper().CreateControlForField(htmlHelper, fieldName, fieldPrefix, fieldTitle, controlType, state, formState, categoryField));

            if (sb.Length > 0)
                htmlString = new HtmlString(sb.ToString());

            return htmlString;
        }

        public static IHtmlString CreateJSValidationContent(System.Web.Mvc.HtmlHelper htmlHelper, Enums.FormStates formState, IEnumerable<Models.Interfaces.ICategoryField> fields)
        {
            IHtmlString htmlString = null;
            StringBuilder sb = new StringBuilder();
            List<string> functions = new List<string>();
            bool hasValidationScript = false;

            if (formState == Enums.FormStates.List || formState == Enums.FormStates.View)
                return new HtmlString("");

            sb.AppendFormat("<script type=\"text/javascript\">{0}", Environment.NewLine);
            foreach (Models.Interfaces.ICategoryField field in fields)
            {
                int fieldState = HtmlTagsHelper.MapFieldStateToFormState(formState, field.FieldStateInNewForm, field.FieldStateInEditForm, field.FieldStateInViewForm, -1);
                if (fieldState == (int)Enums.FieldStates.Editable)
                {
                    if (!string.IsNullOrEmpty(field.ValidationJSScript))
                    {
                        sb.AppendFormat("{1}{0}", Environment.NewLine, HtmlTagsHelper.CreateJSValidationContentForField(htmlHelper, field.InternalName, null, field.GetTitle(), field.ControlTypeInNewForm, (Enums.FieldStates)fieldState, formState, field));
                        functions.Add(string.Format("CustomValidate{0}()", field.InternalName));
                        hasValidationScript = true;
                    }
                }
            }
            sb.AppendFormat("{0}function CustomValidate() {{ {0}", Environment.NewLine);
            sb.AppendFormat("\tvar errors = [];{0}", Environment.NewLine);
            sb.AppendFormat("\tvar msg = \"\";{0}", Environment.NewLine);
            foreach (string item in functions)
            {
                sb.AppendFormat("\tmsg = {1};{0}", Environment.NewLine, item);
                sb.AppendFormat("\tif (msg != \"\"){0}", Environment.NewLine);
                sb.AppendFormat("\t\terrors.push({{ elementId: \"#{1}\", errorMessage: msg }});{0}", Environment.NewLine, item.Replace("CustomValidate", "").Replace("()", ""));
            }
            sb.AppendFormat("\treturn errors;{0}", Environment.NewLine);
            sb.AppendFormat("}} {0}</script>", Environment.NewLine);
            if (sb.Length > 0 && hasValidationScript)
                htmlString = new HtmlString(sb.ToString());
            return htmlString;
        }

        private static string CreateJSValidationContentForField(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldPrefix, string fieldTitle, string controlType, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            IHtmlString htmlString = null;
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(categoryField.ValidationJSScript))
            {
                string js = categoryField.ValidationJSScript;
                if (!js.StartsWith("function ", StringComparison.InvariantCultureIgnoreCase))
                {
                    sb.AppendFormat("function CustomValidate{0}(fieldName) {{", fieldName);
                }

                sb.Append(js.Replace("[[FIELDNAME]]", fieldName));

                if (!js.StartsWith("function", StringComparison.InvariantCultureIgnoreCase))
                {
                    sb.Append("}}");
                }
            }
            if (sb.Length > 0)
                htmlString = new HtmlString(sb.ToString());
            return sb.ToString();
        }

        public static IHtmlString CreateJSDocumentReadyContent(System.Web.Mvc.HtmlHelper htmlHelper, Enums.FormStates formState, IEnumerable<Models.Interfaces.ICategoryField> fields)
        {
            IHtmlString htmlString = null;
            StringBuilder sb = new StringBuilder();
            //List<string> functions = new List<string>();
            bool hasScript = false;

            if (formState == Enums.FormStates.List || formState == Enums.FormStates.View)
                return new HtmlString("");

            foreach (Models.Interfaces.ICategoryField field in fields)
            {
                int fieldState = HtmlTagsHelper.MapFieldStateToFormState(formState, field.FieldStateInNewForm, field.FieldStateInEditForm, field.FieldStateInViewForm, -1);
                if (fieldState == (int)Enums.FieldStates.Editable)
                {
                    if (!string.IsNullOrEmpty(field.DocumentReadyJSScript))
                    {
                        sb.AppendFormat("{1}{0}", Environment.NewLine, HtmlTagsHelper.CreateJSDocumentReadyContentForField(htmlHelper, field.InternalName, null, field.GetTitle(), field.ControlTypeInNewForm, (Enums.FieldStates)fieldState, formState, field));
                        //functions.Add(string.Format("CustomValidate{0}()", field.InternalName));
                        hasScript = true;
                    }
                }
            }

            if (sb.Length > 0 && hasScript)
                htmlString = new HtmlString(sb.ToString());
            return htmlString;
        }

        private static string CreateJSDocumentReadyContentForField(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldPrefix, string fieldTitle, string controlType, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            IHtmlString htmlString = null;
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(categoryField.DocumentReadyJSScript))
            {
                string js = categoryField.DocumentReadyJSScript;

                sb.Append(js.Replace("[[FIELDNAME]]", fieldName));
            }
            if (sb.Length > 0)
                htmlString = new HtmlString(sb.ToString());
            return sb.ToString();
        }

        public static object BuildQueryStringRouteValues(object id, object ext, string hostWebUrl, string appWebUrl, string clientTag, string productNumber)
        {
            object obj = null;

            if (string.IsNullOrEmpty(hostWebUrl) && string.IsNullOrEmpty(appWebUrl))
            {
                if (id != null)
                    obj = new { Id = id };
                else
                    obj = new { };
            }
            else
            {
                if (id != null)
                    obj = new { Id = id, Ext = ext, SPHostUrl = hostWebUrl, SPClientTag = clientTag, SPProductNumber = productNumber, SPAppWebUrl = appWebUrl, };
                else
                    obj = new { SPHostUrl = hostWebUrl, SPClientTag = clientTag, SPProductNumber = productNumber, SPAppWebUrl = appWebUrl, };
            }
            return obj;
        }

        public static object BuildQueryStringRouteValues(HttpRequestBase request)
        {
            string hostWebUrl = request.QueryString["SPHostUrl"];
            string appWebUrl = request.QueryString["SPAppWebUrl"];

            if (string.IsNullOrEmpty(hostWebUrl) && request.Cookies["SPHOSTWEBURL"] != null)
                hostWebUrl = request.Cookies["SPHOSTWEBURL"].Value;
            if (string.IsNullOrEmpty(appWebUrl) && request.Cookies["SPAPPWEBURL"] != null)
                appWebUrl = request.Cookies["SPAPPWEBURL"].Value;
            return BuildQueryStringRouteValues(null, null, hostWebUrl, appWebUrl, request.QueryString["SPClientTag"], request.QueryString["SPProductNumber"]);
        }

        public static object BuildQueryStringRouteValues(HttpRequestBase request, object id)
        {
            string hostWebUrl = request.QueryString["SPHostUrl"];
            string appWebUrl = request.QueryString["SPAppWebUrl"];

            if (string.IsNullOrEmpty(hostWebUrl) && request.Cookies["SPHOSTWEBURL"] != null)
                hostWebUrl = request.Cookies["SPHOSTWEBURL"].Value;
            if (string.IsNullOrEmpty(appWebUrl) && request.Cookies["SPAPPWEBURL"] != null)
                appWebUrl = request.Cookies["SPAPPWEBURL"].Value;
            return BuildQueryStringRouteValues(id, null, hostWebUrl, appWebUrl, request.QueryString["SPClientTag"], request.QueryString["SPProductNumber"]);
        }

        public static object BuildQueryStringRouteValues(HttpRequestBase request, object id, object ext)
        {
            string hostWebUrl = request.QueryString["SPHostUrl"];
            string appWebUrl = request.QueryString["SPAppWebUrl"];

            if (string.IsNullOrEmpty(hostWebUrl) && request.Cookies["SPHOSTWEBURL"] != null)
                hostWebUrl = request.Cookies["SPHOSTWEBURL"].Value;
            if (string.IsNullOrEmpty(appWebUrl) && request.Cookies["SPAPPWEBURL"] != null)
                appWebUrl = request.Cookies["SPAPPWEBURL"].Value;
            return BuildQueryStringRouteValues(id, ext, hostWebUrl, appWebUrl, request.QueryString["SPClientTag"], request.QueryString["SPProductNumber"]);
        }

        public static void SetContextWebUrls(HttpRequestBase request, out string hostWebUrl, out string appWebUrl)
        {
            hostWebUrl = request.QueryString["SPHostUrl"];
            appWebUrl = request.QueryString["SPAppWebUrl"];

            if (string.IsNullOrEmpty(hostWebUrl) && request.Cookies["SPHOSTWEBURL"] != null)
                hostWebUrl = request.Cookies["SPHOSTWEBURL"].Value;
            if (string.IsNullOrEmpty(appWebUrl) && request.Cookies["SPAPPWEBURL"] != null)
                appWebUrl = request.Cookies["SPAPPWEBURL"].Value;
        }

        public static bool IsLegacyBrowser(HttpRequestBase request)
        {
            if (request.UserAgent.IndexOf("MSIE 8.") >= 0 || request.UserAgent.IndexOf("MSIE 7.") >= 0 || request.UserAgent.IndexOf("MSIE 6.") >= 0 || request.UserAgent.IndexOf("MSIE 5.") >= 0)
            {
                if (request.UserAgent.IndexOf("Trident/5.") >= 0)
                    return false;
                else
                    return true;
            }
            return false;
        }
    }
}