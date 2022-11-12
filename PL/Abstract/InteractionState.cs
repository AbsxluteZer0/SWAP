using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.PL
{
    abstract class InteractionState : IState
    {
        protected virtual void Continue()
        {
            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        }

        protected virtual int InputId()
        {
            Console.WriteLine("Введіть номер елемента: ");
            int answer = new int();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    break;
                }
                Console.WriteLine("Помилка вводу. Повторіть, будь-ласка, спробу: ");
            }
            return answer;
        }

        public abstract IState RunState();
    }
}
