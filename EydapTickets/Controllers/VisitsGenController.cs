using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DM.App.Library.Models;
using DM.App.Library.Core;
using EydapTickets.Helpers;
using EydapTickets.Utils;
using System.Web.Script.Serialization;
using System.IO;
using System.Threading.Tasks;
using DevExpress.Utils.Extensions;
using EydapTickets.Services;
using Newtonsoft.Json;
using TaskDTO = EydapTickets.Models.Task;

namespace EydapTickets.Controllers
{
    [Authorize]
    [OutputCache(NoStore = true, Duration = 0)]
    public class VisitsGenController : BaseController
    {
        private ExternalDBEntities db = new ExternalDBEntities();

        // GET: VisitsGen
        public async Task<ActionResult> Index()
        {
            var model = await db.Visits
                .ToListAsync();

            return View(model.ToList());
        }

        // GET: VisitsGen/Details/00000000-0000-0000-0000-000000000000
        public async Task<ActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = await db.Visits
                .FindAsync(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            // Assign the current editor.
            var currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                model.CurrentUser = new GenericUser(currentUser.UserName)
                {
                    Id = currentUser.UserId
                };
            }

            return View(model);
        }

        // GET: VisitsGen/Edit/00000000-0000-0000-0000-000000000000
        [HttpGet]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = await db.Visits
                .FindAsync(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            // Assign a new guid to be used for uploading new attachments for the editing session.
            model.Attachments = Guid.NewGuid().ToString();

            // Assign the current editor.
            var currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                model.CurrentUser = new GenericUser(currentUser.UserName)
                {
                    Id = currentUser.UserId
                };
            }

