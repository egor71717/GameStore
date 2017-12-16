using GameStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Controllers
{
    public class PublisherController : BaseController
    {
        public ActionResult Index()
        {
            var model = new PublisherIndexViewModel();
            model.Publishers = this.DbContext.Publishers
                .ToList();
            model.LayoutModel = this.BaseModel;
            return View(model);
        }

        public ActionResult Details(Int32 id)
        {
            var model = new PublisherDetailViewModel();
            model.Publisher = this.DbContext.Publishers
                .Where(pub => pub.Id == id)
                .FirstOrDefault();
            model.LayoutModel = this.BaseModel;
            return View(model);
        }

        public ActionResult Games(Int32 id)
        {
            var model = new PublisherGamesViewModel();
            model.PublisherName = this.DbContext.Publishers
                .Where(pub => pub.Id == id)
                .Select(pub => pub.Name)
                .FirstOrDefault();
            model.GamesModel = new GameIndexViewModel()
            {
                Games = this.DbContext.Games
                    .Where(game => game.Publisher.Id == id)
                    .ToList()
            };
            model.LayoutModel = this.BaseModel;
            return View(model);
        }
    }
}