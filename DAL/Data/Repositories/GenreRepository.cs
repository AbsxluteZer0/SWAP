using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Repositories
{
    public class GenreRepository : List<Genre>, Interfaces.IEntityRepository<Genre>
    {
        public new void Add(Genre item)
        {
            int prevId = this.Max(u => u.GenreId as int?) ?? 0;
            item.GenreId = prevId + 1;
            base.Add(item);
        }

        public void Delete(Genre item)
        {
            base.Remove(item);
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<Genre> GetAll()
        {
            return this;
        }

        public void Update(Genre item)
        {
            throw new NotImplementedException();
        }
    }
}
