using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc.Html;
using DM.App.Library.Models;

namespace DM.App.Library.Core
{
    public class HtmlLibBootstrapHelper : HtmlLibHelper
    {
        public HtmlLibBootstrapHelper()
        {
            genericFormControlClass = "form-control";
            genericFormControlWrapperClass = "form-group";
        }

        protected override string RenderControlTextbox(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;

            attributes.Add("class", genericFormControlClass);
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            object value = modelMetadata.Model;
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                value = GetFormattedValue(value, categoryField.FieldExtension1, state, categoryField);
                tmp = htmlHelper.TextBox(fieldName, value, null, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                if (FieldIsMandatory(categoryField, state, formState))
                {
                    MergeDictionaries(GetRequiredAttributes(fieldTitle), attributes);
                }
                Models.Interfaces.IField field = categoryField.FieldsDefinitions.Where(e => e.Entity == categoryField.Entity && e.FieldName == categoryField.InternalName).FirstOrDefault();
                if (field != null && field.Size > 0)
                {
                    if (!string.IsNullOrEmpty(field.FieldType) && field.FieldType == "decimal")
                    {
                        attributes.Add("maxlength", field.Size + 1);
                    }
                    else
                    {
                        attributes.Add("maxlength", field.Size);
                    }
                }


                string format = GetFormat(value, categoryField.FieldExtension2, state, categoryField);
                tmp = htmlHelper.TextBox(fieldName, null, format, attributes).ToString();
                if (!string.IsNullOrEmpty(categoryField.ValidationJSScript))
                    tmp = tmp.Replace("data-val=\"true\"", "");
            }
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null),
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());

