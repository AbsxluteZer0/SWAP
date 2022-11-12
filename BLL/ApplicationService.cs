using SWAP.BLL.EntityServices;
using SWAP.DAL.Data.Contexts;
using SWAP.DAL.Data.Interfaces;

namespace SWAP.BLL
{
    public class ApplicationService
    {
        private readonly ValidationService validationService;
        private readonly UserService userService;
        private readonly ShoppingCartService shoppingCartService;
        private readonly OrderService orderService;
        private readonly GameService gameService;

        public ApplicationService(string connection)
        {
            IApplicationContext context = new DbApplicationContext(connection);//Data provider
            context.LoadData();

            //context.Clear();
            InitializationService.Initialize(context);

            validationService = new ValidationService();
            userService = new UserService(context);
            shoppingCartService = new ShoppingCartService(context);
            orderService = new OrderService(context);
            gameService = new GameService(context);
        }

        public string Register(string email, string userName, string password, string passwordConfirm)
        {
            if (!validationService.ValidateEmail(email))
            {
                return "Невірний формат електронної адреси!";
            }
            if (!validationService.ValidateUserName(userName))
            {
                return "Ім'я не може бути пустим!";
            }
            if (!validationService.ValidatePasswords(password, passwordConfirm))
            {
                return "Паролі не можуть бути пустими! Паролі мусять співпадати!";
            }

            try
            {
                userService.Register(email, userName, password);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
            return "успіх";
        }

        public string Login(string email, string password)
        {
            if (!validationService.ValidateEmail(email))
            {
                return "Перевірте правильність введених даних";
            }

            try
            {
                userService.Login(email, password);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "успіх";
        }

        public string ListShoppingCartItems()
        {
            try
            {
                return shoppingCartService.ListItems(userService.User);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            
        }

        public string DeleteFromCart(int gameId)
        {
            try
            {
                shoppingCartService.DeleteFromCart(gameId, userService.User);
                return "Видалено успішно";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }            
        }

        public string FormOrder()
        {
            try
            {
                orderService.FormOrder(userService.User);
                return "Замовлення сформовано";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ListOrders()
        {
            try
            {
                return orderService.ListOrders(userService.User);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ClearCart()
        {
            try
            {
                shoppingCartService.ClearCart(userService.User);
                return "Кошик очищено";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetUserInfo()
        {
            try
            {
                return userService.GetProfile();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditUserName(string newUserName)
        {
            try
            {
                userService.EditUserName(newUserName);
                return "Ім'я успішно змінено";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditUserPassword(string password, string newPassword)
        {
            try
            {
                userService.EditPassword(password, newPassword);
                return "Новий пароль успішно встановлено";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AddToCart(int gameId)
        {
            try
            {
                shoppingCartService.AddToCart(gameId, userService.User);
                return "Гру успішно додано";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ListGames()
        {
            try
            {
                return gameService.ListGames();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ListGames(int genreId)
        {                           
            try
            {
                return gameService.ListGames(genreId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GameDetails(int gameId)
        {
            try
            {
                return gameService.Details(gameId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ListGenres()
        {
            try
            {
                return gameService.ListGenres();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetUserName()
        {
            return userService.User.UserName;
        }
    }
}
