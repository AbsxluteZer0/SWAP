using SWAP.BLL;

namespace SWAP.PL.States
{
    internal class AddToCartState : InteractionState
    {
        public ApplicationService ApplicationService { get; }
        private int gameId;

        public AddToCartState(ApplicationService applicationService, int gameId)
        {
            ApplicationService = applicationService;
            this.gameId = gameId;
        }

        public override IState RunState()
        {
            Console.WriteLine(ApplicationService.AddToCart(gameId));
            Continue();
            return new GameState(ApplicationService, gameId);
        }
    }
}