using GameStore.Entities;
using System.Collections.Generic;

namespace GameStore.UI.Models
{
    public class LayoutViewModel
    {
        public IEnumerable<Category> HeaderCategories { get; set; }
    }
}