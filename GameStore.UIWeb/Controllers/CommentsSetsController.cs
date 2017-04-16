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
    public class CommentsSetsController : Controller
    {
        private Entities db = new Entities();

        // GET: CommentsSets
        public ActionResult Index()
        {
            var commentsSet = db.CommentsSet.Include(c => c.GameSet).Include(c => c.UserSet);
            return View(commentsSet.ToList());
        }

        // GET: CommentsSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentsSet commentsSet = db.CommentsSet.Find(id);
            if (commentsSet == null)
            {
                return HttpNotFound();
            }
            return View(commentsSet);
        }

        // GET: CommentsSets/Create
        public ActionResult Create()
        {
            ViewBag.Game_Id = new SelectList(db.GameSet, "Id", "Name");
            ViewBag.User_Id = new SelectList(db.UserSet, "Id", "Login");
            return View();
        }

        // POST: CommentsSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,DateTime,User_Id,Game_Id")] CommentsSet commentsSet)
        {
            if (ModelState.IsValid)
            {
                db.CommentsSet.Add(commentsSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Game_Id = new SelectList(db.GameSet, "Id", "Name", commentsSet.Game_Id);
            ViewBag.User_Id = new SelectList(db.UserSet, "Id", "Login", commentsSet.User_Id);
            return View(commentsSet);
        }

        // GET: CommentsSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentsSet commentsSet = db.CommentsSet.Find(id);
            if (commentsSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Game_Id = new SelectList(db.GameSet, "Id", "Name", commentsSet.Game_Id);
            ViewBag.User_Id = new SelectList(db.UserSet, "Id", "Login", commentsSet.User_Id);
            return View(commentsSet);
        }

        // POST: CommentsSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,DateTime,User_Id,Game_Id")] CommentsSet commentsSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentsSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Game_Id = new SelectList(db.GameSet, "Id", "Name", commentsSet.Game_Id);
            ViewBag.User_Id = new SelectList(db.UserSet, "Id", "Login", commentsSet.User_Id);
            return View(commentsSet);
        }

        // GET: CommentsSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentsSet commentsSet = db.CommentsSet.Find(id);
            if (commentsSet == null)
            {
                return HttpNotFound();
            }
            return View(commentsSet);
        }

        // POST: CommentsSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentsSet commentsSet = db.CommentsSet.Find(id);
            db.CommentsSet.Remove(commentsSet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CommentsForGame()
        {
            return View();
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
