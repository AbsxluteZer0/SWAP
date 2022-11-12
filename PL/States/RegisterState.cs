using SWAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL.States
{
    internal class RegisterState : InteractionState
    {
        public ApplicationService ApplicationService { get; }

        public RegisterState(ApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        public override IState RunState()
        {
            Console.Clear();
            Console.WriteLine("Введіть ел. пошту: ");
            string? email = Console.ReadLine();
            Console.WriteLine("Введіть ім'я користувача: ");
            string? userName = Console.ReadLine();
            Console.WriteLine("Введіть пароль: ");
            string? password = Console.ReadLine();
            Console.WriteLine("Повторіть пароль: ");
            string? passwordConfirm = Console.ReadLine();

            string response = ApplicationService.Register(email, userName, password, passwordConfirm);

            if (response == "успіх")
            {
                Console.WriteLine("Ви успішно зареєструвалися!");
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
