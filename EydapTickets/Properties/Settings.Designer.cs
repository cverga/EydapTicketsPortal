//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EydapTickets.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://dominosrv2.eydap.gr:80/EYDAP/TicketTrace/TicketTrace.nsf/G-TT-Update?OpenW" +
            "ebService")]
        public string EydapTicketsPortal_gr_eydap_dominosrv2_TTUpdateService {
            get {
                return ((string)(this["EydapTicketsPortal_gr_eydap_dominosrv2_TTUpdateService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://dominosrv2.eydap.gr:80/EYDAP/TicketTrace/TicketTrace.nsf/G-TT-Initiation?O" +
            "penWebService")]
        public string EydapTicketsPortal_gr_eydap_dominosrv21_TTCreationService {
            get {
                return ((string)(this["EydapTicketsPortal_gr_eydap_dominosrv21_TTCreationService"]));
            }
        }
    }
}
