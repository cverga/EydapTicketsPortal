using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc.Html;
using DM.App.Library.Models;
using DevExpress.Web.Mvc;
using DevExpress.Web.Mvc.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Web.Mvc;

namespace DM.App.Library.Core
{
    public abstract class HtmlLibHelper
    {
        public const string CONTROL_TEXTBOX = "textbox";
        public const string CONTROL_CHECKBOX = "checkbox";
        public const string CONTROL_CHECKBOXLIST = "checkboxlist";
        public const string CONTROL_RADIOBOX = "radiobox";
        public const string CONTROL_SWITCHER = "switcher";
        public const string CONTROL_DATETIME = "datetime";
        public const string CONTROL_TIME = "time";
        public const string CONTROL_DROPDOWNLIST = "dropdownlist";
        public const string CONTROL_DROPDOWNLISTMULTI = "dropdownlist-multi";
        public const string CONTROL_HIERARCHY = "hierarchy";
        public const string CONTROL_TEXTAREA = "textarea";
        public const string CONTROL_PERSON = "person";
        public const string CONTROL_LOOKUP = "lookup";
        public const string CONTROL_FILEUPLOAD = "fileupload";

        protected Dictionary<string, object> readonlyAttributes = new Dictionary<string, object>() { { "class", "readonly" }, { "readonly", "" } };
        protected Dictionary<string, object> disabledAttributes = new Dictionary<string, object>() { { "class", "readonly" }, { "disabled", "" } };
        protected string requiredIndicator = "";
        protected string requiredClass = "";
        protected string genericFormControlWrapperClass = "";
        protected string genericFormControlClass = "input-control text full-size";
        //protected string datetimeFormat1 = Configuration.Formatting.DateFormat();
        //protected string datetimeFormat2 = Configuration.Formatting.DateFormatForBinding();

        protected List<UIExtensions> uiExtensions = new List<UIExtensions>();
        public List<UIExtensions> Extensions { get { return uiExtensions; } }
        public bool UseEntityNamePrefix { get; set; }

        //private static IEnumerable<Models.Interfaces.IField> _fieldsDefinitions = null;
        //public static IEnumerable<Models.Interfaces.IField> FieldsDefinitions
        //{
        //    get
        //    {
        //        if (_fieldsDefinitions == null)
        //        {
        //            // Get fields from DB
        //            _fieldsDefinitions = ExternalDB.GetFields();
        //        }

        //        return _fieldsDefinitions;
        //    }
        //    set
        //    {
        //        _fieldsDefinitions = value;
        //    }
        //}

        virtual public void RegisterUiExtension(UIExtensions extension)
        {
            if (!uiExtensions.Contains(extension))
                uiExtensions.Add(extension);
        }

        virtual public IHtmlString CreateControlForField(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldPrefix, string fieldTitle, string controlType, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            IHtmlString htmlString = null;
            StringBuilder sb = new StringBuilder();

            //string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldName);
            var metadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewData);
            //var value = string.Format("", metadata.Model);

            //htmlHelper.ViewContext.FormContext.FieldValidators
            //ValidationExtensions.Validate(htmlHelper, fieldName);
            System.Web.Mvc.FieldValidationMetadata validationMetadata = ApplyFieldValidationMetadata(htmlHelper, fieldName);

