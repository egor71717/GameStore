using GameStore.Entities;
using System.Collections.Generic;

namespace GameStore.UI.Models
{
    public class GameIndexViewModel: ILayoutViewModelGetable
    {
        public LayoutViewModel LayoutModel { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}