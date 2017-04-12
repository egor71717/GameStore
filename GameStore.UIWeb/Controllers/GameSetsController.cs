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
        public ActionResult Main()
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

        //Queries
        //new in catalog
        public ActionResult ShowNewGames()
        {
            var foundGames = from game in db.GameSet
                             where game.Date > new DateTime(2017, 4, 7)
                             orderby game.Date descending
                             select game;

            return View(foundGames);
        }

        //cheap games
        public ActionResult ShowCheapGames()
        {
            var foundGames = from game in db.GameSet
                             where game.Price < 20
                             orderby game.Price ascending
                             select game;

            return View(foundGames);
        }

        //filter by category
        public ActionResult ShowGamesWithCategory(string category)
        {
            var foundGames = from game in db.GameSet
                             where game.Category.Contains(category)
                             orderby game.Date descending
                             select game;

            return View(foundGames);
        }

        //sort by name
        public ActionResult SortByName()
        {
            var foundGames = from game in db.GameSet
                             orderby game.Name ascending
                             select game;

            return View("Main", foundGames);
        }

        //sort by date
        public ActionResult SortByDate()
        {
            var foundGames = from game in db.GameSet
                             orderby game.Date descending
                             select game;

            return View("Main", foundGames);
        }

        //sort by price
        public ActionResult SortByPrice()
        {
            var foundGames = from game in db.GameSet
                             orderby game.Price ascending
                             select game;

            return View("Main",foundGames);
        }
    }
}
