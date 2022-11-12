using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class RemoveFromShoppingCartState : InteractionState
    {
        public ApplicationService ApplicationService { get; }
        private int gameId;

        public RemoveFromShoppingCartState(ApplicationService applicationService, int gameId)
        {
            ApplicationService = applicationService;
            this.gameId = gameId;
        }
        public override IState RunState()
        {
            Console.WriteLine(ApplicationService.DeleteFromCart(gameId));
            Continue();
            return new ShoppingCartState(ApplicationService);
        }
    }
}
