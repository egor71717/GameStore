using System;
using System.Collections.Generic;

namespace GameStore.Entities
{
    public partial class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Purchases = new HashSet<Purchase>();
            this.Games = new HashSet<Game>();
            this.Roles = new HashSet<Role>();
        }

        public Int32 Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public Int32 Balance { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
