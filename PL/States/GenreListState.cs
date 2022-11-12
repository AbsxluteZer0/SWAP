using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class GenreListState : MenuState
    {
        protected override ApplicationService ApplicationService { get; }

        public GenreListState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        protected override Dictionary<int, MenuItem> Menus => menus;

        private Dictionary<int, MenuItem> menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Обрати жанр"}},
        {2, new MenuItem(){Text = "Повернутися до списку ігор"}}
        };

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu)
        {
            switch (selectedMenu.Key)
            {
                case 1:
                    return new ChooseGenreState(ApplicationService);
                case 2:
                    return new GameListState(ApplicationService);
            };

            return this;
        }

        protected override void ShowMenu()
        {

            Console.WriteLine("Список жанрів:");
            Console.WriteLine(ApplicationService.ListGenres());
            
            Console.WriteLine("\nДії:");
            base.ShowMenu();
        }
    }
}
