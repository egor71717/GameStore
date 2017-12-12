using System;

namespace GameStore.Entities
{
    public class Purchase
    {
        public Int32 Id { get; set; }
        public DateTime? Date { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
