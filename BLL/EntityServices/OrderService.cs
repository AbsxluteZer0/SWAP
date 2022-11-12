using SWAP.DAL.Data.Interfaces;
using SWAP.DAL.Data;
using System.Text;

namespace SWAP.BLL.EntityServices
{
    internal class OrderService
    {
        private readonly IApplicationContext context;

        public OrderService(IApplicationContext context)
        {
            this.context = context;
        }

        public void FormOrder(User currentUser)
        {
            IEnumerable<Game> orderedGames = context.ShoppingCarts.Where(c => c.UserId == currentUser.UserId).Select(c => c.Game);

            if (!orderedGames.Any())
            {
                throw new ApplicationException("Кошик порожній");
            }

            Order order = new Order { User = currentUser, Status = "обробляється" };

            context.Orders.Add(order);

            foreach (var game in orderedGames)
            {
                context.GameOrders.Add(new GameOrder { Game = game, Order = order });
            }

            context.SaveData();
        }

        public string ListOrders(User currentUser)
        {
            List<Order> orders = context.Orders.Where(r => r.UserId == currentUser.UserId).ToList();

            if (!orders.Any())
                return "Пусто";

            StringBuilder builder = new StringBuilder();

            foreach (var order in orders)
            {
                builder.AppendLine(String.Format("Номер замовлення: {0}\nСума: {1}₴\nСтатус: {2}\n", order.TransactionKey, GetSum(order), order.Status));
            }

            return builder.ToString();
        }

        private decimal GetSum(Order order)
        {
            decimal sum = 0;

            IEnumerable<GameOrder> gameOrders = context.GameOrders.Where(o => o.OrderId.Equals(order.TransactionKey));
            foreach (var relation in gameOrders)
            {
                sum += relation.Game.Price;
            }

            return sum;
        }
    }
}
