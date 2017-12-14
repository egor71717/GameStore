using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Entities
{
    public class Category
    {
        public Category()
        {
            this.Games = new HashSet<Game>();
        }

        public Int32 Id { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
