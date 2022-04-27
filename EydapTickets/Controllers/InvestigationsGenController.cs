using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DM.App.Library.Models;
using DM.App.Library.Core;
using EydapTickets.Utils;
using EydapTickets.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Net.Http;

namespace EydapTickets.Controllers
{
    [Authorize]
    [OutputCache(NoStore = true, Duration = 0)]
    public class InvestigationsGenController : BaseController
    {
        private ExternalDBEntities db = new ExternalDBEntities();
        string TEMP_FILES_ABS_PATH = System.Configuration.ConfigurationManager.AppSettings.Get("FilesAbsolutePath") + "\\Uploads"; //  "~/App_Data/Uploads";
        string TARGET_FILES_ABS_PATH = System.Configuration.ConfigurationManager.AppSettings.Get("FilesAbsolutePath") + "\\Files"; //"~/App_Data/Files";

        // GET: Investigations
        public ActionResult Index()
        {
            var model = db.Investigations; //.Include(t => t.TaskTypes);
            return View(model.ToList());
        }

        // GET: Investigations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigations model = db.Investigations.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Investigations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Investigations model, string UserCommand)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Visits.Add(tasks);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            try
            {
                if (string.IsNullOrEmpty(UserCommand) || UserCommand == "Cancel")
                    return RedirectToAction("Index", "Home", HtmlTagsHelper.BuildQueryStringRouteValues(this.Request));

                {
                    if (ModelState.IsValid)
                    {
                        model.PrepareFields(this.HttpContext.User);
                        this.ValidateModel(model);

                        FieldValidator.SetMultiSelectValues(this.Request, model, model.FieldsConfiguration, Enums.FormStates.New);
                        FieldValidator.EscapeRichText(model, model.FieldsConfiguration, Enums.FormStates.New, Server);

                        model.InvestigationsId = Guid.NewGuid();

                        db.Investigations.Add(model);

                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        foreach (var error in ModelState)
                        {
                            foreach (var err in error.Value.Errors)
                            {
                                if (err.Exception != null)
                                    sb.AppendFormat("{0}: {1}{2}", error.Key, err.Exception.Message, Environment.NewLine);
                                else
                                    sb.AppendFormat("{0}: {1}{2}", error.Key, err.ErrorMessage, Environment.NewLine);
                            }
                        }
                        throw new Exception(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                //logger.Error(string.Format("Create.Post [{0} - ReqId: {1} - User: {2}]", hostWebUrl, requests.SPRequestId, this.userLoginName), ex);
            }
            return View(model);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigations model = db.Investigations.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            model.StoixeiaEpisynaptomena_FileAttachments = Guid.NewGuid().ToString();

            EydapTickets.Models.UsersModel u = GetCurrentUser();
            if (u != null)
            {
                // 'u' Should never be null
                GenericUser user = new GenericUser(u.UserName);
                user.Id = u.UserId;
                model.CurrentUser = user;
            }

            //ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "TaskTypeId", "TaskCode", tasks.TaskTypeId);
            return View(model);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Investigations model, string UserCommand)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tasks).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "TaskTypeId", "TaskCode", tasks.TaskTypeId);
            //return RedirectToAction("Index");

