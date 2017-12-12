using System;
using System.Collections.Generic;

namespace GameStore.Entities
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Privileges { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
