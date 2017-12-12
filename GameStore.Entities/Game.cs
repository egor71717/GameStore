using System;
using System.Collections.Generic;

namespace GameStore.Entities
{
    public class Game
    {
        public Game()
        {
            this.Comments = new HashSet<Comment>();
            this.Purchases = new HashSet<Purchase>();
            this.Users = new HashSet<User>();
        }

        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        public String Category { get; set; }
        public DateTime? Date { get; set; }
        public String Requirements { get; set; }
        public Double Discount { get; set; }
        public String Picture { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