            if (string.IsNullOrEmpty(UserCommand) || UserCommand == "Cancel")
                return RedirectToAction("Index", "Home", HtmlTagsHelper.BuildQueryStringRouteValues(this.Request));
            try
            {
                if (ModelState.IsValid)
                {
                    //Visits taskFromDB = db.Visits.Find(tasks.RowId);
                    Investigations modelFromDB = db.Investigations.Where(e => e.InvestigationsId == model.InvestigationsId).FirstOrDefault();
                    //logger.Debug(string.Format("Edit Post GetDBModel [Id: {0}]", (tasks != null ? tasks.UniqueId.ToString() : "empty")));
                    if (model == null || modelFromDB == null)
                    {
                        return HttpNotFound();
                    }

                    //if (this.isSiteAdmin || tasks.AssignedToLoginName.Equals(this.userLoginName, StringComparison.InvariantCultureIgnoreCase) || tasks.SubstituteLoginName.Equals(this.userLoginName, StringComparison.InvariantCultureIgnoreCase))
                    {

                        //if (!string.IsNullOrEmpty(tasks.Comments))
                        //{
                        //    tasks.Comments = FieldValidator.EscapeRichText(tasks.Comments, Server);
                        //}

                        // refresh existing attachments
                        model.StoixeiaEpisynaptomena_FileAttachments = modelFromDB.StoixeiaEpisynaptomena_FileAttachments;
                        //model.StoixeiaVlavis_SkarifimaFileAttatchment = modelFromDB.StoixeiaVlavis_SkarifimaFileAttatchment;

                        db.Entry(modelFromDB).State = EntityState.Modified;
                        modelFromDB.PrepareFieldsForUpdate(this.HttpContext.User);
                        FieldValidator.SetMultiSelectValues(this.Request, model, model.FieldsConfiguration, Enums.FormStates.Edit);
                        FieldValidator.AssignValues(modelFromDB, model, modelFromDB.FieldsConfiguration, DM.App.Library.Core.Enums.FormStates.Edit, true, Server);

                        HandleAttachmentsFromStoixeiaEpisynaptomena(modelFromDB, Enums.FormStates.New);

                        db.SaveChanges();

                        //logger.Debug(string.Format("Edit Post End [Id: {0}]", (tasks != null ? tasks.UniqueId.ToString() : "empty")));
                        //return RedirectToAction("Index", HtmlTagsHelper.BuildQueryStringRouteValues(this.Request));
                        //return RedirectToAction("Index", "Home", HtmlTagsHelper.BuildQueryStringRouteValues(this.Request));
                        return View("EditPosted");

                    }
                    //else
                    //    return HttpNotFound();
                }
                else
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (var error in ModelState)
                    {
                        foreach (var err in error.Value.Errors)
                        {
                            if (err.Exception != null)
                                sb.AppendFormat("{0}: {1}{2}", error.Key, err.Exception.Message, Environment.NewLine);
                            else
                                sb.AppendFormat("{0}: {1}{2}", error.Key, err.ErrorMessage, Environment.NewLine);
                        }
                    }
                    throw new Exception(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                //logger.Error(string.Format("Edit.Post [{0} - TaskId: {1} - User: {2}]", hostWebUrl, tasks.SPTaskId, this.userLoginName), ex);
            }
            FieldValidator.EscapeRichText(model, model.FieldsConfiguration, Enums.FormStates.Edit, Server);
            return View(model);

        }

        private void POST(string url, string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                length = response.ContentLength;
            }
        }

        // GET: Tasks/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Visits tasks = db.Visits.Find(id);
        //    if (tasks == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tasks);
        //}

