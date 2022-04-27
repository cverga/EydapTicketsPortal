using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EydapTickets.Models;
using System.Data;


namespace EydapTickets.Controllers
{
    public class DownLoadController : Controller
    {
        // GET: DownLoad
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public FileStreamResult Index()
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream file = new FileStream("C:\\WebApplications\\Manual.pdf", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);
                ms.Flush();
            }
            ms.Position = 0;
            return File(ms,  "application/pdf");
        }
        //[UniqueId] ,[FileID] ,[FileName] ,[FileDirectory]



        public FileStreamResult GetFile(string aGuid)
        {
            DataTable mTable = InvestigationsProvider.GetFileDetails(aGuid);
            if (mTable.Rows.Count != 0)
            {
                DataRow mRow = mTable.Rows[0];
                string mUpLoadPath = System.Configuration.ConfigurationManager.AppSettings.Get("FilesUploadPath");
                string mFileName = mRow["FileName"].ToString();
                string mFileDirectory = mRow["FileDirectory"].ToString();
                MemoryStream ms = new MemoryStream();
                string filestring = String.Format("{0}\\{1}\\{2}", mUpLoadPath, aGuid, mFileName);
                using (FileStream file = new FileStream(filestring, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);
                    ms.Flush();
                }
                ms.Position = 0;
                return File(ms, System.Net.Mime.MediaTypeNames.Application.Octet, mFileName);
            }
            return null;
        }
    }
}