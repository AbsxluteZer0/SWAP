using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class AuthorizationState : MenuState
    {
        protected override ApplicationService ApplicationService { get; }

        public AuthorizationState(string connectionString)
        {
            ApplicationService = new ApplicationService(connectionString);
        }

        public AuthorizationState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        protected override Dictionary<int, MenuItem> Menus => menus;

        private Dictionary<int, MenuItem> menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Вхід"}},
        {2, new MenuItem(){Text = "Реєстрація"}},
        {0, new MenuItem(){Text = "Вихід"}}
        };

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu)
        {
            switch (selectedMenu.Key)
            {
                case 0:
                    return null;
                case 1:
                    return new LoginState(ApplicationService);
                case 2:
                    return new RegisterState(ApplicationService);              
            };

            return this;
        }
    }
}
