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
    public class GameSetsController : Controller
    {
        private Entities db = new Entities();
        public ActionResult bootstrap()
        {
            return View();
        }

        // GET: GameSets
        public ActionResult Index()
        {
            var gameSet = db.GameSet.Include(g => g.PublisherSet);
            return View(gameSet.ToList());
        }

        // GET: GameSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSet gameSet = db.GameSet.Find(id);
            if (gameSet == null)
            {
                return HttpNotFound();
            }
            return View(gameSet);
        }

        // GET: GameSets/Create
        public ActionResult Create()
        {
            ViewBag.Publisher_Id = new SelectList(db.PublisherSet, "Id", "Name");
            return View();
        }

        // POST: GameSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Category,Date,Requirements,Discount,Picture,Publisher_Id")] GameSet gameSet)
        {
            if (ModelState.IsValid)
            {
                db.GameSet.Add(gameSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Publisher_Id = new SelectList(db.PublisherSet, "Id", "Name", gameSet.Publisher_Id);
            return View(gameSet);
        }

        // GET: GameSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSet gameSet = db.GameSet.Find(id);
            if (gameSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Publisher_Id = new SelectList(db.PublisherSet, "Id", "Name", gameSet.Publisher_Id);
            return View(gameSet);
        }

        // POST: GameSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Category,Date,Requirements,Discount,Picture,Publisher_Id")] GameSet gameSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Publisher_Id = new SelectList(db.PublisherSet, "Id", "Name", gameSet.Publisher_Id);
            return View(gameSet);
        }

        // GET: GameSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSet gameSet = db.GameSet.Find(id);
            if (gameSet == null)
            {
                return HttpNotFound();
            }
            return View(gameSet);
        }

        // POST: GameSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameSet gameSet = db.GameSet.Find(id);
            db.GameSet.Remove(gameSet);
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
