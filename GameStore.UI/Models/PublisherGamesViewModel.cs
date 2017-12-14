using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.UI.Models
{
    public class PublisherGamesViewModel : ILayoutViewModelGetable
    {
        public LayoutViewModel LayoutModel { get; set ; }
        public GameIndexViewModel GamesModel { get; set; }
        public String PublisherName { get; set; }
    }
}