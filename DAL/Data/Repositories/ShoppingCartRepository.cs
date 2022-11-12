using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Repositories
{
    public class ShoppingCartRepository : List<ShoppingCart>, Interfaces.IEntityRepository<ShoppingCart>
    {
        public new void Add(ShoppingCart item)
        {
            if (item == null) return;

            int prevId = this.Max(u => u.RelationId as int?) ?? 0;
            item.RelationId = prevId + 1;

            if (item.User != null)
                item.UserId = item.User.UserId;
            if (item.Game != null)
                item.GameId = item.Game.GameId;

            base.Add(item);
        }

        public void Delete(ShoppingCart item)
        {
            base.Remove(item);
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return this;
        }

        public void Update(ShoppingCart item)
        {
            throw new NotImplementedException();
        }
    }
}
