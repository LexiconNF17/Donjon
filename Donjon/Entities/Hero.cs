using Lib;
using System;

namespace Donjon.Entities
{
    class Hero : Creature
    {
        public int X { get; set; }
        public int Y { get; set; }

        public LimitedList<Item> Backpack { get; set; }

        public Hero() : base("Hero", "☻", ConsoleColor.Cyan) {
            Damage = 1;
            Health = 5;
            Backpack = new LimitedList<Item>(3);
        }
    }
}
