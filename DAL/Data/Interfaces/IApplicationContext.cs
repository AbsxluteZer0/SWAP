using SWAP.DAL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Interfaces
{
    public interface IApplicationContext
    {
        IEntityRepository<Game> Games { get; }
        IEntityRepository<GameGenre> GameGenres { get; }
        IEntityRepository<GameOrder> GameOrders { get; }
        IEntityRepository<Genre> Genres { get; }
        IEntityRepository<Order> Orders { get; }
        IEntityRepository<ShoppingCart> ShoppingCarts { get; }
        IEntityRepository<User> Users { get; }

        public void LoadData();

        public void SaveData();

        public void Clear();
    }
}
