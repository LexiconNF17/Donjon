
using Donjon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Donjon
{
    internal class Game
    {
        private Map map;
        private bool playing;
        private List<string> log = new List<string>();

        public Game()
        {
        }

        internal void Start()
        {
            Console.Clear();
            Initialize();
            Play();
        }

        private void Initialize()
        {
            map = new Map(width: 10, height: 10, log: log);
            map.Hero = new Hero();
            map.Cell(5, 8).Monster = Monster.Troll();
            map.Cell(8, 5).Monster = Monster.Goblin();
            map.Cell(4, 3).Monster = Monster.Goblin();
            map.Cell(2, 3).Item = Item.Coin();
            map.Cell(4, 2).Item = Item.Coin();
            map.Cell(1, 2).Item = Item.Coin();
            map.Cell(1, 4).Item = Item.Coin();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        private void Play()
        {
            Draw();
            playing = true;
            while (playing)
            {
                PlayerAction();
                UpdateMap();
                Draw();
                if (map.Hero.Health <= 0) playing = false;
                if (map.Monsters.Count() <= 0) playing = false;
            }
            Console.WriteLine("Game Over");
        }

        private void UpdateMap()
        {
            map.ClearDeadMonsters();
            map.MoveMonsters();
        }

        private void PlayerAction()
        {
            log.Clear();
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Move(x: 0, y: -1);
                    break;
                case ConsoleKey.DownArrow:
                    Move(x: 0, y: 1);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(x: -1, y: 0);
                    break;
                case ConsoleKey.RightArrow:
                    Move(x: 1, y: 0);
                    break;
                case ConsoleKey.P:
                    Pickup();
                    break;
                case ConsoleKey.I:
                    Inventory();
                    break;
                case ConsoleKey.Q:
                    playing = false;
                    break;
            }
        }

        private void Inventory()
        {
            log.Add($"Inventory:");
            foreach (var item in map.Hero.Backpack)
            {
                log.Add($"  {item.Name}");
            }
        }

        private void Pickup()
        {
            map.Pickup();
        }

        private void Move(int x, int y)
        {
            map.MoveHero(x, y);
        }

        private void Draw()
        {
            Console.CursorVisible = false;
            Console.Clear();
            map.Draw();
            Console.WriteLine($"Health: {map.Hero.Health}  ({map.Hero.X}, {map.Hero.Y})");
            foreach (var message in log)
            {
                Console.WriteLine(message);
            }
            while (log.Count > 6) log.RemoveAt(0);
        }
    }
}