using SWAP.DAL.Data.Contexts;
using System.Collections;

namespace SWAP.DAL.Data.Repositories
{
    internal class EFGenreRepository : Interfaces.IEntityRepository<Genre>
    {
        private readonly GameStoreDbContext context;

        public EFGenreRepository(GameStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(Genre item)
        {
            context.Genres.Add(item);
        }

        public void Delete(Genre item)
        {
            context.Genres.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genres;
        }

        public IEnumerator<Genre> GetEnumerator()
        {
            return context.Genres.AsEnumerable().GetEnumerator();
        }

        public void Update(Genre item)
        {
            context.Genres.Update(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
