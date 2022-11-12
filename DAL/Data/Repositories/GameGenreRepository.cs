using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Repositories
{
    public class GameGenreRepository : List<GameGenre>, Interfaces.IEntityRepository<GameGenre>
    {
        public new void Add(GameGenre item)
        {
            int prevId = this.Max(u => u.RelationId as int?) ?? 0;
            item.RelationId = prevId + 1;
            item.GameId = item.Game.GameId;
            item.GenreId = item.Genre.GenreId;

            base.Add(item);
        }

        public void Delete(GameGenre item)
        {
            base.Remove(item);
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<GameGenre> GetAll()
        {
            return this;
        }

        public void Update(GameGenre item)
        {
            throw new NotImplementedException();
        }
    }
}
