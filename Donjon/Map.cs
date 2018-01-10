using Donjon.Entities;
using System;

namespace Donjon
{
    internal class Map
    {
        private int width;
        private int height;
        private Cell[,] cells;

        public Hero Hero { get; set; }

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell();
                }
            }
        }

        internal void Draw()
        {
            var previousColor = Console.ForegroundColor;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(" ");
                    IDrawable drawable = cells[x, y];
                    if (Hero.X == x && Hero.Y == y) drawable = Hero;

                    Console.ForegroundColor = drawable.Color;
                    Console.Write(drawable.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = previousColor;
        }

        internal bool InvalidCell(int x, int y)
        {
            return x < 0 || y < 0 || x >= width || y >= height;
        }
    }
}