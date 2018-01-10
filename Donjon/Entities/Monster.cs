using System;

namespace Donjon.Entities
{
    class Monster : Creature
    {
        private Monster(string name, string symbol, ConsoleColor color)
            : base(name, symbol, color) { }

        public static Monster Troll()
        {
            return new Monster("Troll", "T", ConsoleColor.Green) {
                Health = 3,
                Damage = 1
            };
        }
        public static Monster Goblin()
        {
            return new Monster("Goblin", "G", ConsoleColor.Green) {
                Health = 2,
                Damage = 1
            };
        }

    }
}
