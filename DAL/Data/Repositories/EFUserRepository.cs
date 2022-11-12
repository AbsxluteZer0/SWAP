using Microsoft.EntityFrameworkCore;
using SWAP.DAL.Data.Contexts;
using System.Collections;

namespace SWAP.DAL.Data.Repositories
{
    internal class EFUserRepository : Interfaces.IEntityRepository<User>
    {
        private readonly GameStoreDbContext context;

        public EFUserRepository(GameStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(User item)
        {
            context.Users.Add(item);
        }

        public void Delete(User item)
        {
            context.Users.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users
                .Include(u => u.Orders);
        }

        public IEnumerator<User> GetEnumerator()
        {
            return context.Users
                .Include(u => u.Orders)
                .AsEnumerable().GetEnumerator();
        }

        public void Update(User item)
        {
            context.Users.Update(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
