using System;

namespace Donjon.Entities
{
    class Monster : Creature
    {
        protected Monster(string name, string symbol, ConsoleColor color)
            : base(name, symbol, color) { }

        public static Monster Troll()
        {
            return new Troll();
        }
        public static Monster Goblin()
        {
            return new Monster("Goblin", "G", ConsoleColor.Green)
            {
                Health = 2,
                Damage = 1
            };
        }
    }

    class Troll : Monster
    {
        private int targetX;
        private int targetY;

        public Troll() : base("Troll", "T", ConsoleColor.Green)
        {
            Health = 3;
            Damage = 1;
        }

        internal void SetTarget(int x, int y)
        {
            targetX = x;
            targetY = y;
        }

        public void MoveTowardsTarget() {
        }
    }
}