            return View(model);
        }

        // POST: VisitsGen/Edit/00000000-0000-0000-0000-000000000000
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(Visits model, string UserCommand)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(UserCommand) || UserCommand == "Cancel")
            {
                return RedirectToAction("Index", "Home", HtmlTagsHelper.BuildQueryStringRouteValues(Request));
            }

            try
            {
                FieldValidator.EscapeRichText(model, model.FieldsConfiguration, Enums.FormStates.Edit, Server);

                if (ModelState.IsValid)
                {
                    Visits storedModel = await db.Visits
                        .FirstOrDefaultAsync(v => v.AssignmentId == model.AssignmentId);

                    //logger.Debug(string.Format("{0}: GetDBModel [Id: {1}]", nameof(EditPost), storedModel != null ? storedModel.AssignmentId.ToString() : "empty"));

                    if (storedModel == null)
                    {
                        return HttpNotFound();
                    }

                    // Verify editor permissions
                    //if (this.isSiteAdmin || tasks.AssignedToLoginName.Equals(this.userLoginName, StringComparison.InvariantCultureIgnoreCase) || tasks.SubstituteLoginName.Equals(this.userLoginName, StringComparison.InvariantCultureIgnoreCase))
                    //{

                    // Refresh existing attachments
                    model.Attachments = storedModel.Attachments;

                    db.Entry(storedModel).State = EntityState.Modified;
                    storedModel.PrepareFieldsForUpdate(HttpContext.User);

                    FieldValidator.SetMultiSelectValues(Request, model, model.FieldsConfiguration, Enums.FormStates.Edit);
                    FieldValidator.AssignValues(storedModel, model, storedModel.FieldsConfiguration, Enums.FormStates.Edit, true, Server);

                    await HandleAttachments(storedModel, Enums.FormStates.New);

                    await db.SaveChangesAsync();

                    //if (ShouldPropagateVisitToTablet(storedModel))
                    //{
                    //    PropagateRequestToTablet(storedModel);
                    //}

                    //logger.Debug(string.Format("{0}: End [Id: {1}]", nameof(EditPost), model != null ? model.AssignmentId.ToString() : "empty" ));

                    return View("EditComplete");
                    //}
                    //else
                    //return HttpNotFound();
                }

                var sb = new StringBuilder();

                foreach (KeyValuePair<string, ModelState> entry in ModelState)
                {
                    ModelErrorCollection errors = entry.Value.Errors;
                    if (!errors.Any())
                    {
                        continue;
                    }
                    foreach (ModelError error in errors)
                    {
                        var errorMessage = error.Exception != null
                            ? error.Exception.Message
                            : error.ErrorMessage;

                        sb.AppendFormat("{0}: {1}{2}", entry.Key, errorMessage, Environment.NewLine);
                    }
                }

                throw new Exception(sb.ToString());
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                //logger.Error(string.Format("Edit.Post [{0} - TaskId: {1} - User: {2}]", hostWebUrl, tasks.SPTaskId, this.userLoginName), ex);
            }

            return View("Edit", model);
        }

        //
        // 24.11.2016, Andreas Kasapleris
        //

        //public class SynergeioEpemvasis
        //{
        //    public string personnelID { get; set; }
        //    public string personnelName { get; set; }
        //    // .. more class properties go here
        //}

        //[HttpGet]
        //public ActionResult LookUpTeam(string id)
        //{
        //    string aTskId = id;

        //    // use a dictionary with an int key
        //    // Dictionary<int, string> dict = new Dictionary<int, string>();
        //    // dict.Add(1, "Ανδρέας Κασαπλέρης");
        //    // dict.Add(2, "Γεράσιμος Χιωτέλης");

        //    var SynergeioEpemv = new List<SynergeioEpemvasis>();

        //    SynergeioEpemv.Add(new SynergeioEpemvasis { personnelID = "1", personnelName = "Andreas Kasapleris" });
        //    SynergeioEpemv.Add(new SynergeioEpemvasis { personnelID = "2", personnelName = "Gerasimos Chiotelis" });

        //    // access first row of data
        //    SynergeioEpemvasis firstRow = SynergeioEpemv[0];
        //    string pId = firstRow.personnelID;
        //    string pName = firstRow.personnelName;

        //    // var SynergeioEpemv = new List<Tuple<string, string>>();

        //    // SynergeioEpemv.Add(new Tuple<string,string>("1", "Ανδρέας Κασαπλέρης" ));
        //    // SynergeioEpemv.Add(new Tuple<string,string>("2", "Γεράσιμος Χιωτέλης" ));

        //    var d = from c in SynergeioEpemv
        //            select new
        //            {
        //                // ValueInt = c.Item1,
        //                // DisplayText = c.Item2
        //                ValueInt = c.personnelID,
        //                DisplayText = c.personnelName
        //            };

        //    return Json(d, JsonRequestBehavior.AllowGet);

        //    // return Json(new { Id = "1", Name = "Ανδρέας Κασαπλέρης" }, JsonRequestBehavior.AllowGet);
        //}

        protected async Task HandleAttachments(Visits model, Enums.FormStates formState)
        {
            IEnumerable<DM.App.Library.Models.Interfaces.ICategoryField> fields = model.FieldsConfiguration.Where(e => (formState == Enums.FormStates.New && e.ControlTypeInNewForm == HtmlLibHelper.CONTROL_FILEUPLOAD) || (formState == Enums.FormStates.Edit && e.ControlTypeInEditForm == HtmlLibHelper.CONTROL_FILEUPLOAD));
            foreach (DM.App.Library.Models.Interfaces.ICategoryField categoryField in fields)
            {
                DM.App.Library.Models.Interfaces.IField field = categoryField.FieldsDefinitions
                    .FirstOrDefault(e => e.Entity == categoryField.Entity && e.FieldName == categoryField.InternalName);

                if (field == null)
                {
                    continue;
                }

                var fuuid = string.Empty;
                var fuuidKey = $"hidden{categoryField.InternalName}";
                if (!string.IsNullOrEmpty(Request.Form[fuuidKey]))
                {
                    fuuid = Request.Form[fuuidKey];
                }

                try
                {
                    var tempStorage = new TemporaryStorageService(fuuid);
                    var attachmentStorage = new AttachmentStorageService(model.AssignmentId != Guid.Empty ? model.AssignmentId.ToString() : fuuid);

                    var processedAttachments = new List<string>();

                    if (!string.IsNullOrEmpty(model.Attachments))
                    {
                        processedAttachments.AddRange(model.Attachments.Split(Path.PathSeparator));
                    }

                    foreach (var blob in await tempStorage.ListAsync())
                    {
                        if (processedAttachments.Contains(blob.Id))
                        {
                            continue;
                        }
                        try
                        {
                            await tempStorage.MoveToAsync(blob.Id, attachmentStorage);
                            processedAttachments.Add(blob.Id);
                        }
                        catch (Exception exception)
                        {
                            Logger.Instance().Error($"{nameof(HandleAttachments)} failed to delete or move file.", exception);
                        }
                    }

                    model.Attachments = string.Join(Path.PathSeparator.ToString(), processedAttachments.ToArray());
                }
                catch (Exception /* exception */)
                {
                    //Logger.Instance().Error(string.Format("HandleAttachments [{0} - ReqId: {1} - FUUId: {2} - FieldName: {3} - User: {4}]", hostWebUrl, requests.SPRequestId, fuuid, categoryField.InternalName, this.userLoginName), exception);
                }
            }
        }

        [HttpGet]
        public ActionResult Attachments(
            [Bind(Prefix = "id" )] Guid? assignmentId)
        {
            if (assignmentId.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var data = new DM.App.Library.Models.DTO.Visit();

            var assignment = db.Visits
                .FirstOrDefault(e => e.AssignmentId == assignmentId);

            if (assignment == null)
            {
                return HttpNotFound();
            }

            if (!string.IsNullOrEmpty(assignment.Attachments))
            {
                var attachmentPaths = assignment.Attachments.Split(new [] { Path.PathSeparator }, StringSplitOptions.RemoveEmptyEntries);
                if (attachmentPaths.Length > 0)
                {
                    if (data.Attachments == null)
                    {
                        data.Attachments = new List<DM.App.Library.Models.DTO.Attachment>();
                    }

                    data.Attachments = attachmentPaths
                        .Select(attachmentPath => new DM.App.Library.Models.DTO.Attachment()
                        {
                            FieldName = "Attachments",
                            AttachmentFileName = attachmentPath,
                            AttachmentUrl = Url.Action("Attachment", "VisitsGen", new { id = assignmentId, p = attachmentPath })
                        })
                        .ToList();
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> Attachment(
            [Bind(Prefix="id")] Guid? assignmentId,
            [Bind(Prefix="p")] string fileName)
        {
            if (assignmentId.HasValue == false || string.IsNullOrWhiteSpace(fileName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var attachmentStorage = new AttachmentStorageService(assignmentId.ToString());

                if (await attachmentStorage.ExistsAsync(fileName))
                {
                    var contentDisposition = ContentDispositionHelper.CreateAttachmentContentDisposition(Request, fileName, true);

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    Response.AppendHeader("Content-Disposition", contentDisposition.ToString());

                    byte[] fileBytes = await attachmentStorage.ReadAllBytes(fileName);
                    return File(fileBytes, "application/octet-stream");
                }
            }
            catch (Exception /* exception */)
            {
                // ignored
            }

            return HttpNotFound();
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile(IEnumerable<HttpPostedFileBase> files, string fuuid, string deletedFile)
        {
            var processedFiles = new List<string>();

            try
            {
                var tempStorage = new TemporaryStorageService(fuuid);

                // Check whether we are deleting a file.
                 if (!string.IsNullOrEmpty(deletedFile))
                {
                   await tempStorage.DeleteAsync(deletedFile);
                   processedFiles.Add(deletedFile);
                }

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.ContentLength <= 0)
                        {
                            continue;
                        }

                        var fileName = Path.GetFileName(file.FileName);
                        if (fileName == null)
                        {
                            continue;
                        }

                        await tempStorage.WriteAsync(fileName, file.InputStream);
                        processedFiles.Add(fileName);
                    }
                }

                Response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception /* exception */)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return Json(processedFiles, JsonRequestBehavior.AllowGet);
        }

        //
        // 13.12.2016, change handled by Andreas Kasapleris
        // 13.12.2016, placed in comments due to I.Varouxis fix
        // new version of this method is written
        //

        //[HttpGet]
        //public ActionResult LookupFaultReasons(int id, string filter)
        //{
        //    if (id > 0 && (string.IsNullOrEmpty(filter) || filter.Equals("undefined")))
        //    {
        //        var data = db.C_VLAVESATH_TAitia.Where(e => e.ID == id).FirstOrDefault();
        //        if (data == null)
        //            return HttpNotFound();

        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        var data = db.C_VLAVESATH_TAitia.Where(e => e.eidos == filter);
        //        if (data == null)
        //            return HttpNotFound();

        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //
        // 13.12.2016, change handled by Andreas Kasapleris
        // 13.12.2016, I.Varouxis new version of action method to
        // support multiple integers (list of ids)
        //

        [HttpGet]
        public ActionResult LookupFaultReasons(string id, string filter)
        {
            List<int> tmpIds = new List<int>();
            if (!string.IsNullOrEmpty(id))
            {
                string[] arr = id.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    int tmp = -1;
                    if (int.TryParse(arr[i], out tmp))
                        tmpIds.Add(tmp);
                }
            }

            if (tmpIds.Count > 0 && (string.IsNullOrEmpty(filter) || filter.Equals("undefined")))
            {
                var data = db.C_VLAVESATH_TAitia.Where(e => tmpIds.Contains(e.ID)).ToList();
                if (data == null)
                    return HttpNotFound();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.C_VLAVESATH_TAitia.Where(e => e.eidos == filter);
                if (data == null)
                    return HttpNotFound();

                return Json(data, JsonRequestBehavior.AllowGet);
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
            // 16.11.2017, Andreas Kasapleris
            // if filter i.e. Municipalities is null or empty
            // return an empty list of Streets; avoid returning
            // an HttpNotFound() message

            if (string.IsNullOrEmpty(filter))
            {
                string[] data = { };

                var d = from c in data
                        select new
                        {
                            Id = c,
                            Name = c
                        };
                return Json(d, JsonRequestBehavior.AllowGet);
            }
            // 16.11.2017, Andreas Kasapleris, commented out
            // return HttpNotFound();

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

        [HttpGet]
        public ActionResult LookupTanks()
        {
            try
            {
                var lResults = Models.IncidentProvider.GetKeyValueStoredProcedure("GetTanks", GetCurrentUser());

                var d = from c in lResults
                        select new
                        {
                            Id = c.Item1,
                            Name = c.Item2
                        };

                return Json(d, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Instance().Error("LookupTanks() failed", ex);

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

        //======================================================
        // 02.07.2018, Andreas Kasapleris
        // action method to handle printing of all forms reports
        // Parameters: takes as input variable AssignmentId
        //======================================================

        // GET: VisitsGen/PrintForm/guid
        public async Task<ActionResult> PrintForm1070(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get db record from Visits and store in into a 'model'
            Visits model = await db.Visits
                .FindAsync(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            var currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                model.CurrentUser = new GenericUser(currentUser.UserName)
                {
                    Id = currentUser.UserId
                };
            }

            // Call Controller: PrintFormsController
            // Action method  : Index
            // Passes params  : TaskId, AssignmentId

            return RedirectToAction("Index", "PrintForm1070", new { TaskId = model.TaskTypeId, AssignmentId = id });
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
