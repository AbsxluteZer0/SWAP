using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class ProfileState : MenuState
    {
        protected override ApplicationService ApplicationService { get; }

        public ProfileState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        protected override Dictionary<int, MenuItem> Menus => menus;

        private Dictionary<int, MenuItem> menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Змінити ім'я"}},
        {2, new MenuItem(){Text = "Змінити пароль"}},
        {3, new MenuItem(){Text = "Історія замовлень"}},
        {4, new MenuItem(){Text = "Кошик"}},
        {5, new MenuItem(){Text = "Повернутися до головного меню"}}
        };

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu)
        {
            switch (selectedMenu.Key)
            {
                case 1:
                    return new EditNameState(ApplicationService);
                case 2:
                    return new EditPasswordState(ApplicationService);
                case 3:
                    return new OrderListState(ApplicationService);
                case 4:
                    return new ShoppingCartState(ApplicationService);
                case 5:
                    return new MainMenuState(ApplicationService);
            };

            return this;
        }

        protected override void ShowMenu()
        {
            Console.WriteLine("Ваш профіль:");
            Console.WriteLine(ApplicationService.GetUserInfo());
            base.ShowMenu();
        }
    }
}
