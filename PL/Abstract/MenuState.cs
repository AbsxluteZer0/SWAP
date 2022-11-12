using System;
using System.Collections.Generic;
using SWAP.BLL;

namespace SWAP.PL
{
    public abstract class MenuState : IState
    {
        protected abstract ApplicationService ApplicationService { get; }
        protected abstract Dictionary<int, MenuItem> Menus { get; }

        protected virtual void ShowMenu()
        {
            foreach (var m in Menus)
                Console.WriteLine($"{m.Key} - {m.Value.Text}");
        }

        protected virtual KeyValuePair<int, MenuItem> ReadOption()
        {
            ShowMenu();

            var str = Console.ReadLine();
            int answerId = 0;

            if (int.TryParse(str, out answerId))
            {
                if (!Menus.ContainsKey(answerId))
                {
                    Console.Clear();
                    Console.WriteLine("Обраний варіант не існує.");
                    return ReadOption();
                }
                return new KeyValuePair<int, MenuItem>(answerId, Menus[answerId]);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Обраний варіант не число.");
                return ReadOption();
            }
        }

        public virtual IState RunState()
        {
            Console.Clear();
            var option = ReadOption();
            return NextState(option);
        }

        protected abstract IState NextState(KeyValuePair<int, MenuItem> selectedMenu);

        protected virtual void Continue()
        {
            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        }        
    }
}
