using Microsoft.EntityFrameworkCore;
using SWAP.DAL.Data.Contexts;
using System.Collections;

namespace SWAP.DAL.Data.Repositories
{
    internal class EFShoppingCartRepository : Interfaces.IEntityRepository<ShoppingCart>
    {
        private readonly GameStoreDbContext context;

        public EFShoppingCartRepository(GameStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(ShoppingCart item)
        {
            context.ShoppingCarts.Add(item);
        }

        public void Delete(ShoppingCart item)
        {
            context.ShoppingCarts.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return context.ShoppingCarts
                .Include(c => c.User)
                .Include(c => c.Game);
        }

        public IEnumerator<ShoppingCart> GetEnumerator()
        {
            return context.ShoppingCarts
                .Include(c => c.User)
                .Include(c => c.Game)
                .AsEnumerable().GetEnumerator();
        }

        public void Update(ShoppingCart item)
        {
            context.ShoppingCarts.Update(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
