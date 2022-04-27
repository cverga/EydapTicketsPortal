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
    public class IncidentsGenController : Controller
    {
        private ExternalDBEntities db = new ExternalDBEntities();

        // GET: Incidents
        public ActionResult Index()
        {
            var incidents = db.Incidents;
            return View(incidents.ToList());
        }

        // GET: Incidents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidents incidents = db.Incidents.Find(id);
            if (incidents == null)
            {
                return HttpNotFound();
            }
            return View(incidents);
        }

        // GET: Incidents/Create
        //public ActionResult Create()
        //{
        //    var model = new Incidents();
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }
        //    return View(model);
        //}

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Incidents incidents, string UserCommand)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(UserCommand) || UserCommand == "Cancel")
        //            return RedirectToAction("Index", "Home", HtmlTagsHelper.BuildQueryStringRouteValues(this.Request));

        //        {
        //            if (ModelState.IsValid)
        //            {
        //                incidents.PrepareFields(this.HttpContext.User);
        //                this.ValidateModel(incidents);

        //                FieldValidator.SetMultiSelectValues(this.Request, incidents, incidents.FieldsConfiguration, Enums.FormStates.New);
        //                FieldValidator.EscapeRichText(incidents, incidents.FieldsConfiguration, Enums.FormStates.New, Server);

        //                incidents.TT_Id = Guid.NewGuid();

        //                db.Incidents.Add(incidents);

        //                db.SaveChanges();

        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //                foreach (var error in ModelState)
        //                {
        //                    foreach (var err in error.Value.Errors)
        //                    {
        //                        if (err.Exception != null)
        //                            sb.AppendFormat("{0}: {1}{2}", error.Key, err.Exception.Message, Environment.NewLine);
        //                        else
        //                            sb.AppendFormat("{0}: {1}{2}", error.Key, err.ErrorMessage, Environment.NewLine);
        //                    }
        //                }
        //                throw new Exception(sb.ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        //logger.Error(string.Format("Create.Post [{0} - ReqId: {1} - User: {2}]", hostWebUrl, requests.SPRequestId, this.userLoginName), ex);
        //    }
        //    return View(incidents);
        //}

        // GET: Tasks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "TaskTypeId", "TaskCode", tasks.TaskTypeId);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Task_Id,Task_Description,Comments,State,TaskTypeId,Incident_Id,SynergeioEpemvasis,ControlDate,ControlTime,VardiaSynergeiouEpemvasis,ArithosAtomonSynergeiouEpemvasis,Porisma,Energeies,PositionOfGeotrisi,ResultsOfChemeio,Remarks,MAP,VanaDiametros,AgogosDiametros,MetritisDiametros,PyrosvestikiParoxiDiametros,ZoniPiesis,Eidopoiisi,HmerominiaApomonosis,OraApomonosis,EkplisiTermatos,PyrosvestikouGeranouDiametros,HmerominiaAnaxorisis,OraAnaxorisis,HmerominiaAfixis,OraAfixis,HmerominiaEpistrofis,OraEpistrofis,HmerominiaEpanaforas,OraEpanaforas,EidosEpanaforas,ArithmosAtomonSynergeiouEpanaforas,VardiaSynergeiouApomonosis,VardiaSynergeiouEpanaforas,ArirthosVanonPouXeiristikan,KatastasiVanonPouXeiristikan,ThesiVanonPouXeiristikan")] Tasks tasks)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tasks).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "TaskTypeId", "TaskCode", tasks.TaskTypeId);
        //    return View(tasks);
        //}

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

        [HttpGet]
        public ActionResult DetailsPartialView(Guid? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidents incidents = db.Incidents.Find(id);
            if (incidents == null)
            {
                return HttpNotFound();
            }
            return PartialView(incidents);

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
