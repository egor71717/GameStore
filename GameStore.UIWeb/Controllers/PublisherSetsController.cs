using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameStore.UIWeb.Models;

namespace GameStore.UIWeb.Controllers
{
    public class PublisherSetsController : Controller
    {
        private Entities db = new Entities();

        // GET: PublisherSets
        public ActionResult Index()
        {
            return View(db.PublisherSet.ToList());
        }

        // GET: PublisherSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherSet publisherSet = db.PublisherSet.Find(id);
            if (publisherSet == null)
            {
                return HttpNotFound();
            }
            return View(publisherSet);
        }

        // GET: PublisherSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Country,Logo,Description")] PublisherSet publisherSet)
        {
            if (ModelState.IsValid)
            {
                db.PublisherSet.Add(publisherSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publisherSet);
        }

        // GET: PublisherSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherSet publisherSet = db.PublisherSet.Find(id);
            if (publisherSet == null)
            {
                return HttpNotFound();
            }
            return View(publisherSet);
        }

        // POST: PublisherSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Country,Logo,Description")] PublisherSet publisherSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisherSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisherSet);
        }

        // GET: PublisherSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherSet publisherSet = db.PublisherSet.Find(id);
            if (publisherSet == null)
            {
                return HttpNotFound();
            }
            return View(publisherSet);
        }

        // POST: PublisherSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublisherSet publisherSet = db.PublisherSet.Find(id);
            db.PublisherSet.Remove(publisherSet);
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
