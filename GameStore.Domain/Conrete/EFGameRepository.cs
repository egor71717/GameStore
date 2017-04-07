using GameStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Conrete
{
    class EFGameRepository : IGameRepository
    {
        public IEnumerable<Game> Games
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
