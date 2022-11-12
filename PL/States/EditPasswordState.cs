using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class EditPasswordState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public EditPasswordState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        public override IState RunState()
        {
            Console.Clear();
            Console.WriteLine("Введіть старий пароль: ");
            string? password = Console.ReadLine();
            Console.WriteLine("Введіть новий пароль: ");
            string? newPassword = Console.ReadLine();
            Console.WriteLine(ApplicationService.EditUserPassword(password, newPassword));
            Continue();
            return new ProfileState(ApplicationService);
        }
    }
}
