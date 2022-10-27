using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KountryClubKennels.Models;

namespace KountryClubKennels.Controllers
{
    public class DogsController : Controller
    {
        private KCKContext db = new KCKContext();

        // GET: Dogs
        public ActionResult Index()
        {
            return View(db.dogs.ToList());
        }

        // GET: Dogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogs dogs = db.dogs.Find(id);
            if (dogs == null)
            {
                return HttpNotFound();
            }
            return View(dogs);
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,photoPath,breed,akctype,birthday,name")] Dogs dogs)
        {
            if (ModelState.IsValid)
            {
                db.dogs.Add(dogs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dogs);
        }

        // GET: Dogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogs dogs = db.dogs.Find(id);
            if (dogs == null)
            {
                return HttpNotFound();
            }
            return View(dogs);
        }

        // POST: Dogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,photoPath,breed,akctype,birthday,name")] Dogs dogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dogs);
        }

        // GET: Dogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dogs dogs = db.dogs.Find(id);
            if (dogs == null)
            {
                return HttpNotFound();
            }
            return View(dogs);
        }

        // POST: Dogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dogs dogs = db.dogs.Find(id);
            db.dogs.Remove(dogs);
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