        // POST: Tasks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Visits tasks = db.Visits.Find(id);
        //    db.Visits.Remove(tasks);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        //
        // Λ. Στοιχεία Επισυναπτόμενα - Επισυναπτόμενα
        // 24.02.2017, Andreas Kasapleris
        //
        protected void HandleAttachmentsFromStoixeiaEpisynaptomena(Investigations model, DM.App.Library.Core.Enums.FormStates formState)
        {
            IEnumerable<DM.App.Library.Models.Interfaces.ICategoryField> fields =
                model.FieldsConfiguration.Where(e => (formState == DM.App.Library.Core.Enums.FormStates.New && e.ControlTypeInNewForm == DM.App.Library.Core.HtmlLibHelper.CONTROL_FILEUPLOAD && e.Entity == "Investigations" && e.InternalName == "StoixeiaEpisynaptomena_FileAttachments") ||
                                                     (formState == DM.App.Library.Core.Enums.FormStates.Edit && e.ControlTypeInEditForm == DM.App.Library.Core.HtmlLibHelper.CONTROL_FILEUPLOAD) && e.Entity == "Investigations" && e.InternalName == "StoixeiaEpisynaptomena_FileAttachments");

            foreach (DM.App.Library.Models.Interfaces.ICategoryField categoryField in fields)
            {
                DM.App.Library.Models.Interfaces.IField field = categoryField.FieldsDefinitions.Where(e => e.Entity == categoryField.Entity && e.FieldName == categoryField.InternalName).FirstOrDefault();
                Guid fieldId = Guid.Empty;
                if (field != null)
                {
                    fieldId = field.Id;
                }
                string fuuid = "";
                if (!string.IsNullOrEmpty(this.Request.Form["hidden" + categoryField.InternalName]))
                    fuuid = this.Request.Form["hidden" + categoryField.InternalName];

                string data = "";
                if (!string.IsNullOrEmpty(this.Request.Form["hiddenData" + categoryField.InternalName]))
                    data = this.Request.Form["hiddenData" + categoryField.InternalName];

                try
                {
                    List<string> attachments = new List<string>();

                    if (!string.IsNullOrEmpty(data))
                    {
                        try
                        {
                            DM.App.Library.Models.DTO.Investigation d = Newtonsoft.Json.JsonConvert.DeserializeObject<DM.App.Library.Models.DTO.Investigation>(data);
                            if (d != null && d.Attachments != null)
                            {
                                foreach (DM.App.Library.Models.DTO.EpisynaptomenaFileAttachment att in d.Attachments)
                                {
                                    attachments.Add(att.AttachmentUrl);
                                }
                            }
                        }
                        catch (Exception /* exeption */)
                        {
                            //logger.Error(string.Format("HandleAttachments [{0} - ReqId: {1} - FUUId: {2} - FieldName: {3} - User: {4} - Data: {5}]", hostWebUrl, requests.SPRequestId, fuuid, categoryField.InternalName, this.userLoginName, data), exception);
                        }
                    }

                    //changed path to absolute...
                    string tempPath = TEMP_FILES_ABS_PATH; // Server.MapPath(TEMP_FILES_PATH);
                    string targetPath = TARGET_FILES_ABS_PATH; // Server.MapPath(TARGET_FILES_PATH);
                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        System.IO.Directory.CreateDirectory(targetPath);
                    }
                    //model.SaveFileAttachments(db, fileNames, this.userLoginName, fieldId, TEMP_FILES_PATH, attachments);

                    List<string> files = new List<string>();
                    if (!string.IsNullOrEmpty(model.StoixeiaEpisynaptomena_FileAttachments))
                        files.AddRange(model.StoixeiaEpisynaptomena_FileAttachments.Split(new char[] { ';' }));

                    foreach (string item in GetFilePaths(fuuid))
                    {
                        string tempFile = item.Replace(tempPath, targetPath);
                        if (model.InvestigationsId != Guid.Empty)
                            tempFile = tempFile.Replace(fuuid, model.InvestigationsId.ToString("D"));
                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(tempFile)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(tempFile));
                        }
                        if (!files.Contains(tempFile))
                        {
                            try
                            {
                                files.Add(tempFile);
                                if (System.IO.File.Exists(tempFile))
                                {
                                    System.IO.File.Delete(tempFile);
                                }

                                System.IO.File.Move(item, tempFile);
                            }
                            catch (Exception ex)
                            {
                                Logger.Instance().Error("HandleAttachments failed to delete or move file.", ex);
                            }
                        }
                    }
                    model.StoixeiaEpisynaptomena_FileAttachments = string.Join(";", files.ToArray());
                }
                catch (Exception /* exception */)
                {
                    //logger.Error(string.Format("HandleAttachments [{0} - ReqId: {1} - FUUId: {2} - FieldName: {3} - User: {4}]", hostWebUrl, requests.SPRequestId, fuuid, categoryField.InternalName, this.userLoginName), exception);
                }
            }
        }


        //
        // 12.09.2016, Επισυναπτόμενα αρχεία (διάφορα, πχ λογμός ΕΥΔΑΠ, φωτο, υπεύθυνη δήλωση, κλπ)
        //

        [HttpGet]
        public ActionResult EpisynaptomenaFileAttachments(Guid? id)
        {
            DM.App.Library.Models.DTO.Investigation data = new DM.App.Library.Models.DTO.Investigation();

            var model = db.Investigations.Where(e => e.InvestigationsId == id).FirstOrDefault();
            if (model == null)
                return HttpNotFound();

            if (!string.IsNullOrEmpty(model.StoixeiaEpisynaptomena_FileAttachments))
            {
                string[] att = model.StoixeiaEpisynaptomena_FileAttachments.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (att != null && att.Length > 0)
                {
                    if (data.Attachments == null)
                        data.Attachments = new List<DM.App.Library.Models.DTO.EpisynaptomenaFileAttachment>();
                    for (int i = 0; i < att.Length; i++)
                    {
                        //string path = "?p=" + att[i].Replace(Server.MapPath(TARGET_FILES_PATH), "");//.Replace("\\", "\\");
                        string path = "?p=" + att[i].Replace(TARGET_FILES_ABS_PATH, "");//.Replace("\\", "\\");
                        if (id.HasValue)
                            path = id.Value.ToString("D") + path;
                        data.Attachments.Add(new DM.App.Library.Models.DTO.EpisynaptomenaFileAttachment() { FieldName = "StoixeiaEpisynaptomena_FileAttachments", AttachmentFileName = System.IO.Path.GetFileName(path), AttachmentUrl = DM.App.Library.Core.Utils.ConcatUrlPaths("/InvestigationsGen/Attachment/", path) });
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Attachment(string id, string p)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                string temp1 = TARGET_FILES_ABS_PATH; //Server.MapPath(TARGET_FILES_PATH);
                string temp2 = p.Replace("/", "\\");
                if (temp2.StartsWith("\\"))
                    temp2 = temp2.Substring(1);
                string path = System.IO.Path.Combine(temp1, temp2);
                if (System.IO.File.Exists(path))
                {
                    System.Net.Mime.ContentDisposition contentDisposition = new System.Net.Mime.ContentDisposition
                    {
                        FileName = System.IO.Path.GetFileName(path),

                        // always prompt the user for downloading, set to true if you want
                        // the browser to try to show the file inline
                        Inline = false,
                    };
                    Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
                    return File(path, "application/octet-stream");
                }
            }
            catch (Exception)
            {
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> files, string fuuid, string deletedFile)
        {
            string data = "";
            try
            {
                if (!string.IsNullOrEmpty(deletedFile))
                {
                    // Remove deleted file
                    Guid tempGuid = Guid.Empty;
                    if (Guid.TryParse(fuuid, out tempGuid))
                    {
                        //string path = System.IO.Path.Combine(Server.MapPath(TEMP_FILES_PATH), fuuid, deletedFile);
                        string path = System.IO.Path.Combine(TEMP_FILES_ABS_PATH, fuuid, deletedFile);
                        if (System.IO.File.Exists(path))
                        {
                            try
                            {
                                System.IO.File.Delete(path);
                                data = deletedFile;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.ContentLength > 0)
                        {
                            string folder = TEMP_FILES_ABS_PATH;
                            if (!string.IsNullOrEmpty(fuuid))
                            {
                                Guid tempGuid = Guid.Empty;
                                if (Guid.TryParse(fuuid, out tempGuid))
                                {
                                    //folder = System.IO.Path.Combine(Server.MapPath(TEMP_FILES_PATH), fuuid);
                                    folder = System.IO.Path.Combine(TEMP_FILES_ABS_PATH, fuuid);
                                    System.IO.Directory.CreateDirectory(folder);
                                }
                                else
                                    folder = Server.MapPath(folder);
                            }
                            else
                                folder = Server.MapPath(folder);
                            string fileName = System.IO.Path.GetFileName(file.FileName);
                            string path = System.IO.Path.Combine(folder, fileName);

                            file.SaveAs(path);

                            data = fileName;
                        }
                    }
                }
                //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data), "application/json", System.Text.Encoding.UTF8);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception /* exception */)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult LookupMunicipalities()
        {
            try
            {
                Eydap1022Port.eydap1022WebService client = new Eydap1022Port.eydap1022WebService();
                Eydap1022Port.getMunicipalitiesResponse resp = client.getMunicipalities("");
                var d = from c in resp.municipalitiesList
                        select new
                        {
                            Id = c,
                            Name = c
                        };

                return Json(d, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("LookupMunicipalities() failed", ex);

                List<string> data = new List<string>();
                data.Add("Αθηνών");
                data.Add("Πειραιά");
                var d = from c in data
                        select new
                        {
                            Id = c,
                            Name = c
                        };

                return Json(d, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult LookupStreets(string id, string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return HttpNotFound();

            if (!filter.Equals("undefined", StringComparison.InvariantCulture))
            {
                try
                {
                    Eydap1022Port.eydap1022WebService client = new Eydap1022Port.eydap1022WebService();
                    string[] data = client.getStreets(filter);

                    var d = from c in data
                            select new
                            {
                                Id = c,
                                Name = c
                            };
                    return Json(d, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    Logger.Instance().Error("LookupMunicipalities() failed", ex);

                    List<string> data = new List<string>();
                    if (filter.Equals("Αθηνών", StringComparison.InvariantCultureIgnoreCase))
                    {
                        data.Add("Τοσίτσα");
                        data.Add("Σταδίου");
                    }
                    else if (filter.Equals("Πειραιά", StringComparison.InvariantCultureIgnoreCase))
                    {
                        data.Add("Λ. Ηρώων Πολυτεχνείου");
                        data.Add("Λαμπράκη");
                    }

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json(new { Id = id, Name = id }, JsonRequestBehavior.AllowGet);
        }

        private string[] GetFilePaths(string fuuid)
        {
            List<string> paths = new List<string>();
            if (!string.IsNullOrEmpty(fuuid))
            {
                //string path = Server.MapPath(System.IO.Path.Combine(TEMP_FILES_PATH, fuuid));

                string path = System.IO.Path.Combine(TEMP_FILES_ABS_PATH, fuuid);
                if (System.IO.Directory.Exists(path))
                {
                    string[] files = System.IO.Directory.GetFiles(path);
                    return files;
                }
            }
            return paths.ToArray();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
