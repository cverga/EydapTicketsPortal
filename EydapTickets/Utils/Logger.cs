using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using System.Configuration;

namespace EydapTickets.Utils
{
    public class Logger
    {

        private static Logger mLogger;

#if !DEBUG
        private static TelemetryClient mTelemetryClient = new TelemetryClient();
#endif

        private Logger()
        {
#if !DEBUG
            mTelemetryClient.InstrumentationKey = ConfigurationManager.AppSettings["Settings:Services:AppInsights"].ToString();
#endif
        }

        public static Logger Instance()
        {
            if (mLogger == null)
            {
                mLogger = new Logger();
            }

            return mLogger;
        }

        public void Info(String aMessage)
        {
            System.Diagnostics.Trace.TraceInformation(aMessage);
            LogToFile(aMessage);
        }

        public void Warning(String aMessage)
        {
            try
            {
                System.Diagnostics.Trace.TraceWarning(aMessage);
                LogToFile(aMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("ERROR on logging warning, message: " + ex.Message);
            }
        }

        public void Error(String aMessage, Exception aException)
        {
            try
            {
                string lMessage = aMessage;
                string lMessage1 = null;
                if (aException != null)
                {
                    lMessage += ". Exception: " + aException.Message;
                    lMessage1 = "StackTrace: " +  aException.StackTrace;
                }

#if !DEBUG
                mTelemetryClient.TrackException(aException);
#endif
                LogToFile(lMessage + " Exception: " + lMessage1);

                System.Diagnostics.Trace.TraceError(aMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("ERROR on logging error, message: " + ex.Message);
            }
        }

        private void LogToFile(String aMessage)
        {
            try
            {
                string lExMessge = aMessage;

                string lFilePath = string.Format("{0}\\{1}", System.Configuration.ConfigurationManager.AppSettings["LogFilePath"], "Ticketing_LogFile.txt");

                File.AppendAllText(lFilePath, string.Format("{0}{1}", Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine, lExMessge));

                //System.Diagnostics.Debug.WriteLine(lExMessge);
            }
            catch (Exception /* exception */)
            {
                //System.Diagnostics.Debug.WriteLine("ERROR on logging error, message: " + exception.Message);
            }
        }
    }
}
