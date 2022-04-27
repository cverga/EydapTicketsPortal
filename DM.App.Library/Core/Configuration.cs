using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DM.App.Library.Core
{
    public class Configuration
    {
        public class Settings
        {
            public static string UILibrary()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:UILibrary");
                return tmp;
            }

            public static string UILibraryCss()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:UILibrary:Css");
                return tmp;
            }

            public static string[] UILibraryAlternateCss()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:UILibrary:AlternateCss");
                if (!string.IsNullOrEmpty(tmp))
                {
                    string[] arr = tmp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    return arr;
                }
                else
                    return new string[] {};
            }

            public static string UILibraryTheme()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:UILibrary:Theme");
                return tmp;
            }

            public static string[] UILibraryAllowedLibs()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:UILibrary:AllowedLibs");
                if (!string.IsNullOrEmpty(tmp))
                {
                    string[] arr = tmp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    return arr;
                }
                else
                    return new string[] { "Bootstrap" };
            }

            public static string[] UILibraryAllowedThemes()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:UILibrary:AllowedThemes");
                if (!string.IsNullOrEmpty(tmp))
                {
                    string[] arr = tmp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    return arr;
                }
                else
                    return new string[] { "Classic" };
            }

            public static bool UseEntityNamePrefix()
            {
                return (UseEntityNamePrefixValue() == "1");
            }

            public static string UseEntityNamePrefixValue()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Config:UseEntityNamePrefix");
                return tmp;
            }

            public static bool UseDocumentSets()
            {
                return (UseDocumentSetsValue() == "1");
            }

            public static string UseDocumentSetsValue()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Config:UseDocumentSets");
                return tmp;
            }

            public static bool EnableSelect2()
            {
                return (EnableSelect2Value() == "1");
            }

            public static string EnableSelect2Value()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Extend:Select2");
                return tmp;
            }

            public static bool EnableCkeditor()
            {
                return (EnableCkeditorValue() == "1");
            }

            public static string EnableCkeditorValue()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Extend:Ckeditor");
                return tmp;
            }

            public static bool EnableJQueryUpload()
            {
                return (EnableJQueryUploadValue() == "1");
            }

            public static string EnableJQueryUploadValue()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Extend:JQueryUpload");
                return tmp;
            }

            public static bool EnableJqDataTables()
            {
                return (EnableJqDataTablesValue() == "1");
            }

            public static string EnableJqDataTablesValue()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Extend:JqDataTables");
                return tmp;
            }

            public static bool EnableOfficeControls()
            {
                return (EnableOfficeControlsValue() == "1");
            }

            public static string EnableOfficeControlsValue()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Extend:EnableOfficeControls");
                return tmp;
            }

            public static string ServicesAppInsights()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Services:AppInsights");
                return tmp;
            }

            public static string DefaultSPAppWebUrl()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:SP:DefaultSPAppWebUrl");
                return tmp;
            }

            public static string DefaultSPHostWebUrl()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:SP:DefaultSPHostWebUrl");
                return tmp;
            }

            public static bool EnableTimePickerUIControl()
            {
                return (EnableTimePickerUIControlValue() == "1");
            }

            public static string EnableTimePickerUIControlValue()
            {
                string tmp = System.Configuration.ConfigurationManager.AppSettings.Get("Settings:Extend:TimePickerUIControl");
                return tmp;
            }
        }

        public class Formatting
        {
            public static string DateFormat()
            {
                return "dd/MM/yyyy";
            }

            public static string DateFormatForHtml()
            {
                return "dd/mm/yyyy";
            }

            public static string DateFormatForBinding()
            {
                return "{0:dd/MM/yyyy}";
            }

            public static string DateTimeFormat()
            {
                return "dd/MM/yyyy HH:mm:ss";
            }
        }

        public class Literals
        {
            public static string CommentsStringFormat()
            {
                return "<div class='custom-comments'><span class='custom-comments-by'>[[DATETIME]] [USER]:<span> <div class='custom-comments-text'>[TEXT]</div></div>";
            }
        }
    }
}