            return sb.ToString();
        }

        override protected string RenderControlTime(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            string lExit = RenderControlTextbox(htmlHelper, fieldName, fieldTitle, state, formState, categoryField);

            if (state == Enums.FieldStates.Editable)
            {
                lExit = lExit.Replace("<input class=\"form-control\"", "<input class=\"form-control timepicker\"");
                string lCleanCntr = string.Format("<div cntr_to_clear=\"{0}\" style=\"cursor:pointer;\" class=\"time_clear\">Καθαρισμός χρόνου</div></div>", fieldName);
                lExit = lExit.Replace("</div>", lCleanCntr);
            }

            return lExit;
        }

        protected override string RenderControlTextArea(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;

            attributes.Add("class", genericFormControlClass);
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            object value = modelMetadata.Model;
            if (state == Enums.FieldStates.Readonly)
            {
                //attributes = new Dictionary<string, object>(readonlyAttributes);
                attributes.Add("disabled", "true");
                MergeDictionaries(readonlyAttributes, attributes);
            }
            else if (state == Enums.FieldStates.Editable)
            {
                if (FieldIsMandatory(categoryField, state, formState))
                {
                    MergeDictionaries(GetRequiredAttributes(fieldTitle), attributes);
                }
            }
            if (Configuration.Settings.EnableCkeditor())
            {
                if (attributes.ContainsKey("class"))
                    attributes["class"] = attributes["class"] + " ckeditor";
                else
                    attributes.Add("class", "ckeditor");
            }
            //tmp = htmlHelper.TextArea(fieldName, null, attributes).ToString();
            attributes.Add("cols", "20");
            attributes.Add("rows", "2");
            string v = string.Empty;
            if (value != null)
                v = System.Net.WebUtility.HtmlEncode(value.ToString());

            tmp = string.Format("<textarea id=\"{0}\" name=\"{0}\" {1}>{2}</textarea>", fieldName, DictionaryToString(attributes), v);

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null),
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        protected override string RenderControlDatetimePicker(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            //string format = datetimeFormat1;
            string tmp = null;
            string tmp2 = null;
            attributes.Add("class", genericFormControlClass);
            //attributes.Add("class", "span2");
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            object value = modelMetadata.Model;
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                value = GetFormattedValue(value, categoryField.FieldExtension1, state, categoryField);
                tmp = InputExtensions.TextBox(htmlHelper, fieldName, value, null, attributes).ToString();
                tmp2 = HtmlTagsHelper.CreateOpenDiv("", null);
            }
            else if (state == Enums.FieldStates.Editable)
            {
                if (FieldIsMandatory(categoryField, state, formState))
                {
                    MergeDictionaries(GetRequiredAttributes(fieldTitle), attributes);
                }
                string format = GetFormat(value, categoryField.FieldExtension2, state, categoryField);
                tmp = InputExtensions.TextBox(htmlHelper, fieldName, null, format, attributes).ToString() +
                    "<span class=\"input-group-addon\"><i class=\"glyphicon glyphicon-th\"></i></span>";
                //tmp2 = HtmlTagsHelper.CreateOpenDiv("input-group date " + requiredClass, "data-date=\"01/01/2015\" data-date-format=\"" + format + "\" data-locale=\"en\"");
                tmp2 = HtmlTagsHelper.CreateOpenDiv("input-group date " + requiredClass, "data-date-format=\"" + Configuration.Formatting.DateFormatForHtml() + "\" data-locale=\"en\"");
            }
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null) + LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  tmp2,
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv() + HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        protected override string RenderControlCheckbox(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            string tmp = null;
            if (state == Enums.FieldStates.Readonly)
            {
                tmp = InputExtensions.CheckBox(htmlHelper, fieldName, false, disabledAttributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                tmp = InputExtensions.CheckBox(htmlHelper, fieldName).ToString();
            }
            tmp = tmp + string.Format("<span class=\"check\"></span><span class=\"caption\">{0}</span>", fieldTitle);

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                 HtmlTagsHelper.CreateOpenDiv("checkbox", null),
                 HtmlTagsHelper.CreateOpenTag("label", null),
                 tmp,
                 HtmlTagsHelper.CreateCloseTag("label") + HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        protected override string RenderControlCheckboxList(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            Dictionary<string, object> dynamicContentAttributes = new Dictionary<string, object>() { { "class", "dynamic-content" }, { "data-apiurl", categoryField.DataSource }, { "data-apifilter", "" }, { "data-fieldvalue", categoryField.FieldExtension1 }, { "data-fieldtext", categoryField.FieldExtension2 } };
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;
            string tmpName = fieldName;
            string readonlyState = "";

            //attributes.Add("class", genericFormControlClass);
            if (state == Enums.FieldStates.Readonly)
            {
                readonlyState = "disabled";
            }
            //else if (state == Enums.FieldStates.Editable)
            {
                List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();
                if (string.IsNullOrEmpty(categoryField.DefaultValue))
                    items.Add(new System.Web.Mvc.SelectListItem() { Text = "", Value = "-1" });
                switch (categoryField.DataSourceTypeId)
                {
                    case (int)Enums.DataSourceTypes.ListValues:
                        {
                            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
                            string value = modelMetadata.Model as string;

                            StringBuilder sbTemp = new StringBuilder();
                            //sbTemp.Append(HtmlTagsHelper.CreateOpenDiv("dynamic-content", null));
                            items = GetListItems(categoryField, null, false);
                            for (int i = 0; i < items.Count; i++)
                            {
                                tmpName = fieldName + "_" + i;
                                sbTemp.Append(HtmlTagsHelper.CreateOpenDiv("checkboxlistitem", null));
                                sbTemp.Append(HtmlTagsHelper.CreateOpenTag("label", null));
                                sbTemp.AppendFormat("<input type=\"checkbox\" id=\"{0}\" name=\"{0}\" {1} {2}/>", tmpName, (items[i].Value == value ? "checked" : ""), readonlyState);
                                sbTemp.AppendFormat("<span class=\"check\"></span><span class=\"caption\">{0}</span>", items[i].Text);
                                sbTemp.Append(HtmlTagsHelper.CreateCloseTag("label"));
                                sbTemp.Append(HtmlTagsHelper.CreateCloseDiv());
                            }
                            //sbTemp.Append(HtmlTagsHelper.CreateCloseDiv());
                            tmp = sbTemp.ToString();
                        }
                        break;
                    case (int)Enums.DataSourceTypes.DBQuery:
                        {
                            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
                            string value = modelMetadata.Model as string;
                            List<string> values = GetListItemsTextDb(categoryField, modelMetadata.Model.ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                            StringBuilder sbTemp = new StringBuilder();
                            for (int i = 0; i < items.Count; i++)
                            {
                                tmpName = fieldName + "_" + i;
                                sbTemp.Append(HtmlTagsHelper.CreateOpenDiv("checkboxlistitem", null));
                                sbTemp.Append(HtmlTagsHelper.CreateOpenTag("label", null));
                                sbTemp.AppendFormat("<input type=\"checkbox\" id=\"{0}\" name=\"{0}\" {1} {2}/>", tmpName, (items[i].Value == value ? "checked" : ""), readonlyState);
                                sbTemp.AppendFormat("<span class=\"check\"></span><span class=\"caption\">{0}</span>", items[i].Text);
                                sbTemp.Append(HtmlTagsHelper.CreateCloseTag("label"));
                                sbTemp.Append(HtmlTagsHelper.CreateCloseDiv());
                            }
                            tmp = sbTemp.ToString();
                        }
                        break;
                    case (int)Enums.DataSourceTypes.WS:
                    case (int)Enums.DataSourceTypes.REST:
                    case (int)Enums.DataSourceTypes.Proxy:
                        {
                            if (categoryField.DataSourceTypeId == (int)Enums.DataSourceTypes.Proxy)
                            {
                                dynamicContentAttributes["data-apiurl"] = "/Proxy?" + dynamicContentAttributes["data-apiurl"];
                            }
                            tmpName = fieldName + "_PLACEHOLDER";
                            attributes.Add("id", tmpName);
                            MergeDictionaries(dynamicContentAttributes, attributes);

                            attributes.Add("data-customcontrol", "checkbox");
                            attributes.Add("data-customstate", readonlyState);
                            tmp = HtmlTagsHelper.CreateOpenTag("span", DictionaryToString(attributes)) +
                                HtmlTagsHelper.CreateCloseTag("span");
                        }
                        break;
                    default:
                        break;
                }
                Dictionary<string, object> attr = new Dictionary<string, object>();
                attr.Add("class", "dynamic-content-hidden");
                tmp2 = InputExtensions.Hidden(htmlHelper, fieldName, null, attr).ToString();
            }

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}", Environment.NewLine,
                 HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null),
                 LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString(),
                 tmp,
                 tmp2,
                 HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        protected override string RenderControlSwitcher(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;
            attributes.Add("class", genericFormControlClass + " switch");

            bool checkedValue = false;
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            if (modelMetadata.Model != null)
            {
                string value = modelMetadata.Model.ToString();
                checkedValue = (value.Equals("true", StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrEmpty(categoryField.FieldExtension1))
                attributes.Add("data-on-text", categoryField.FieldExtension1);
            if (!string.IsNullOrEmpty(categoryField.FieldExtension2))
                attributes.Add("data-off-text", categoryField.FieldExtension2);

            if (!string.IsNullOrEmpty(categoryField.FieldExtension3))
                attributes.Add("data-on-color", categoryField.FieldExtension3);
            if (!string.IsNullOrEmpty(categoryField.FieldExtension4))
                attributes.Add("data-off-color", categoryField.FieldExtension4);

            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(disabledAttributes, attributes);
                tmp = InputExtensions.CheckBox(htmlHelper, fieldName, checkedValue, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                tmp = InputExtensions.CheckBox(htmlHelper, fieldName, checkedValue, attributes).ToString();
            }
            tmp2 = HtmlTagsHelper.CreateOpenDiv("input-group " + requiredClass, null);
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null) + LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  tmp2,
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv() + HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        protected override string RenderControlDropdownList(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField, bool multiSelect)
        {
            Dictionary<string, object> dynamicContentAttributes = new Dictionary<string, object>() { { "class", "dynamic-content" }, { "data-apiurl", categoryField.DataSource }, { "data-apifilter", categoryField.FieldExtension5 }, { "data-fieldvalue", categoryField.FieldExtension1 }, { "data-fieldtext", categoryField.FieldExtension2 } };
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;
            string tmpName = fieldName;

            attributes.Add("class", genericFormControlClass);
            if (state == Enums.FieldStates.Readonly)
            {
                string value = null;
                switch (categoryField.DataSourceTypeId)
                {
                    case (int)Enums.DataSourceTypes.ListValues:
                        break;
                    case (int)Enums.DataSourceTypes.DBQuery:
                        {
                            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
                            if (modelMetadata.Model != null)
                            {
                                //List<string> values = GetListItemsTextDb(categoryField, modelMetadata.Model.ToString().Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries));
                                //value = string.Join(", ", values.ToArray());

                                string[] values = modelMetadata.Model.ToString().Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                                List<System.Web.Mvc.SelectListItem> items = GetListItemsDb(categoryField, values, false);
                                foreach (System.Web.Mvc.SelectListItem lItem in items)
                                {
                                    if (values.Contains(lItem.Value))
                                    {
                                        value += string.Format("{0}{1}", value == null ? "" : ", ", lItem.Text);
                                    }
                                }
                            }
                            tmpName = fieldName + "_val";
                            tmp2 = InputExtensions.Hidden(htmlHelper, fieldName, null, null).ToString();
                        }
                        break;
                    case (int)Enums.DataSourceTypes.WS:
                    case (int)Enums.DataSourceTypes.REST:
                    case (int)Enums.DataSourceTypes.Proxy:
                        {
                            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
                            if (modelMetadata.Model != null)
                            {
                                string[] values = modelMetadata.Model.ToString().Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

                                if (categoryField.DataSource != null && categoryField.DataSource.IndexOf("[[FIELD_VALUE]]") > -1 && values.Length > 0)
                                {
                                    dynamicContentAttributes["data-apiurl"] = categoryField.DataSource.Replace("[[FIELD_VALUE]]", modelMetadata.Model.ToString());
                                }
                            }
                            if (categoryField.DataSourceTypeId == (int)Enums.DataSourceTypes.Proxy)
                            {
                                dynamicContentAttributes["data-apiurl"] = "/Proxy?" + dynamicContentAttributes["data-apiurl"];
                            }
                            MergeDictionaries(dynamicContentAttributes, attributes);
                        }
                        break;
                    default:
                        break;
                }

                MergeDictionaries(readonlyAttributes, attributes);
                tmp = InputExtensions.TextBox(htmlHelper, tmpName, value, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                string[] values = null;
                System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
                if (modelMetadata.Model != null)
                {
                    values = modelMetadata.Model.ToString().Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (categoryField.DataSource != null && categoryField.DataSource.IndexOf("[[FIELD_VALUE]]") > -1 && values.Length > 0)
                    {
                        dynamicContentAttributes["data-apiurl"] = categoryField.DataSource.Replace("[[FIELD_VALUE]]", modelMetadata.Model.ToString());
                    }
                }

                if (FieldIsMandatory(categoryField, state, formState))
                {
                    MergeDictionaries(GetRequiredAttributes(fieldTitle), attributes);
                }
                List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();
                if (string.IsNullOrEmpty(categoryField.DefaultValue))
                    items.Add(new System.Web.Mvc.SelectListItem() { Text = "", Value = "-1" });
                switch (categoryField.DataSourceTypeId)
                {
                    case (int)Enums.DataSourceTypes.ListValues:
                        {
                            items = GetListItems(categoryField, values, true);
                            if (multiSelect)
                                attributes.Add("multiple", "multiple");
                            if (uiExtensions.Contains(UIExtensions.Select2))
                                attributes.Add("data-role", "select");

                            tmp = SelectExtensions.DropDownList(htmlHelper, tmpName, items, attributes).ToString();
                            if (multiSelect)
                            {
                                // Fix selected nodes
                                // Listbox cannot be used, since the (bound) property is not of enumerable type
                                items = GetListItems(categoryField, values, (formState == Enums.FormStates.New));
                                tmp = FixMultiSelectValues(categoryField, tmp, items);
                            }
                        }
                        break;
                    case (int)Enums.DataSourceTypes.DBQuery:
                        {
                            items = GetListItemsDb(categoryField, values, true);

                            if (multiSelect)
                                attributes.Add("multiple", "multiple");
                            if (uiExtensions.Contains(UIExtensions.Select2))
                                attributes.Add("data-role", "select");

                            tmp = SelectExtensions.DropDownList(htmlHelper, tmpName, items, attributes).ToString();
                            if (multiSelect)
                            {
                                // Fix selected nodes
                                // Listbox cannot be used, since the (bound) property is not of enumerable type
                                items = GetListItemsDb(categoryField, values, (formState == Enums.FormStates.New));
                                tmp = FixMultiSelectValues(categoryField, tmp, items);
                            }
                        }
                        break;
                    case (int)Enums.DataSourceTypes.WS:
                    case (int)Enums.DataSourceTypes.REST:
                    case (int)Enums.DataSourceTypes.Proxy:
                        {
                            tmpName = fieldName + "_0";

                            if (categoryField.DataSourceTypeId == (int)Enums.DataSourceTypes.Proxy)
                            {
                                dynamicContentAttributes["data-apiurl"] = "/Proxy?" + dynamicContentAttributes["data-apiurl"];
                            }
                            MergeDictionaries(dynamicContentAttributes, attributes);
                            if (multiSelect)
                                attributes.Add("multiple", "multiple");

                            if (uiExtensions.Contains(UIExtensions.Select2))
                                attributes.Add("data-role", "select");

                            tmp = string.Format("<select id='{0}' name='{0}' {1}></select>", tmpName, DictionaryToString(attributes));

                            Dictionary<string, object> attrHiddden = new Dictionary<string, object>();
                            attrHiddden.Add("class", "dynamic-content-hidden");
                            tmp2 = InputExtensions.Hidden(htmlHelper, fieldName, null, attrHiddden).ToString();
                        }
                        break;
                    default:
                        break;
                }
            }

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null),
                  LabelExtensions.Label(htmlHelper, tmpName, fieldTitle).ToString() + requiredIndicator,
                  tmp,
                  tmp2,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        protected override string RenderControlSpecializedHierarchy(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            Dictionary<string, object> hierarchyAttributes = new Dictionary<string, object>() { { "class", "hierarchy hierarchy_" + categoryField.FieldExtensionId + " full-size" }, { "data-hierarchylevel", categoryField.FieldExtensionId }, { "data-apiurl", "/api/" + categoryField.DataSource }, { "data-apifilter", "?$filter=" + categoryField.FieldExtension1 + " eq [PARENT_ID]" }, { "data-hierarchyentity", fieldName } };
            Dictionary<string, object> hierarchyHiddenAttributes = new Dictionary<string, object>() { { "class", "hierarchy-hidden" }, { "data-apiurl", "/api/" + categoryField.DataSource }, { "data-apifilter", "/[ID]" }, { "data-hierarchyentity", fieldName } };
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;
            string tmpName = string.Format("{0}_{1}", fieldName, categoryField.FieldExtensionId);

            attributes.Add("class", genericFormControlClass);
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                MergeDictionaries(hierarchyAttributes, attributes);
                attributes.Add("placeholder", "...");
                tmp = InputExtensions.TextBox(htmlHelper, tmpName, null, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                MergeDictionaries(hierarchyAttributes, attributes);

                if (uiExtensions.Contains(UIExtensions.Select2))
                    attributes.Add("data-role", "select");

                List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();
                tmp = SelectExtensions.DropDownList(htmlHelper, tmpName, items, attributes).ToString();
            }
            if (categoryField.FieldExtensionId == 0)
                tmp2 = InputExtensions.Hidden(htmlHelper, fieldName, null, hierarchyHiddenAttributes).ToString();

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null),
                  LabelExtensions.Label(htmlHelper, tmpName, fieldTitle).ToString() + requiredIndicator,
                  tmp,
                  tmp2,
                  HtmlTagsHelper.CreateCloseDiv());

            return sb.ToString();
        }

        protected override string RenderControlSpecializedPerson(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;

            attributes.Add("class", genericFormControlClass);
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            string value = "";
            if (modelMetadata.Model != null)
            {
                value = modelMetadata.Model.ToString();
            }
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                //tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
                tmp = HtmlTagsHelper.CreateOpenDiv("custom-peoplepicker", "id=\"peoplePicker" + fieldName + "\" data-value='" + value + "'") + HtmlTagsHelper.CreateCloseDiv();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                if (Configuration.Settings.EnableOfficeControls())
                {
                    tmp = htmlHelper.Hidden(fieldName, null, attributes).ToString();
                    tmp2 = HtmlTagsHelper.CreateOpenDiv("custom-peoplepicker", "id=\"peoplePicker" + fieldName + "\" data-office-control=\"Office.Controls.PeoplePicker\" data-office-options=\"" + categoryField.DataSource + "\"") + HtmlTagsHelper.CreateCloseDiv();
                }
                else
                {
                    tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
                }
            }
            if (Configuration.Settings.EnableOfficeControls())
            {
                sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                      HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null) + LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                      tmp2,
                      tmp,
                      HtmlTagsHelper.CreateCloseDiv());
            }
            else
            {
                tmp = "<i class='glyphicon glyphicon-user'></i>" + tmp;
                tmp2 = HtmlTagsHelper.CreateOpenDiv("bs-ext-inner-addon bs-ext-left-addon " + requiredClass, null);

                sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                      HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null) + LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                      tmp2,
                      tmp,
                      HtmlTagsHelper.CreateCloseDiv() + HtmlTagsHelper.CreateCloseDiv());
            }
            return sb.ToString();
        }

        protected override string RenderControlSpecializedLookup(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string dialogHtml = null;

            attributes.Add("class", genericFormControlClass);
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {

                tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
                //tmp = HtmlTagsHelper.CreateOpenDiv("input-group", null) + tmp + string.Format("<span class='input-group-btn'><button class='btn btn-default' value='Search' id='btn{0}' data-field='{0}' data-target='#dialog{0}' data-toggle='modal'>Search</button></span>", fieldName) + HtmlTagsHelper.CreateCloseDiv();
                tmp = HtmlTagsHelper.CreateOpenDiv("input-group", null) + tmp + string.Format("<span class='input-group-btn'><button class='btn btn-default' value='Search' id='btn{0}' data-field='{0}' >Search</button></span>", fieldName) + HtmlTagsHelper.CreateCloseDiv();

                Dictionary<string, object> attr = new Dictionary<string, object>();
                attr.Add("class", "lookup-hidden");
                tmp = tmp + InputExtensions.Hidden(htmlHelper, "hidden" + fieldName, null, attr).ToString();

                dialogHtml = string.Format("<div class=\"modal fade\" id=\"dialog{0}\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\">" +
                    "<div class=\"modal-dialog\" role=\"document\">" +
                    "  <div class=\"modal-content\">" +
                    "    <div class=\"modal-header\">" +
                    "      <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                    "      <h4 class=\"modal-title\" >{1}</h4>" +
                    "    </div>" +
                    "    <div class=\"modal-body\" id=\"dialogBody{0}\">" +
                    "<div class=\"input-group\">" +
                    "<input type=\"text\" id=\"txtPopupSearch{0}\" data-apiurl=\"{2}\" class=\"" + genericFormControlClass + "\">" +
                    "<span class='input-group-btn'><button class='btn btn-default' value='Search' id='btnPopupSearch' data-field='{0}'>Search</button></span>" +
                    "</div>" +
                    "    </div>" +
                    "    <div class=\"modal-footer\">" +
                    "      <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button>" +
                    "    </div>" +
                    "  </div>" +
                    "</div>" +
                    "</div>", fieldName, fieldTitle, categoryField.DataSource);
            }

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, "data-role='input'"),
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());
            sb.Append(dialogHtml);
            return sb.ToString();
        }

        protected override string RenderControlSpecializedFileUpload(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            Dictionary<string, object> dynamicContentAttributes = new Dictionary<string, object>() { { "class", "multipleupload" }, { "data-apiurl", categoryField.DataSource }, { "data-apifilter", "" }, { "data-fieldvalue", categoryField.FieldExtension1 }, { "data-fieldtext", categoryField.FieldExtension2 } };
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;

            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            object value = modelMetadata.Model;
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(dynamicContentAttributes, readonlyAttributes);
                //tmp = htmlHelper.TextBox(fieldName, null, readonlyAttributes).ToString();
                tmp = string.Format("<div id=\"file{0}\" {1}></div>", fieldName, DictionaryToString(readonlyAttributes));
            }
            else if (state == Enums.FieldStates.Editable)
            {
                if (FieldIsMandatory(categoryField, state, formState))
                {
                    attributes = GetRequiredAttributes(fieldTitle);
                }
                MergeDictionaries(dynamicContentAttributes, attributes);

                // <div id="multipleupload" class="multipleupload" data-posturl="/Requests/UploadFile?@this.Request.QueryString.ToString()" data-formdata='{ "fuuid" : "@Guid.NewGuid()" }' data-allowmultipleupload="true" data-allowdragdrop="true"><div id="multipleupload-msg"></div></div>
                string postUrl = categoryField.FieldExtension4;
                string formData = categoryField.FieldExtension5;
                string extraData = categoryField.FieldExtension6;
                if (!string.IsNullOrEmpty(postUrl))
                    postUrl = postUrl.Replace("[[QUERY_STRING]]", htmlHelper.ViewContext.HttpContext.Request.QueryString.ToString());
                if (string.IsNullOrEmpty(extraData) || extraData.Equals("false", StringComparison.InvariantCultureIgnoreCase))
                    extraData = "data-allowmulti=\"false\"";
                else if (extraData.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    extraData = "data-allowmulti=\"true\"";

                string sessionId = null;
                if (value != null)
                    sessionId = value.ToString();
                else
                    sessionId = Guid.NewGuid().ToString();
                if (!string.IsNullOrEmpty(formData))
                    formData = formData.Replace("[[SESSION_ID]]", sessionId);

                tmp = string.Format("<div id=\"file{0}\" data-posturl=\"{1}\" data-formdata='{2}' data-allowdragdrop=\"true\" data-dragdropWidth=\"100%\" {3} {4}><div id=\"file{0}-msg\" ></div></div>", fieldName, postUrl, formData, extraData, DictionaryToString(attributes));

                Dictionary<string, object> attr = new Dictionary<string, object>();
                attr.Add("class", "fileupload-hidden");
                tmp = tmp + InputExtensions.Hidden(htmlHelper, "hidden" + fieldName, sessionId, attr).ToString();
                tmp = tmp + InputExtensions.Hidden(htmlHelper, "hiddenData" + fieldName, null, null).ToString();

            }
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlWrapperClass + " " + requiredClass, null),
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }
    }

}