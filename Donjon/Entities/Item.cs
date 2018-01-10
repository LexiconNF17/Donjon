using System;

namespace Donjon.Entities
{
    public class Item : IDrawable
    {
        public string Name;
        public ConsoleColor Color { get; }
        public string Symbol { get; }

        public Item(string name, string symbol, ConsoleColor color)
        {
            Name = name;
            Symbol = symbol;
            Color = color;
        }

        public static Item Coin() => new Item("Coin", "c", ConsoleColor.Yellow);
    }
}