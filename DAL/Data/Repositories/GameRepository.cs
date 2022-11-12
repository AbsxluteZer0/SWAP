using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Repositories
{
    public class GameRepository : List<Game>, Interfaces.IEntityRepository<Game>
    {
        public new void Add(Game item)
        {
            int prevId = this.Max(u => u.GameId as int?) ?? 0;
            item.GameId = prevId + 1;
            base.Add(item);
        }

        public void Delete(Game item)
        {
            base.Remove(item);
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<Game> GetAll()
        {
            return this;
        }

        public void Update(Game item)
        {
            throw new NotImplementedException();
        }
    }
}
