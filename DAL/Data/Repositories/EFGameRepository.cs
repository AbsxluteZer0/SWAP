using SWAP.DAL.Data.Contexts;
using System.Collections;

namespace SWAP.DAL.Data.Repositories
{
    internal class EFGameRepository : Interfaces.IEntityRepository<Game>
    {
        private readonly GameStoreDbContext context;

        public EFGameRepository(GameStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(Game item)
        {
            context.Games.Add(item);
        }

        public void Delete(Game item)
        {
            context.Games.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Game> GetAll()
        {
            return context.Games;
        }

        public IEnumerator<Game> GetEnumerator()
        {
            return context.Games.AsEnumerable().GetEnumerator();
        }

        public void Update(Game item)
        {
            context.Games.Update(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
