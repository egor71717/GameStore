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
    public class UserSetsController : Controller
    {
        private Entities db = new Entities();

        // GET: UserSets
        public ActionResult Index()
        {
            var userSet = db.UserSet.Include(u => u.RoleSet);
            return View(userSet.ToList());
        }

        // GET: UserSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSet userSet = db.UserSet.Find(id);
            if (userSet == null)
            {
                return HttpNotFound();
            }
            return View(userSet);
        }

        // GET: UserSets/Create
        public ActionResult Create()
        {
            ViewBag.Role_Id = new SelectList(db.RoleSet, "Id", "Name");
            return View();
        }

        // POST: UserSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Password,Balance,LastName,FirstName,Role_Id")] UserSet userSet)
        {
            if (ModelState.IsValid)
            {
                db.UserSet.Add(userSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role_Id = new SelectList(db.RoleSet, "Id", "Name", userSet.Role_Id);
            return View(userSet);
        }

        // GET: UserSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSet userSet = db.UserSet.Find(id);
            if (userSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_Id = new SelectList(db.RoleSet, "Id", "Name", userSet.Role_Id);
            return View(userSet);
        }

        // POST: UserSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Password,Balance,LastName,FirstName,Role_Id")] UserSet userSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_Id = new SelectList(db.RoleSet, "Id", "Name", userSet.Role_Id);
            return View(userSet);
        }

        // GET: UserSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSet userSet = db.UserSet.Find(id);
            if (userSet == null)
            {
                return HttpNotFound();
            }
            return View(userSet);
        }

        // POST: UserSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserSet userSet = db.UserSet.Find(id);
            db.UserSet.Remove(userSet);
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
