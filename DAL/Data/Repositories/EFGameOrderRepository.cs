using Microsoft.EntityFrameworkCore;
using SWAP.DAL.Data.Contexts;
using System.Collections;

namespace SWAP.DAL.Data.Repositories
{
    internal class EFGameOrderRepository : Interfaces.IEntityRepository<GameOrder>
    {
        private readonly GameStoreDbContext context;

        public EFGameOrderRepository(GameStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(GameOrder item)
        {
            context.GameOrders.Add(item);
        }

        public void Delete(GameOrder item)
        {
            context.GameOrders.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<GameOrder> GetAll()
        {
            return context.GameOrders
                .Include(g => g.Game)
                .Include(g => g.Order);
        }

        public IEnumerator<GameOrder> GetEnumerator()
        {
            return context.GameOrders
                .Include(g => g.Game)
                .Include(g => g.Order)
                .AsEnumerable().GetEnumerator();
        }

        public void Update(GameOrder item)
        {
            context.GameOrders.Update(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
