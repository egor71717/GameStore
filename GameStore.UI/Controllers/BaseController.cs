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
        protected ApplicationDbContext DbContext = ContextSingleton.GetInstance();
        protected LayoutViewModel BaseModel { get; set; }

        static BaseController()
        {
            //comment when deploying
            //ContextSingleton.connectionStringName = "DevelopementLocalConnection";
        }

        public BaseController()
        {
            var model = new LayoutViewModel();
            model.HeaderCategories = DbContext.Categories.ToList();
            this.BaseModel = model;
        }
    }
}