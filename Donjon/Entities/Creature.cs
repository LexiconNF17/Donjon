using System;

namespace Donjon.Entities
{
    internal class Creature : IDrawable
    {
        public ConsoleColor Color { get; set; } 
        public string Symbol { get; set; }

        public int Health { get; set; }
        public int Damage { get; set; }

        public Creature(string symbol, ConsoleColor color)
        {
            Symbol = symbol;
            Color = color;
        }
    }
}