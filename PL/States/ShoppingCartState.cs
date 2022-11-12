using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class ShoppingCartState : MenuState
    {
        protected override ApplicationService ApplicationService { get; }

        public ShoppingCartState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        protected override Dictionary<int, MenuItem> Menus => menus;

        private Dictionary<int, MenuItem> menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Видалити з кошика"}},
        {2, new MenuItem(){Text = "Оформити замовлення"}},
        {3, new MenuItem(){Text = "Повернутися у головне меню"}}
        };

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu)
        {
            switch (selectedMenu.Key)
            {
                case 1:
                    return new ChooseShoppingCartItemState(ApplicationService);
                case 2:
                    return new CreateOrderState(ApplicationService);
                case 3:
                    return new MainMenuState(ApplicationService);
            };

            return this;
        }

        protected override void ShowMenu()
        {
            Console.WriteLine("Ваш кошик:");
            Console.WriteLine(ApplicationService.ListShoppingCartItems());            

            Console.WriteLine("\nДії:");
            base.ShowMenu();
        }
    }
}
