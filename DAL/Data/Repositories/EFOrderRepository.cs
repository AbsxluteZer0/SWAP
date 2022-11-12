using Microsoft.EntityFrameworkCore;
using SWAP.DAL.Data.Contexts;
using System.Collections;

namespace SWAP.DAL.Data.Repositories
{
    internal class EFOrderRepository : Interfaces.IEntityRepository<Order>
    {
        private readonly GameStoreDbContext context;

        public EFOrderRepository(GameStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(Order item)
        {
            if (item != null)
                item.TransactionKey = KeyGenerator(16);
            using (context)
            {
                context.Orders.Add(item);
            }                            
        }

        public void Delete(Order item)
        {
            context.Orders.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Order> GetAll()
        {
            using (context)
            {
                return context.Orders
                    .Include(o => o.User);
            }            
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return context.Orders
                .Include(o => o.User)
                .AsEnumerable().GetEnumerator();
        }

        public void Update(Order item)
        {
            context.Orders.Update(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private string KeyGenerator(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
