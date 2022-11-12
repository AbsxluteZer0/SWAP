using SWAP.BLL;
using System;
using System.Collections.Generic;

namespace SWAP.PL.States
{
    public class MainMenuState : MenuState
    {
        protected override ApplicationService ApplicationService { get; }       

        public MainMenuState(string connectionString)
        {
            ApplicationService = new ApplicationService(connectionString);
        }
        public MainMenuState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        protected override Dictionary<int, MenuItem> Menus => menus;

        private Dictionary<int, MenuItem> menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Ігри"}},
        {2, new MenuItem(){Text = "Кошик"}},
        {3, new MenuItem(){Text = "Профіль"}},
        {0, new MenuItem(){Text = "Вихід"}}
        };

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu)
        {
            switch (selectedMenu.Key)
            {
                case 0:
                    return null;
                case 1:
                    return new GameListState(ApplicationService);
                case 2:
                    return new ShoppingCartState(ApplicationService);
                case 3:
                    return new ProfileState(ApplicationService);
            };

            return this;
        }

        protected override void ShowMenu()
        {
            Console.WriteLine("Головне меню");
            base.ShowMenu();
        }
    }
}
