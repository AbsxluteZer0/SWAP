using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class LoginState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public LoginState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        public override IState RunState()
        {
            Console.Clear();
            Console.WriteLine("Введіть ел. пошту: ");
            string? email = Console.ReadLine();
            Console.WriteLine("Введіть пароль: ");
            string? password = Console.ReadLine();

            string response = ApplicationService.Login(email, password);

            if (response == "успіх")
            {
                Console.WriteLine("Ви увійшли як");
                Console.WriteLine(ApplicationService.GetUserName());
                Continue();
                return new MainMenuState(ApplicationService);
            }
            else
            {
                Console.WriteLine(response);
                Continue();
                return new AuthorizationState(ApplicationService);
            }            
        }
    }
}
