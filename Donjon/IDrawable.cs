using System;

namespace Donjon
{
    internal interface IDrawable
    {
        ConsoleColor Color { get; }
        string Symbol { get; }
    }
}