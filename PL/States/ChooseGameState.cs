using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class ChooseGameState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public ChooseGameState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }
        public override IState RunState()
        {            
            int chosenOption = InputId();
            return new GameState(ApplicationService, chosenOption);
        }
    }
}
