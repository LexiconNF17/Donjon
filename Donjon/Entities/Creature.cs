using System;

namespace Donjon.Entities
{
    internal abstract class Creature : IDrawable
    {
        public ConsoleColor Color { get; set; } 
        public string Symbol { get; set; }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Creature(string name, string symbol, ConsoleColor color)
        {
            Name = name;
            Symbol = symbol;
            Color = color;
        }
    }
}