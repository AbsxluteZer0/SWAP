using SWAP.PL;
using SWAP.PL.States;
using System.Runtime.CompilerServices;

namespace SWAP 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //string connectionString = Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data")).FullName; //Serialization
            string connectionString = @"Server = (localdb)\mssqllocaldb; Database = gameStore_db; Trusted_Connection = True;";

            try
            {
                IState startState = new AuthorizationState(connectionString);
                while (startState != null) startState = startState.RunState();
            }
            catch (Exception ex)
            {
                Console.WriteLine("При виконанні програми сталася помилка!\nТекст помилки: " + ex.Message);
                Console.Read();
            }
        }
    }
}

