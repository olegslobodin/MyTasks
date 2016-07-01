using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTasks.DataAccess;
using MyTasks.Models;

namespace MyTasks.Controllers
{
    public class TaskGroupsController : Controller
    {
        private Context db = new Context();

        // GET: TaskGroups
        public ActionResult Index()
        {
            var result = Json(db.TaskGroups.ToList(), JsonRequestBehavior.AllowGet);
            return result;
        }

        // GET: TaskGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskGroup taskGroup = db.TaskGroups.Find(id);
            if (taskGroup == null)
            {
                return HttpNotFound();
            }
            return View(taskGroup);
        }

        // GET: TaskGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskGroups/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TaskGroup taskGroup)
        {
            if (ModelState.IsValid)
            {
                db.TaskGroups.Add(taskGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskGroup);
        }

        // GET: TaskGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskGroup taskGroup = db.TaskGroups.Find(id);
            if (taskGroup == null)
            {
                return HttpNotFound();
            }
            return View(taskGroup);
        }

        // POST: TaskGroups/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TaskGroup taskGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskGroup);
        }

        // GET: TaskGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskGroup taskGroup = db.TaskGroups.Find(id);
            if (taskGroup == null)
            {
                return HttpNotFound();
            }
            return View(taskGroup);
        }

        // POST: TaskGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskGroup taskGroup = db.TaskGroups.Find(id);
            db.TaskGroups.Remove(taskGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
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
