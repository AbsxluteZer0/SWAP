using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Repositories
{
    public class GameOrderRepository : List<GameOrder>, Interfaces.IEntityRepository<GameOrder>
    {
        public new void Add(GameOrder item)
        {
            if (item == null) return;

            int prevId = this.Max(u => u.RelationId as int?) ?? 0;
            item.RelationId = prevId + 1;

            if (item.Game != null)
                item.GameId = item.Game.GameId;
            if (item.Order != null)
                item.OrderId = item.Order.TransactionKey;

            base.Add(item);
        }

        public void Delete(GameOrder item)
        {
            base.Remove(item);
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<GameOrder> GetAll()
        {
            return this;
        }

        public void Update(GameOrder item)
        {
            throw new NotImplementedException();
        }
    }
}
