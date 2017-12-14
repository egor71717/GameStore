using GameStore.Entities;

namespace GameStore.UI.Models
{
    public class PublisherDetailViewModel : ILayoutViewModelGetable
    {
        public LayoutViewModel LayoutModel { get; set; }
        public Publisher Publisher { get; set; }
    }
}