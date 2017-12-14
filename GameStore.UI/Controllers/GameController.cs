using GameStore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext _dbContext = ContextSingleton.GetInstance();

        public ActionResult Index()
        {
            var games = _dbContext.Games
                .Include("Publisher")
                .Include("Categories")
                .ToList();
            return View(games);
        }
    }
}