using Donjon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Donjon
{
    internal class Map
    {
        private int width;
        private int height;
        private Cell[,] cells;
        private List<string> log;
        private IEnumerable<Cell> Cells => cells.Cast<Cell>();

        public Hero Hero { get; set; }

        public IEnumerable<Monster> Monsters
            => Cells
                .Where(c => c.Monster != null)
                .Select(c => c.Monster);

        public Map(int width, int height, List<string> log)
        {
            this.log = log;
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

        internal Cell Cell(int x, int y)
        {
            return cells[x, y];
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

        internal void ClearDeadMonsters()
        {
            var deadCells = Cells
                .Where(c => c.Monster != null)
                .Where(c => c.Monster.Health <= 0);
            foreach (var cell in deadCells)
            {
                cell.Monster = null;
            }

            //foreach (var cell in Cells)
            //{
            //    if (cell.Monster != null)
            //    {
            //        if (cell.Monster.Health <= 0)
            //        {
            //            cell.Monster = null;
            //        }
            //    }
            //}
        }

        internal bool OutOfBounds(int x, int y)
        {
            return x < 0 || y < 0
                || x >= width || y >= height;
        }

        public bool MoveHero(int x, int y)
        {
            var targetX = Hero.X + x;
            var targetY = Hero.Y + y;
            if (OutOfBounds(targetX, targetY)) return false;
            var cell = cells[targetX, targetY];
            if (cell.Monster == null)
            {
                Hero.X = targetX;
                Hero.Y = targetY;
                return true;
            }
            else
            {
                Fight(Hero, cell.Monster);
                return false;
            }
        }

        private void Fight(Hero hero, Monster monster)
        {
            log.Add($"The {hero.Name} attacks a {monster.Name} ({monster.Health})");
            monster.Health -= hero.Damage;
            if (monster.Health <= 0)
            {
                log.Add($"The {monster.Name} is dead");
                return;
            }

            log.Add($"The {monster.Name} attacks the {hero.Name}");
            hero.Health -= monster.Damage;
        }
    }
}