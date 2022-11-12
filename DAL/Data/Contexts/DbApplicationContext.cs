using SWAP.DAL.Data.Interfaces;
using SWAP.DAL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Contexts
{
    internal class DbApplicationContext : Interfaces.IApplicationContext
    {      
        public IEntityRepository<Game> Games { get; private set; }
        public IEntityRepository<GameGenre> GameGenres { get; private set; }
        public IEntityRepository<GameOrder> GameOrders { get; private set; }
        public IEntityRepository<Genre> Genres { get; private set; }
        public IEntityRepository<Order> Orders { get; private set; }
        public IEntityRepository<ShoppingCart> ShoppingCarts { get; private set; }
        public IEntityRepository<User> Users { get; private set; }

        private readonly GameStoreDbContext context;

        public DbApplicationContext(string dbConnectionString)
        {
            context = new GameStoreDbContext(dbConnectionString);

            Games = new EFGameRepository(context);
            GameGenres = new EFGameGenreRepository(context);
            GameOrders = new EFGameOrderRepository(context);
            Genres = new EFGenreRepository(context);
            Orders = new EFOrderRepository(context);
            ShoppingCarts = new EFShoppingCartRepository(context);
            Users = new EFUserRepository(context);
        }

        public void LoadData() { /*db doesn't need to explicitly load all data*/ }        

        public void SaveData()
        {
            context.SaveChanges();
        }

        public void Clear()
        {
            context.Database.EnsureDeleted();
        }
    }
}
