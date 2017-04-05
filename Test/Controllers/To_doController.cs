using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class To_doController : Controller
    {
        private TestContext db = new TestContext();

        // GET: To_do
        public ActionResult Index()
        {
            return View(db.To_do.ToList());
        }

        // GET: To_do/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            To_do to_do = db.To_do.Find(id);
            if (to_do == null)
            {
                return HttpNotFound();
            }
            return View(to_do);
        }

        // GET: To_do/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: To_do/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "To_doID,Description,IsDone")] To_do to_do)
        {
            if (ModelState.IsValid)
            {
                db.To_do.Add(to_do);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(to_do);
        }

        // GET: To_do/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            To_do to_do = db.To_do.Find(id);
            if (to_do == null)
            {
                return HttpNotFound();
            }
            return View(to_do);
        }

        // POST: To_do/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "To_doID,Description,IsDone")] To_do to_do)
        {
            if (ModelState.IsValid)
            {
                db.Entry(to_do).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(to_do);
        }

        // GET: To_do/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            To_do to_do = db.To_do.Find(id);
            if (to_do == null)
            {
                return HttpNotFound();
            }
            return View(to_do);
        }

        // POST: To_do/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            To_do to_do = db.To_do.Find(id);
            db.To_do.Remove(to_do);
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
