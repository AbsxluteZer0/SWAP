using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class ChooseShoppingCartItemState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public ChooseShoppingCartItemState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }
        public override IState RunState()
        {
            int chosenOption = InputId();
            return new RemoveFromShoppingCartState(ApplicationService, chosenOption);
        }
    }
}
