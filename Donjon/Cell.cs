using Donjon.Entities;
using System;

namespace Donjon
{
    internal class Cell : IDrawable
    {        
        public string Symbol 
            => Monster?.Symbol 
            ?? Item?.Symbol
            ?? ".";

        public ConsoleColor Color 
            => Monster?.Color 
            ?? Item?.Color
            ?? ConsoleColor.DarkGray;

        public Item Item { get; set; }
        public Monster Monster { get; set; }
    }
}