using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Repositories
{
    public class UserRepository : List<User>, Interfaces.IEntityRepository<User>
    {
        public new void Add(User item)
        {
            int prevId = this.Max(u => u.UserId as int?) ?? 0;
            item.UserId = prevId + 1;
            base.Add(item);
        }

        public void Delete(User item)
        {
            base.Remove(item);
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<User> GetAll()
        {
            return this;
        }

        public void Update(User item)
        {
            User user = Find(u => u.UserId == item.UserId);

            if (user == null) 
            {
                base.Add(item);
                return;                 
            };

            item.UserId = user.UserId;
            base.Add(item);
        }
    }
}
