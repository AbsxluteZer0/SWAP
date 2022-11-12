using SWAP.DAL.Data;
using SWAP.DAL.Data.Interfaces;
using System.Text;

namespace SWAP.BLL.EntityServices
{
    internal class ShoppingCartService
    {
        private readonly IApplicationContext context;

        public ShoppingCartService(IApplicationContext context)
        {
            this.context = context;
        }

        public string ListItems(User currentUser)
        {
            IEnumerable<Game> games = context.ShoppingCarts.Where(c => c.UserId == currentUser.UserId).Select(c => c.Game);

            if (!games.Any())
            {
                return "Пусто";
            }

            StringBuilder builder = new StringBuilder();

            foreach (Game? game in games)
            {
                builder.AppendLine(String.Format("{0}.{1}\t\t{2} ₴",game.GameId, game.Title, game.Price));
            }

            builder.AppendLine("Сума: " + games.Sum(g => g.Price) + "₴");

            return builder.ToString();
        }

        public void AddToCart(int gameId, User currentUser)
        {
            Game game = context.Games.FirstOrDefault(g => g.GameId == gameId);

            if (game == null)
            {
                throw new ApplicationException("Гру не знайдено");
            }

            context.ShoppingCarts.Add(new ShoppingCart { User = currentUser, Game = game });

            context.SaveData();
        }

        public void DeleteFromCart(int gameId, User currentUser)
        {
            Game game = context.Games.FirstOrDefault(g => g.GameId == gameId);

            if (game == null)
            {
                throw new ApplicationException("Гру не знайдено");
            }

            ShoppingCart relation = context.ShoppingCarts.Where(c => c.UserId == currentUser.UserId).FirstOrDefault(c => c.GameId == game.GameId);

            if (relation == null)
                return;

            context.ShoppingCarts.Delete(relation);

            context.SaveData();
        }

        public void ClearCart(User currentUser)
        {
            IEnumerable<ShoppingCart> shoppingCarts = context.ShoppingCarts.Where(c => c.UserId == currentUser.UserId);

            List<ShoppingCart> carts = shoppingCarts.ToList();

            foreach (var cart in carts)
            {
                context.ShoppingCarts.Delete(cart);
            }

            context.SaveData();
        }
    }
}
