using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Entities
{
    public class Comment
    {
        public Int32 Id { get; set; }
        public String Text { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
