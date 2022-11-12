using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Repositories
{
    public class OrderRepository : List<Order>, Interfaces.IEntityRepository<Order>
    {
        public new void Add(Order item)
        {
            if (item == null) return;

            if (item.User != null)
                item.UserId = item.User.UserId;

            item.TransactionKey = KeyGenerator(16);

            base.Add(item);
        }

        public void Delete(Order item)
        {
            base.Remove(item);
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<Order> GetAll()
        {
            return this;
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
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
