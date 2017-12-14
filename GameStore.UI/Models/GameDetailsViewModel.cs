using GameStore.Entities;

namespace GameStore.UI.Models
{
    public class GameDetailsViewModel : ILayoutViewModelGetable
    {
        public Game Game { get; set; }
        public LayoutViewModel LayoutModel { get; set; }
    }
}