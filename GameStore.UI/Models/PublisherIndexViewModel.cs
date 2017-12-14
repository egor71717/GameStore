using GameStore.Entities;
using System.Collections.Generic;

namespace GameStore.UI.Models
{
    public class PublisherIndexViewModel: ILayoutViewModelGetable
    {
        public LayoutViewModel LayoutModel { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
    }
}