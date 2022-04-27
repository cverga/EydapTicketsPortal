using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DM.App.Library.Models;

namespace DM.App.Library.Core
{
    public static class FieldValidator
    {
        public static void SetDefaultValues(object model, IEnumerable<Models.Interfaces.ICategoryField> fields)
        {
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();

            foreach (Models.Interfaces.ICategoryField field in fields)
            {
                if (!string.IsNullOrEmpty(field.DefaultValue))
                {
                    IEnumerable<System.Reflection.PropertyInfo> propsList = properties.Where(e => e.Name == field.InternalName);
                    System.Reflection.PropertyInfo property = propsList.FirstOrDefault();
                    if (property != null)
                    {
                        object defaultValue = null;
                        if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                            defaultValue = Convert.ToInt32(field.DefaultValue);
                        else if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                            defaultValue = Convert.ToDouble(field.DefaultValue);
                        else if (property.PropertyType == typeof(float) || property.PropertyType == typeof(float?))
                            defaultValue = Convert.ToDouble(field.DefaultValue);
                        else if (property.PropertyType == typeof(string))
                            defaultValue = field.DefaultValue;
                        else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                            defaultValue = Convert.ToBoolean(field.DefaultValue);
                        else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                            defaultValue = Convert.ToDateTime(field.DefaultValue);

                        if (defaultValue != null)
                            property.SetValue(model, defaultValue, null);
                    }
                }
            }
        }

        public static void AssignValues(object modelFromDB, object model, IEnumerable<Models.Interfaces.ICategoryField> fields, Core.Enums.FormStates formState, bool ignoreNulls, System.Web.HttpServerUtilityBase server)
        {
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();

            IEnumerable<Models.Interfaces.ICategoryField> fieldsForState = null;
            if (formState == Enums.FormStates.Edit)
                fieldsForState = fields.Where(e => e.FieldStateInEditForm == (int)Core.Enums.FieldStates.Editable);
            else if (formState == Enums.FormStates.New)
                fieldsForState = fields.Where(e => e.FieldStateInNewForm == (int)Core.Enums.FieldStates.Editable);

            foreach (Models.Interfaces.ICategoryField field in fieldsForState)
            {
                IEnumerable<System.Reflection.PropertyInfo> propsList = properties.Where(e => e.Name == field.InternalName);
                System.Reflection.PropertyInfo property = propsList.FirstOrDefault();

                if (property != null)
                {
                    var propval = property.GetValue(model, null);
                    if (ignoreNulls || propval != null)
                    {
                        if (propval != null)
                        {
                            if (server != null)
                            {
                                object propval2 = EscapeRichText(model, property, field, formState, server);
                                if (propval2 != null)
                                    propval = propval2;
                            }
                        }
                        property.SetValue(modelFromDB, propval, null);
                    }
                }
            }
        }

        public static void AssignValuesCopySimilarTypes(object modelFromDB, object model, bool ignoreNulls)
        {
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();
            System.Reflection.PropertyInfo[] propertiesFromDB = modelFromDB.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                //IEnumerable<System.Reflection.PropertyInfo> propsList = properties.Where(e => e.Name == field.InternalName);
                //System.Reflection.PropertyInfo property = propsList.FirstOrDefault();

                if (property != null)
                {
                    var propval = property.GetValue(model, null);
                    if (ignoreNulls || propval != null)
                    {
                        IEnumerable<System.Reflection.PropertyInfo> propsListFromDB = propertiesFromDB.Where(e => e.Name == property.Name);
                        System.Reflection.PropertyInfo propertyFromDB = propsListFromDB.FirstOrDefault();
                        if (propertyFromDB != null)
                        {
                            propertyFromDB.SetValue(modelFromDB, propval, null);
                        }
                    }
                }
            }
        }

        private static object EscapeRichText(object model, System.Reflection.PropertyInfo property, Models.Interfaces.ICategoryField field, Core.Enums.FormStates formState, System.Web.HttpServerUtilityBase server)
        {
            object value = null;
            string control = "";

            if (formState == Enums.FormStates.Edit)
                control = field.ControlTypeInEditForm;
            else if (formState == Enums.FormStates.New)
                control = field.ControlTypeInNewForm;

            // Escape input text for all text fields
            if (control == HtmlLibHelper.CONTROL_TEXTAREA || control == HtmlLibHelper.CONTROL_TEXTBOX)
            {
                var propval = property.GetValue(model, null);

                //value = server.HtmlDecode(propval as string);
                if (propval is string)
                    value = server.HtmlDecode(Microsoft.Security.Application.Sanitizer.GetSafeHtmlFragment(propval as string));
            }
            return value;
        }

        public static void EscapeRichText(object model, IEnumerable<Models.Interfaces.ICategoryField> fields, Core.Enums.FormStates formState, System.Web.HttpServerUtilityBase server)
        {
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();

            IEnumerable<Models.Interfaces.ICategoryField> fieldsForState = null;
            if (formState == Enums.FormStates.Edit)
                fieldsForState = fields.Where(e => e.FieldStateInEditForm == (int)Core.Enums.FieldStates.Editable);
            else if (formState == Enums.FormStates.New)
                fieldsForState = fields.Where(e => e.FieldStateInNewForm == (int)Core.Enums.FieldStates.Editable);

            foreach (Models.Interfaces.ICategoryField field in fieldsForState)
            {
                IEnumerable<System.Reflection.PropertyInfo> propsList = properties.Where(e => e.Name == field.InternalName);
                System.Reflection.PropertyInfo property = propsList.FirstOrDefault();

                if (property != null)
                {
                    var propval = property.GetValue(model, null);
                    if (propval != null)
                    {
                        propval = EscapeRichText(model, property, field, formState, server);
                        if (propval != null)
                            property.SetValue(model, propval, null);
                    }
                }
            }
        }

        public static string EscapeRichText(string content, System.Web.HttpServerUtilityBase server)
        {
            if (!string.IsNullOrEmpty(content) && server != null)
            {
                return server.HtmlDecode(Microsoft.Security.Application.Sanitizer.GetSafeHtmlFragment(content));
            }
            return content;
        }

        public static void SetMultiSelectValues(HttpRequestBase request, object model, IEnumerable<Models.Interfaces.ICategoryField> fields, Core.Enums.FormStates formState)
        {
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties();

            IEnumerable<Models.Interfaces.ICategoryField> fieldsForState = null;
            if (formState == Enums.FormStates.Edit)
                fieldsForState = fields.Where(e => e.FieldExtension4 == "MULTISELECT" && e.FieldStateInEditForm == (int)Core.Enums.FieldStates.Editable);
            else if (formState == Enums.FormStates.New)
                fieldsForState = fields.Where(e => e.FieldExtension4 == "MULTISELECT" && e.FieldStateInNewForm == (int)Core.Enums.FieldStates.Editable);

            if (fieldsForState != null)
            {
                foreach (Models.Interfaces.ICategoryField field in fieldsForState)
                {
                    IEnumerable<System.Reflection.PropertyInfo> propsList = properties.Where(e => e.Name == field.InternalName);
                    System.Reflection.PropertyInfo property = propsList.FirstOrDefault();

                    if (property != null)
                    {
                        var propval = request.Form[field.InternalName + "_0"];
                        if (propval == null)
                            propval = request.Form[field.InternalName];
                        if (propval != null)
                        {
                            property.SetValue(model, propval, null);
                        }
                    }

                }
            }
        }
    }
}