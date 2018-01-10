using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon.Entities
{
    class Hero : Creature
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Hero() : base("☻", ConsoleColor.Cyan) { }
    }
}
