using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Entities
{
    public class PublisherImage
    {
        public Int32 Id { get; set; }
        public Byte[] Image { get; set; }
        public String Format { get; set; }

        //public virtual Publisher Publisher { get; set; }
    }
}
