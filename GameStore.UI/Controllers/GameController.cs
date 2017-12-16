using GameStore.EntityFramework;
using GameStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Controllers
{
    public class GameController : BaseController
    {
        public ActionResult Index()
        {
            var model = new GameIndexViewModel();
            model.Games = DbContext.Games
                .Include("Publisher")
                .Include("Categories")
                .ToList();
            model.LayoutModel = this.BaseModel;
            return View(model);
        }
        public ActionResult Details(Int32 id)
        {
            var model = new GameDetailsViewModel();
            model.Game = DbContext.Games
                .Include("Publisher")
                .Include("Categories")
                .Include("Comments.User.Avatar")
                .Where(g => g.Id == id)
                .FirstOrDefault();
            model.LayoutModel = this.BaseModel;
            return View(model);
        }
    }
}