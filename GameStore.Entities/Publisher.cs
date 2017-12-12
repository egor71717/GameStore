using System;
using System.Collections.Generic;

namespace GameStore.Entities
{
    public class Publisher
    {
        public Publisher()
        {
            this.Games = new HashSet<Game>();
        }

        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Country { get; set; }
        public String Logo { get; set; }
        public String Description { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
