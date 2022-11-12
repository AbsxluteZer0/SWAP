using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class OrderListState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public OrderListState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        public override IState RunState()
        {
            Console.Clear();
            Console.WriteLine(ApplicationService.ListOrders());
            Continue();
            return new MainMenuState(ApplicationService);
        }

        protected override void Continue()
        {
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню...");
            Console.ReadKey();
        }
    }
}
