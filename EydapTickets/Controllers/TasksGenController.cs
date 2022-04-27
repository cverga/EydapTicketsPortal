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

namespace EydapTickets.Controllers
{
    [Authorize]
    public class TasksGenController : BaseController
    {
        private ExternalDBEntities db = new ExternalDBEntities();

        // GET: Tasks
        public ActionResult Index()
        {
            var model = db.Tasks.Include(t => t.TaskTypes);
            return View(model.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks model = db.Tasks.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Tasks/Create
        public ActionResult Create(int? taskType)
        {
            var model = new Tasks();
            try
            {
                if (taskType.HasValue)
                {
                    DM.App.Library.Models.TaskTypes taskTypeFromDB = db.TaskTypes.Where(e => e.TaskTypeId == taskType.Value && e.IsActive == 1).FirstOrDefault();
                    if (taskTypeFromDB != null)
                    {
                        model.TaskTypeId = taskType.Value;

                        EydapTickets.Models.UsersModel u = GetCurrentUser();
                        if (u != null)
                        {
                            // 'u' Should never be null
                            GenericUser user = new GenericUser(u.UserName);
                            model.CurrentUser = user;
                        }
                    }
                    else
                        RedirectToAction("Index");
                }
                else
                    RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks model, string UserCommand)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Tasks.Add(tasks);
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

                        model.Task_Id = Guid.NewGuid();

                        // dummy default values, why are they NOT NULL? and not visible in forms???
                        model.Incident_Id = Guid.Empty;
                        model.Comments = "comments";
                        model.Task_Description = "description";
                        model.State = "state";

                        db.Tasks.Add(model);

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
            Tasks model = db.Tasks.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            //ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "TaskTypeId", "TaskCode", tasks.TaskTypeId);
            return View(model);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tasks model, string UserCommand)
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
                    //Tasks taskFromDB = db.Tasks.Find(tasks.RowId);
                    Tasks taskFromDB = db.Tasks.Where(e => e.Task_Id == model.Task_Id).FirstOrDefault();
                    //logger.Debug(string.Format("Edit Post GetDBModel [Id: {0}]", (tasks != null ? tasks.UniqueId.ToString() : "empty")));
                    if (model == null || taskFromDB == null)
                    {
                        return HttpNotFound();
                    }

                    //if (this.isSiteAdmin || tasks.AssignedToLoginName.Equals(this.userLoginName, StringComparison.InvariantCultureIgnoreCase) || tasks.SubstituteLoginName.Equals(this.userLoginName, StringComparison.InvariantCultureIgnoreCase))
                    {

                        //if (!string.IsNullOrEmpty(tasks.Comments))
                        //{
                        //    tasks.Comments = FieldValidator.EscapeRichText(tasks.Comments, Server);
                        //}

                        db.Entry(taskFromDB).State = EntityState.Modified;
                        taskFromDB.PrepareFieldsForUpdate(this.HttpContext.User);
                        FieldValidator.SetMultiSelectValues(this.Request, model, model.FieldsConfiguration, Enums.FormStates.Edit);
                        FieldValidator.AssignValues(taskFromDB, model, taskFromDB.FieldsConfiguration, DM.App.Library.Core.Enums.FormStates.Edit, true, Server);

                        db.SaveChanges();
                        //logger.Debug(string.Format("Edit Post End [Id: {0}]", (tasks != null ? tasks.UniqueId.ToString() : "empty")));
                        //return RedirectToAction("Index", HtmlTagsHelper.BuildQueryStringRouteValues(this.Request));
                        return RedirectToAction("Index", "Home", HtmlTagsHelper.BuildQueryStringRouteValues(this.Request));
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
            return View(model);

        }

        // GET: Tasks/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tasks tasks = db.Tasks.Find(id);
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
        //    Tasks tasks = db.Tasks.Find(id);
        //    db.Tasks.Remove(tasks);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
