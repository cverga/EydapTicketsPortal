using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using EydapTickets.Models;
using System.Data;

namespace EydapTickets.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadControlCallbackAction()
        {
            UploadControlExtension.GetUploadedFiles("uc", UploadControlHelper.ValidationSettings, UploadControlHelper.uc_FileUploadComplete);
            return null;
        }

        public ActionResult GetFiles(string aInvestigationId)
        {
            ViewData["InvestigationsID"] = aInvestigationId;
            return PartialView("UploadedFilesPartialView", InvestigationsProvider.GetAttachements(aInvestigationId));
        }

        public ActionResult DeleteFile(FileAttachment aFileAttachment, string aInvestigationId)
        {
            ViewData["InvestigationsID"] = aInvestigationId;
            InvestigationsProvider.DeleteFile(aFileAttachment.UniqueId);
            return PartialView("UploadedFilesPartialView", InvestigationsProvider.GetAttachements(aInvestigationId));
        }
    }

    public class UploadControlHelper
    {
        public const string UploadDirectory = "~/Content/UploadControl/UploadFolder/";

        public static readonly UploadControlValidationSettings ValidationSettings = new UploadControlValidationSettings
        {
            //AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".bmp", },
            MaxFileSize = 120971520,
        };

        public static void uc_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            var value1 = HttpContext.Current.Request.Params["hf1"];
            var value2 = HttpContext.Current.Request.Params["hf2"];
            if (e.UploadedFile.IsValid)
            {
                //string resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory + e.UploadedFile.FileName);
                string Id = value1.ToString();
                string FilePath = System.Configuration.ConfigurationManager.AppSettings.Get("FilesUploadPath");
                string FileName = e.UploadedFile.FileName;
                int FileSize = e.UploadedFile.FileBytes.Length;
                string mGuid = Guid.NewGuid().ToString();
                string resultFilePath = FilePath + "\\" + mGuid + "\\" + e.UploadedFile.FileName;
                if (!Directory.Exists(FilePath + "\\" + mGuid))
                {
                    Directory.CreateDirectory(FilePath + "\\" + mGuid);
                }

                try
                {
                    e.UploadedFile.SaveAs(resultFilePath, true);
                }
                catch (Exception /* exception */)
                {
                    // TODO: Handle exception
                    throw;
                }

                InvestigationsProvider.InsertNewFile(mGuid.ToString(), Id, value2.ToString(), FileName, FilePath, FileSize);
                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                {
                    //e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath);
                    e.CallbackData = "InvestigationGridView" + Id.Replace("-", "");
                }
            }
        }
    }
}