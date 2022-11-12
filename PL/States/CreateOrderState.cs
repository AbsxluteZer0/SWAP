using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class CreateOrderState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public CreateOrderState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        public override IState RunState()
        {
            Console.Clear();
            string responce = ApplicationService.FormOrder();
            Console.WriteLine(responce);
            if (responce.Equals("Замовлення сформовано"))
            {
                Console.WriteLine(ApplicationService.ClearCart());                
            }
            Continue();
            return new OrderListState(ApplicationService);
        }
    }
}
