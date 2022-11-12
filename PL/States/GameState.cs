using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class GameState : MenuState
    {
        protected override ApplicationService ApplicationService { get; }
        private int gameId;

        public GameState(ApplicationService applicationService, int gameId)
        {
            ApplicationService = applicationService;
            this.gameId = gameId;
        }

        protected override Dictionary<int, MenuItem> Menus => menus;

        private Dictionary<int, MenuItem> menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Додати до кошика"}},
        {2, new MenuItem(){Text = "Повернутися"}}
        };

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu)
        {
            switch (selectedMenu.Key)
            {
                case 1:
                    return new AddToCartState(ApplicationService, gameId);
                case 2:
                    return new GameListState(ApplicationService);
            };

            return this;
        }

        protected override void ShowMenu()
        {
            Console.WriteLine(ApplicationService.GameDetails(gameId));
            base.ShowMenu();
        }
    }
}
