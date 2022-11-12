using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class EditNameState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public EditNameState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        public override IState RunState()
        {
            Console.Clear();
            Console.WriteLine("Введіть нове ім'я: ");
            string? name = Console.ReadLine();
            Console.WriteLine(ApplicationService.EditUserName(name));
            Continue();
            return new ProfileState(ApplicationService);
        }
    }
}
