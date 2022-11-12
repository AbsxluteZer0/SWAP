using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class GameListState : MenuState
    {
        protected override ApplicationService ApplicationService { get; }
        private int? genreId;

        public GameListState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        public GameListState(ApplicationService applicationService, int genreId)
        {
            ApplicationService = applicationService;
            this.genreId = genreId;
        }

        protected override Dictionary<int, MenuItem> Menus => menus;

        private Dictionary<int, MenuItem> menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Обрати гру"}},
        {2, new MenuItem(){Text = "Пошук за жанром"}},
        {3, new MenuItem(){Text = "Повернутися у головне меню"}}
        };

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu)
        {
            switch (selectedMenu.Key)
            {
                case 1:
                    return new ChooseGameState(ApplicationService);
                case 2:
                    return new GenreListState(ApplicationService);
                case 3:
                    return new MainMenuState(ApplicationService);
            };

            return this;
        }

        protected override void ShowMenu()
        {
            if (genreId != null)
            {
                Console.WriteLine("Ігри за обраним жанром:");
                Console.WriteLine(ApplicationService.ListGames((int)genreId));
            }
            else
            {
                Console.WriteLine("Ігри в наявності:");
                Console.WriteLine(ApplicationService.ListGames());
            }
            
            Console.WriteLine("\nДії:");
            base.ShowMenu();
        }
    }
}
