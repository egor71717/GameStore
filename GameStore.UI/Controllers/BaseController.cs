using GameStore.EntityFramework;
using GameStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext _dbContext = ContextSingleton.GetInstance();
        protected LayoutViewModel BaseModel { get; set; }

        public BaseController()
        {
            var model = new LayoutViewModel();
            model.HeaderCategories = _dbContext.Categories.ToList();
            this.BaseModel = model;
        }
    }
}