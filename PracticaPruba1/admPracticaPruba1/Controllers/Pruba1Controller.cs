using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admPracticaPruba1.Models;

namespace admPracticaPruba1.Controllers
{
    public class Pruba1Controller : Controller
    {
        private DataContext db = new DataContext();

        // GET: Pruba1
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Pruba1.ToList());
        }

        // GET: Pruba1/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pruba1 pruba1 = db.Pruba1.Find(id);
            if (pruba1 == null)
            {
                return HttpNotFound();
            }
            return View(pruba1);
        }

        // GET: Pruba1/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pruba1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZambranaID,FriendofZambrana,Place,Email,Birthdate")] Pruba1 pruba1)
        {
            if (ModelState.IsValid)
            {
                db.Pruba1.Add(pruba1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pruba1);
        }

        // GET: Pruba1/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pruba1 pruba1 = db.Pruba1.Find(id);
            if (pruba1 == null)
            {
                return HttpNotFound();
            }
            return View(pruba1);
        }

        // POST: Pruba1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZambranaID,FriendofZambrana,Place,Email,Birthdate")] Pruba1 pruba1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pruba1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pruba1);
        }

        // GET: Pruba1/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pruba1 pruba1 = db.Pruba1.Find(id);
            if (pruba1 == null)
            {
                return HttpNotFound();
            }
            return View(pruba1);
        }

        // POST: Pruba1/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pruba1 pruba1 = db.Pruba1.Find(id);
            db.Pruba1.Remove(pruba1);
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
