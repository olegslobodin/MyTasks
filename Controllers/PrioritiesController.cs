using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MyTasks.DataAccess;
using MyTasks.Models;

namespace MyTasks.Controllers
{
    public class PrioritiesController : Controller
    {
        private Context db = new Context();

        public List<Priority> GetSortedPriorities()
        {
            return db.Priorities.OrderBy(p => p.PriorityLevel).ToList();
        }

        public Priority GetPriorityById(int id)
        {
            return db.Priorities.First(p => p.ID == id);
        }

        public ActionResult ChangeTaskPriority(int? id, string act)
        {
            var task = db.Tasks.First(t => t.ID == id);
            var priorityController = new PrioritiesController();
            var priorities = priorityController.GetSortedPriorities();
            var pos = priorities.IndexOf(priorities.First(p => p.ID == task.PriorityId));
            if (act == "Up")
            {
                if (pos + 1 < priorities.Count)
                {
                    task.PriorityId = priorities.ElementAt(pos + 1).ID;
                    db.SaveChanges();
                }
            }
            else
            {
                if (pos > 0)
                {
                    task.PriorityId = priorities.ElementAt(pos - 1).ID;
                    db.SaveChanges();
                }
            }
            return PartialView("~/Views/Priorities/_Priority.cshtml", priorityController.GetPriorityById(task.PriorityId));
        }

        // GET: Priorities
        public ActionResult Index()
        {
            return View(GetSortedPriorities());
        }

        // GET: Priorities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        // GET: Priorities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Priorities/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PriorityLevel,Title")] Priority priority)
        {
            if (ModelState.IsValid)
            {
                db.Priorities.Add(priority);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priority);
        }

        // GET: Priorities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        // POST: Priorities/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PriorityLevel,Title")] Priority priority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priority);
        }

        // GET: Priorities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        // POST: Priorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Priority priority = db.Priorities.Find(id);
            db.Priorities.Remove(priority);
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
