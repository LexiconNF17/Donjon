using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain;
            do
            {
                var game = new Game();
                game.Start();
                Console.WriteLine("Another game? Y/N");
                playAgain = Console.ReadKey(intercept: true).Key == ConsoleKey.Y; 
            } while (playAgain);
        }
    }
}
