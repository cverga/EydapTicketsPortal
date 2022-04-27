using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.App.Library.Log
{
    public class Logger
    {
        //public static void Log(string message)
        //{
        //    Log(message, false, true);
        //}

        public static void Log(string message, bool ignoreSource, bool ingoreDateTime)
        {
            try
            {
                string source = null;
                if (!ignoreSource)
                {
                    source = new System.Diagnostics.StackFrame(1).GetMethod().Name + ": ";
                    //System.Diagnostics.Debug.WriteLine(string.Format("{0} - {1}", source, message, DateTime.Now.ToLocalTime()));
                }
                string messageLog = string.Format("{0}{1}", source, message);
                if (!ingoreDateTime)
                    messageLog = string.Format("{0}\t{1}", DateTime.Now.ToString("yyyyMMdd-HHmmss"), messageLog);
                System.Diagnostics.Debug.WriteLine(messageLog);
            }
            catch (Exception)
            {
            }
        }

        public static void ClearLogFile(bool retainBackup)
        {
            string fileName = Logger.GetLogFileName();
            string fileNameNoExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
            string fileNameFull = Logger.GetExecutablePath() + fileName;
            try
            {
                if (retainBackup && System.IO.File.Exists(fileNameFull))
                {
                    DateTime d = System.IO.File.GetLastWriteTime(fileNameFull);
                    string newFileName = string.Format("{0}-{1}.log", fileNameNoExtension, d.ToString("yyyyMMdd-HHmmss"));
                    if (System.IO.File.Exists(newFileName))
                        newFileName = string.Format("{0}-{1}-{2}.log", fileNameNoExtension, d.ToString("yyyyMMdd-HHmmss"), DateTime.Now.Ticks);
                    System.IO.File.Move(fileNameFull, newFileName);

                    Log(string.Format("New log file: {0}\tOld file: {1}", fileNameFull, newFileName), false, false);
                }
                else
                    Log(string.Format("New log file: {0}", fileNameFull), false, false);
            }
            catch (Exception ex)
            {
                Log(string.Format("Move log file failed: {0} - {1}", fileNameFull, ex.Message), false, false);
            }
            try
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(fileNameFull));
                System.IO.FileInfo[] filesInfo = dirInfo.GetFiles();

                foreach (System.IO.FileInfo fi in filesInfo)
                {
                    if (fi.Name.StartsWith("trace") && System.IO.Path.GetExtension(fi.Name) == ".log" && DateTime.Today.Subtract(fi.CreationTime).TotalDays > 3)
                    {
                        try
                        {
                            System.IO.File.Delete(fi.FullName);
                        }
                        catch (Exception ex)
                        {
                            Log(string.Format("Delete file failed: {0} [{1}] - {2}", fi.Name, fi.CreationTime.ToString(), ex.Message), false, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(string.Format("Delete log files failed: {0}", ex.Message), false, false);
            }
        }

        private static string GetLogFileName()
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location;
            return string.Format("trace-{0}.log", System.IO.Path.GetFileNameWithoutExtension(path));
        }

        private static string GetExecutablePath()
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location;
            return string.Format("{0}\\", System.IO.Path.GetFullPath(path.Substring(0, path.LastIndexOf("\\"))));
        }

    }
}