            if (state == Enums.FieldStates.Editable)
            {
                if (formState == Enums.FormStates.New && categoryField.IsMandatoryInNewForm)
                    requiredIndicator = "<span style='color: red; margin-left: 5px;'>*</span>";
                //requiredClass = "error";
                else if (formState == Enums.FormStates.Edit && categoryField.IsMandatoryInEditForm)
                    requiredIndicator = "<span style='color: red; margin-left: 5px;'>*</span>";
                else
                    requiredIndicator = "";
                //requiredClass = "error";
            }
            switch (controlType)
            {
                case CONTROL_CHECKBOX:
                    {
                        sb.Append(this.RenderControlCheckbox(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_CHECKBOXLIST:
                    {
                        sb.Append(this.RenderControlCheckboxList(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_RADIOBOX:
                    //sb.Append("input-control radio");
                    break;
                case CONTROL_SWITCHER:
                    sb.Append(this.RenderControlSwitcher(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    break;
                case CONTROL_DATETIME:
                    {
                        sb.Append(this.RenderControlDatetimePicker(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_DROPDOWNLIST:
                case CONTROL_DROPDOWNLISTMULTI:
                    {
                        sb.Append(this.RenderControlDropdownList(htmlHelper, fieldName, fieldTitle, state, formState, categoryField, (controlType == CONTROL_DROPDOWNLISTMULTI)));
                    }
                    break;
                case CONTROL_HIERARCHY:
                    {
                        sb.Append(this.RenderControlSpecializedHierarchy(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_TIME:
                    {
                        sb.Append(this.RenderControlTime(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_TEXTAREA:
                    {
                        sb.Append(this.RenderControlTextArea(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_PERSON:
                    {
                        sb.Append(this.RenderControlSpecializedPerson(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_LOOKUP:
                    {
                        sb.Append(this.RenderControlSpecializedLookup(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                case CONTROL_FILEUPLOAD:
                    {
                        sb.Append(this.RenderControlSpecializedFileUpload(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
                default:
                    {
                        sb.Append(this.RenderControlTextbox(htmlHelper, fieldName, fieldTitle, state, formState, categoryField));
                    }
                    break;
            }
            if (sb.Length > 0)
                htmlString = new HtmlString(sb.ToString());

            return htmlString;
        }

        virtual protected Dictionary<string, object> GetRequiredAttributes(string fieldName)
        {
            return new Dictionary<string, object>() { { "required", "required" }, { "data-val", "true" }, { "data-val-required", "Field " + fieldName + " is required." } };
        }

        virtual protected void MergeDictionaries(Dictionary<string, object> source, Dictionary<string, object> target)
        {
            if (target != null)
            {
                foreach (KeyValuePair<string, object> kvp in source)
                {
                    if (!target.ContainsKey(kvp.Key))
                        target.Add(kvp.Key, kvp.Value);
                    else
                    {
                        if (kvp.Value != null)
                            target[kvp.Key] = target[kvp.Key].ToString() + " " + kvp.Value.ToString();
                    }
                }
            }
        }

        virtual protected string DictionaryToString(Dictionary<string, object> source)
        {
            string value = "";
            foreach (KeyValuePair<string, object> item in source)
            {
                value += string.Format(" {0}='{1}'", item.Key, item.Value);
            }
            return value;
        }

        virtual protected bool FieldIsMandatory(Models.Interfaces.ICategoryField field, Enums.FieldStates state, Enums.FormStates formState)
        {
            if (state == Enums.FieldStates.Editable)
            {
                if (formState == Enums.FormStates.Edit)
                    return field.IsMandatoryInEditForm;
                else if (formState == Enums.FormStates.New)
                    return field.IsMandatoryInNewForm;
            }
            return false;
        }

        virtual protected string GetFormat(object value, string formatString, Enums.FieldStates state, Models.Interfaces.ICategoryField categoryField)
        {
            string format = null;
            if (value != null)
            {
                if (value is DateTime)
                {
                    if (state == Enums.FieldStates.Readonly)
                        format = Configuration.Formatting.DateFormat();
                    else if (state == Enums.FieldStates.Editable)
                        format = Configuration.Formatting.DateFormatForBinding();
                    if (!string.IsNullOrEmpty(formatString))
                        format = formatString;
                }
            }
            return format;
        }

        virtual protected string GetFormattedValue(object value, string formatString, Enums.FieldStates state, Models.Interfaces.ICategoryField categoryField)
        {
            string format = GetFormat(value, formatString, state, categoryField);
            string formattedValue = null;
            if (value != null)
            {
                if (value is DateTime)
                    formattedValue = ((DateTime)value).ToString(format);
                else
                    formattedValue = value.ToString();
            }
            return formattedValue;
        }

        virtual protected string RenderControlTextbox(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            object value = modelMetadata.Model;
            if (state == Enums.FieldStates.Readonly)
            {
                value = GetFormattedValue(value, categoryField.FieldExtension1, state, categoryField);
                tmp = htmlHelper.TextBox(fieldName, value, null, readonlyAttributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                if (FieldIsMandatory(categoryField, state, formState))
                {
                    attributes = GetRequiredAttributes(fieldTitle);
                }
                Models.Interfaces.IField field = categoryField.FieldsDefinitions.Where(e => e.Entity == categoryField.Entity && e.FieldName == categoryField.InternalName).FirstOrDefault();
                if (field != null && field.Size > 0)
                    attributes.Add("maxlength", field.Size);

                string format = GetFormat(value, categoryField.FieldExtension2, state, categoryField);
                tmp = htmlHelper.TextBox(fieldName, null, format, attributes).ToString();
                if (!string.IsNullOrEmpty(categoryField.ValidationJSScript))
                    tmp = tmp.Replace("data-val=\"true\"", "");
            }
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlClass + " " + requiredClass, null),
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());

            return sb.ToString();
        }

        virtual protected string RenderControlTime(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            string lExit = RenderControlTextbox(htmlHelper, fieldName, fieldTitle, state, formState, categoryField);

            if (state == Enums.FieldStates.Editable)
            {
                lExit = lExit.Replace("<input ", "<input class=\"timepicker\"");
            }

            return lExit;
        }

        virtual protected string RenderControlTextArea(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;

            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            object value = modelMetadata.Model;
            if (state == Enums.FieldStates.Readonly)
            {
                //tmp = htmlHelper.TextArea(fieldName, null, readonlyAttributes).ToString();
                attributes = new Dictionary<string, object>(readonlyAttributes);
                attributes.Add("disabled", "true");
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
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlClass.Replace("text", "textarea") + " " + requiredClass, null),
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());

            return sb.ToString();
        }

        virtual protected string RenderControlDatetimePicker(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            //string format = datetimeFormat1;
            string tmp = null;
            string tmp2 = null;
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            object value = modelMetadata.Model;
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                value = GetFormattedValue(value, categoryField.FieldExtension1, state, categoryField);
                tmp = InputExtensions.TextBox(htmlHelper, fieldName, value, null, attributes).ToString();
                tmp2 = HtmlTagsHelper.CreateOpenDiv(genericFormControlClass + " ", null);
            }
            else if (state == Enums.FieldStates.Editable)
            {
                if (FieldIsMandatory(categoryField, state, formState))
                {
                    MergeDictionaries(GetRequiredAttributes(fieldTitle), attributes);
                }
                string format = GetFormat(value, categoryField.FieldExtension2, state, categoryField);
                tmp = InputExtensions.TextBox(htmlHelper, fieldName, null, format, attributes).ToString() +
                    "<button class=\"button\"><span class=\"mif-calendar\"></span></button>";
                tmp2 = HtmlTagsHelper.CreateOpenDiv(genericFormControlClass + " " + requiredClass, "data-role=\"datepicker\" data-other-days=\"true\" data-week-start=\"1\" data-format=\"" + Configuration.Formatting.DateFormatForHtml() + "\" data-locale=\"en\"");
            }
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  tmp2,
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        virtual protected string RenderControlCheckbox(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
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
                 LabelExtensions.Label(htmlHelper, fieldName, " ").ToString(),
                 HtmlTagsHelper.CreateOpenDiv("input-control full-size ", null) + HtmlTagsHelper.CreateOpenTag("label", "class=\"input-control checkbox\""),
                 tmp,
                 HtmlTagsHelper.CreateCloseTag("label") + HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        virtual protected string RenderControlCheckboxList(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            Dictionary<string, object> dynamicContentAttributes = new Dictionary<string, object>() { { "class", "dynamic-content" }, { "data-apiurl", categoryField.DataSource }, { "data-apifilter", "" }, { "data-fieldvalue", categoryField.FieldExtension1 }, { "data-fieldtext", categoryField.FieldExtension2 } };
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;
            string tmpName = fieldName;
            string readonlyState = "";
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
                                sbTemp.Append(HtmlTagsHelper.CreateOpenTag("label", "class=\"input-control checkbox\""));
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
                 LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString(),
                 HtmlTagsHelper.CreateOpenDiv(" full-size ", null),
                 tmp,
                 tmp2,
                 HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        virtual protected string RenderControlSwitcher(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            string tmp = null;

            bool checkedValue = false;
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(fieldName, htmlHelper.ViewContext.ViewData);
            if (modelMetadata.Model != null)
            {
                string value = modelMetadata.Model.ToString();
                checkedValue = (value.Equals("true", StringComparison.InvariantCultureIgnoreCase));
            }
            if (state == Enums.FieldStates.Readonly)
            {
                tmp = InputExtensions.CheckBox(htmlHelper, fieldName, checkedValue, disabledAttributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                tmp = InputExtensions.CheckBox(htmlHelper, fieldName).ToString();
            }
            tmp = tmp + string.Format("<span class=\"check\"></span>");

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                 LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString(),
                 HtmlTagsHelper.CreateOpenDiv("input-control full-size ", null) + HtmlTagsHelper.CreateOpenTag("label", "class=\"switch-original\""),
                 tmp,
                 HtmlTagsHelper.CreateCloseTag("label") + HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        virtual protected string FixMultiSelectValues(Models.Interfaces.ICategoryField categoryField, string html, List<System.Web.Mvc.SelectListItem> selectList)
        {
            string tmp = string.Copy(html);
            foreach (System.Web.Mvc.SelectListItem item in selectList)
            {
                if (item.Selected)
                {
                    tmp = tmp.Replace("option value=\"" + item.Value + "\"", "option value=\"" + item.Value + "\" selected=\"selected\"");
                }
            }

            return tmp;
        }

        virtual protected List<System.Web.Mvc.SelectListItem> GetListItems(Models.Interfaces.ICategoryField categoryField, string[] values, bool useDefaultValue)
        {
            List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();
            if (string.IsNullOrEmpty(categoryField.DataSource))
                categoryField.DataSource = categoryField.AllowedValues;
            if (!string.IsNullOrEmpty(categoryField.DataSource))
            {
                string[] arr = categoryField.DataSource.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr != null && arr.Length > 0)
                {
                    if (useDefaultValue && string.IsNullOrEmpty(categoryField.DefaultValue))
                        items.Add(new System.Web.Mvc.SelectListItem() { Text = "", Value = "-1" });
                    for (int i = 0; i < arr.Length; i++)
                    {
                        bool selected = false;
                        if (useDefaultValue)
                            selected = (categoryField.DefaultValue == arr[i]);
                        if (values != null)
                            selected = values.Contains(arr[i]);
                        items.Add(new System.Web.Mvc.SelectListItem() { Text = arr[i], Value = arr[i], Selected = selected });
                    }
                }
            }
            return items;
        }

        virtual protected List<System.Web.Mvc.SelectListItem> GetListItemsDb(Models.Interfaces.ICategoryField categoryField, string[] values, bool useDefaultValue)
        {
            List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();
            if (!string.IsNullOrEmpty(categoryField.DataSource))
            {
                //IEnumerable<Models.DTO.LookupItem> results = ExternalDB.GetLookupKVPs(categoryField.DataSource);
                IEnumerable<Models.Interfaces.ILookupItemDTO> results = categoryField.GetLookupKVPs();

                if (results != null && results.Count() > 0)
                {
                    if (useDefaultValue && string.IsNullOrEmpty(categoryField.DefaultValue))
                        items.Add(new System.Web.Mvc.SelectListItem() { Text = "", Value = "-1" });
                    foreach (Models.Interfaces.ILookupItemDTO item in results)
                    {
                        string value = "";
                        if (item.ValueInt.HasValue)
                            value = item.ValueInt.Value.ToString();
                        else if (!string.IsNullOrEmpty(item.ValueString))
                            value = item.ValueString;
                        else
                        {
                            if (categoryField.FieldExtension1 == "DisplayText")
                            {
                                value = item.DisplayText;
                            }
                        }
                        bool selected = false;
                        if (useDefaultValue)
                        {
                            //if (item.ValueInt.HasValue)
                            //    selected = (categoryField.DefaultValue == item.ValueInt.Value.ToString());
                            //else
                            //    selected = (categoryField.DefaultValue == item.ValueString);
                            selected = (categoryField.DefaultValue == value);
                        }
                        if (values != null)
                        {
                            //if (item.ValueInt.HasValue)
                            //    selected = values.Contains(item.ValueInt.ToString());
                            //else
                            //    selected = values.Contains(item.ValueString);
                            selected = values.Contains(value);
                        }
                        //if (item.ValueInt.HasValue)
                        //    items.Add(new System.Web.Mvc.SelectListItem() { Text = item.DisplayText, Value = item.ValueInt.ToString(), Selected = selected, Disabled = item.Disabled });
                        //else
                        //    items.Add(new System.Web.Mvc.SelectListItem() { Text = item.DisplayText, Value = item.ValueString, Selected = selected, Disabled = item.Disabled });
                        items.Add(new System.Web.Mvc.SelectListItem() { Text = item.DisplayText, Value = value, Selected = selected, Disabled = item.Disabled });
                    }
                }
            }
            return items;
        }

        virtual protected List<string> GetListItemsTextDb(Models.Interfaces.ICategoryField categoryField, string[] ids)
        {
            List<string> values = new List<string>(ids);
            if (!string.IsNullOrEmpty(categoryField.DataSource))
            {
                //IEnumerable<Models.DTO.LookupItem> results = ExternalDB.GetLookupKVPs(categoryField.DataSource);
                IEnumerable<Models.Interfaces.ILookupItemDTO> results = categoryField.GetLookupKVPs();

                if (results != null && results.Count() > 0)
                {
                    values = new List<string>();
                    foreach (Models.Interfaces.ILookupItemDTO item in results)
                    {
                        foreach (string val in ids)
                        {
                            if (val.Equals(item.ValueString) || (item.ValueInt > 0 && val.Equals(item.ValueInt.ToString())))
                                values.Add(item.DisplayText);
                        }
                    }
                }
            }
            return values;
        }

        virtual protected string RenderControlDropdownList(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField, bool multiSelect)
        {
            Dictionary<string, object> dynamicContentAttributes = new Dictionary<string, object>() { { "class", "dynamic-content" }, { "data-apiurl", categoryField.DataSource }, { "data-apifilter", categoryField.FieldExtension5 }, { "data-fieldvalue", categoryField.FieldExtension1 }, { "data-fieldtext", categoryField.FieldExtension2 } };
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;
            string tmpName = fieldName;
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
                                List<string> values = GetListItemsTextDb(categoryField, modelMetadata.Model.ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                                value = string.Join(", ", values.ToArray());
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

                            tmp = string.Format("<select id='{0}' name='{0}' {1}></select>", tmpName, DictionaryToString(attributes));

                            Dictionary<string, object> attr = new Dictionary<string, object>();
                            attr.Add("class", "dynamic-content-hidden");
                            tmp2 = InputExtensions.Hidden(htmlHelper, fieldName, null, attr).ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
            string attributesDiv = "";
            if (uiExtensions.Contains(UIExtensions.Select2) && state == Enums.FieldStates.Editable)
                attributesDiv = string.Format(" data-role='select'");
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}", Environment.NewLine,
                  LabelExtensions.Label(htmlHelper, tmpName, fieldTitle).ToString() + requiredIndicator,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlClass + " " + requiredClass, attributesDiv),
                  tmp,
                  tmp2,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        virtual protected string RenderControlSpecializedHierarchy(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            Dictionary<string, object> hierarchyAttributes = new Dictionary<string, object>() { { "class", "hierarchy hierarchy_" + categoryField.FieldExtensionId + " full-size" }, { "data-hierarchylevel", categoryField.FieldExtensionId }, { "data-apiurl", "/api/" + categoryField.DataSource }, { "data-apifilter", "?$filter=" + categoryField.FieldExtension1 + " eq [PARENT_ID]" }, { "data-hierarchyentity", fieldName } };
            Dictionary<string, object> hierarchyHiddenAttributes = new Dictionary<string, object>() { { "class", "hierarchy-hidden" }, { "data-apiurl", "/api/" + categoryField.DataSource }, { "data-apifilter", "/[ID]" }, { "data-hierarchyentity", fieldName } };
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string tmp2 = null;
            string tmpName = string.Format("{0}_{1}", fieldName, categoryField.FieldExtensionId);
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                MergeDictionaries(hierarchyAttributes, attributes);
                attributes.Add("placeholder", "...");

                tmp = InputExtensions.TextBox(htmlHelper, tmpName, null, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {
                List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();

                tmp = SelectExtensions.DropDownList(htmlHelper, tmpName, items, hierarchyAttributes).ToString();
            }
            if (categoryField.FieldExtensionId == 0)
                tmp2 = InputExtensions.Hidden(htmlHelper, fieldName, null, hierarchyHiddenAttributes).ToString();

            string attributesDiv = "";
            if (uiExtensions.Contains(UIExtensions.Select2) && state == Enums.FieldStates.Editable)
                attributesDiv = string.Format(" data-role='select'");

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}", Environment.NewLine,
                  LabelExtensions.Label(htmlHelper, tmpName, fieldTitle).ToString() + requiredIndicator,
                  HtmlTagsHelper.CreateOpenDiv("input-control full-size " + requiredClass, attributesDiv),
                  tmp,
                  tmp2,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        virtual protected string RenderControlSpecializedPerson(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {

                tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
            }
            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlClass + " " + requiredClass, null),
                  "<span class='mif-user prepend-icon'></span>" + tmp,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        virtual protected string RenderControlSpecializedLookup(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> attributes = new Dictionary<string, object>();
            string tmp = null;
            string dialogHtml = null;

            if (state == Enums.FieldStates.Readonly)
            {
                MergeDictionaries(readonlyAttributes, attributes);
                tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
            }
            else if (state == Enums.FieldStates.Editable)
            {

                tmp = htmlHelper.TextBox(fieldName, null, attributes).ToString();
                tmp = tmp + string.Format("<button class='button' id='btn{0}' data-field='{0}'><span class='mif-search'></span></button>", fieldName);

                Dictionary<string, object> attr = new Dictionary<string, object>();
                attr.Add("class", "lookup-hidden");
                tmp = tmp + InputExtensions.Hidden(htmlHelper, "hidden" + fieldName, null, attr).ToString();

                dialogHtml = string.Format("<div data-role=\"dialog\" id=\"dialog{0}\" data-close-button=\"true\" class=\"padding20\" data-background=\"bg-grayLighter\" data-color=\"fg-gray\" data-overlay=\"true\" style=\"min-width: 400px;\">" +
                    "<h3>{1}</h3>" +
                    "<div class=\"{3}\">" +
                    "<input type=\"text\" id=\"txtPopupSearch{0}\" data-apiurl=\"{2}\">" +
                    "<button id='btnPopupSearch' class='button' data-field='{0}'><span class='mif-search'></span></button>" +
                    "</div>" +
                    "</div>", fieldName, fieldTitle, categoryField.DataSource, genericFormControlClass);
            }

            sb.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}", Environment.NewLine,
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlClass + " " + requiredClass, "data-role='input'"),
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());
            sb.Append(dialogHtml);
            return sb.ToString();
        }

        virtual protected string RenderControlSpecializedFileUpload(System.Web.Mvc.HtmlHelper htmlHelper, string fieldName, string fieldTitle, Enums.FieldStates state, Enums.FormStates formState, Models.Interfaces.ICategoryField categoryField)
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
                  LabelExtensions.Label(htmlHelper, fieldName, fieldTitle).ToString() + requiredIndicator,
                  HtmlTagsHelper.CreateOpenDiv(genericFormControlClass + " " + requiredClass, null),
                  tmp,
                  HtmlTagsHelper.CreateCloseDiv());
            return sb.ToString();
        }

        protected System.Web.Mvc.FieldValidationMetadata ApplyFieldValidationMetadata(System.Web.Mvc.HtmlHelper htmlHelper, string modelName)
        {
            System.Web.Mvc.FormContext formContext = htmlHelper.ViewContext.FormContext;
            System.Web.Mvc.ModelMetadata modelMetadata = System.Web.Mvc.ModelMetadata.FromStringExpression(modelName, htmlHelper.ViewContext.ViewData);

            System.Web.Mvc.FieldValidationMetadata validationMetadataForField = formContext.GetValidationMetadataForField(modelName, true);
            IEnumerable<System.Web.Mvc.ModelValidator> validators = System.Web.Mvc.ModelValidatorProviders.Providers.GetValidators(modelMetadata, htmlHelper.ViewContext);
            foreach (System.Web.Mvc.ModelClientValidationRule current in validators.SelectMany((System.Web.Mvc.ModelValidator v) => v.GetClientValidationRules()))
            {
                validationMetadataForField.ValidationRules.Add(current);
            }
            return validationMetadataForField;
        }
    }

    public class HtmlLibMetroHelper : HtmlLibHelper
    {
    }

}