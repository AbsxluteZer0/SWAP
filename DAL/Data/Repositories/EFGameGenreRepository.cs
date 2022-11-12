using Microsoft.EntityFrameworkCore;
using SWAP.DAL.Data.Contexts;
using System.Collections;

namespace SWAP.DAL.Data.Repositories
{
    internal class EFGameGenreRepository : Interfaces.IEntityRepository<GameGenre>
    {
        private readonly GameStoreDbContext context;

        public EFGameGenreRepository(GameStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(GameGenre item)
        {
            context.GameGenres.Add(item);
        }

        public void Delete(GameGenre item)
        {
            context.GameGenres.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<GameGenre> GetAll()
        {
            return context.GameGenres
                .Include(g => g.Game)
                .Include(g => g.Genre);
        }

        public IEnumerator<GameGenre> GetEnumerator()
        {
            return context.GameGenres
                .Include(g => g.Game)
                .Include(g => g.Genre)
                .AsEnumerable().GetEnumerator();
        }

        public void Update(GameGenre item)
        {
            context.GameGenres.Update(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
