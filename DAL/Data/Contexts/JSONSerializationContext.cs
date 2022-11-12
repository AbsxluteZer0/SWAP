using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using SWAP.DAL.Data.Static;
using SWAP.DAL.Data.Interfaces;
using SWAP.DAL.Data.Repositories;

namespace SWAP.DAL.Data.Contexts
{
    public class JSONSerializationContext : IApplicationContext
    {   
        public string ConnectionString { get; private set; }

        public IEntityRepository<Game> Games { get; private set; }
        public IEntityRepository<GameGenre> GameGenres { get; private set; }
        public IEntityRepository<GameOrder> GameOrders { get; private set; }
        public IEntityRepository<Genre> Genres { get; private set; }
        public IEntityRepository<Order> Orders { get; private set; }
        public IEntityRepository<ShoppingCart> ShoppingCarts { get; private set; }
        public IEntityRepository<User> Users { get; private set; }

        public JSONSerializationContext(string connectionString)
        {
            ConnectionString = connectionString;

            Games = new GameRepository();
            GameGenres = new GameGenreRepository();
            GameOrders = new GameOrderRepository();
            Genres = new GenreRepository();
            Orders = new OrderRepository();
            ShoppingCarts = new ShoppingCartRepository();
            Users = new UserRepository();
        }

        public void LoadData()
        {
            using (FileStream fileStream = File.OpenRead(Path.Combine(ConnectionString, Constants.GamesFileName)))
            {
                GameRepository? deserializedGames = JsonSerializer.Deserialize<GameRepository>(fileStream);
                Games = deserializedGames == null ? new GameRepository() : deserializedGames;
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.OpenRead(Path.Combine(ConnectionString, Constants.GameGenresFileName)))
            {
                GameGenreRepository? deserializedGameGenres = JsonSerializer.Deserialize<GameGenreRepository>(fileStream);
                GameGenres = deserializedGameGenres == null ? new GameGenreRepository() : deserializedGameGenres;
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.OpenRead(Path.Combine(ConnectionString, Constants.GameOrdersFileName)))
            {
                GameOrderRepository? deserializedGameOrders = JsonSerializer.Deserialize<GameOrderRepository>(fileStream);
                GameOrders = deserializedGameOrders == null ? new GameOrderRepository() : deserializedGameOrders;
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.OpenRead(Path.Combine(ConnectionString, Constants.GenresFileName)))
            {
                GenreRepository? deserializedGenres = JsonSerializer.Deserialize<GenreRepository>(fileStream);
                Genres = deserializedGenres == null ? new GenreRepository() : deserializedGenres;
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.OpenRead(Path.Combine(ConnectionString, Constants.OrdersFileName)))
            {
                OrderRepository? deserializedOrders = JsonSerializer.Deserialize<OrderRepository>(fileStream);
                Orders = deserializedOrders == null ? new OrderRepository() : deserializedOrders;
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.OpenRead(Path.Combine(ConnectionString, Constants.ShoppingCartsFileName)))
            {
                ShoppingCartRepository? deserializedShoppingCarts = JsonSerializer.Deserialize<ShoppingCartRepository>(fileStream);
                ShoppingCarts = deserializedShoppingCarts == null ? new ShoppingCartRepository() : deserializedShoppingCarts;
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.OpenRead(Path.Combine(ConnectionString, Constants.UsersFileName)))
            {
                UserRepository? deserializedUsers = JsonSerializer.Deserialize<UserRepository>(fileStream);
                Users = deserializedUsers == null ? new UserRepository() : deserializedUsers;
                fileStream.Dispose();
            }                        
        }

        public void SaveData()
        {
            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GamesFileName)))
            {
                JsonSerializer.Serialize(fileStream, Games);
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GameGenresFileName)))
            {
                JsonSerializer.Serialize(fileStream, GameGenres);
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GameOrdersFileName)))
            {
                JsonSerializer.Serialize(fileStream, GameOrders);
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GenresFileName)))
            {
                JsonSerializer.Serialize(fileStream, Genres);
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.OrdersFileName)))
            {
                JsonSerializer.Serialize(fileStream, Orders);
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.ShoppingCartsFileName)))
            {
                JsonSerializer.Serialize(fileStream, ShoppingCarts);
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.UsersFileName)))
            {
                JsonSerializer.Serialize(fileStream, Users);
                fileStream.Dispose();
            }
        }
        
        public void Clear()
        {
            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GamesFileName)))
            {
                JsonSerializer.Serialize(fileStream, new GameRepository());
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GameGenresFileName)))
            {
                JsonSerializer.Serialize(fileStream, new GameGenreRepository());
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GameOrdersFileName)))
            {
                JsonSerializer.Serialize(fileStream, new GameOrderRepository());
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.GenresFileName)))
            {
                JsonSerializer.Serialize(fileStream, new GenreRepository());
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.OrdersFileName)))
            {
                JsonSerializer.Serialize(fileStream, new OrderRepository());
                fileStream.Dispose();
            }

            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.ShoppingCartsFileName)))
            {
                JsonSerializer.Serialize(fileStream, new ShoppingCartRepository());
                fileStream.Dispose();
            }

            /* 
            using (FileStream fileStream = File.Create(Path.Combine(ConnectionString, Constants.UsersFileName)))
            {
                JsonSerializer.Serialize(fileStream, new UserRepository();
                fileStream.Dispose();
            }*/
        }
    }
}
