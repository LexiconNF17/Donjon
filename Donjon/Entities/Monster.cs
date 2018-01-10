using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon.Entities
{
    class Monster : Creature
    {
        private Monster(string symbol, ConsoleColor color)
            : base(symbol, color) { }

        static Monster Troll()
        {
            return new Monster("T", ConsoleColor.Green);
        }
        static Monster Goblin()
        {
            return new Monster("G", ConsoleColor.Green);
        }

    }
}
