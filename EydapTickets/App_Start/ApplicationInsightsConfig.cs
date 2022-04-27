using System.Web.Configuration;
using Microsoft.ApplicationInsights.Extensibility;
using DM.App.Library.Core;

namespace EydapTickets
{
    public class ApplicationInsightsConfig
    {

        public static string InstrumentationKey => Configuration.Settings.ServicesAppInsights();

        public static void Configure()
        {
            if (string.IsNullOrWhiteSpace(InstrumentationKey))
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
            }
            else
            {
                TelemetryConfiguration.Active.InstrumentationKey = InstrumentationKey;
            }
        }
    }
}