
using Donjon.Entities;
using System;
using System.Collections.Generic;

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
            }
            Console.WriteLine("Game Over");
        }

        private void UpdateMap()
        {
            map.ClearDeadMonsters();
        }

        private void PlayerAction()
        {
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
                case ConsoleKey.Q:
                    playing = false;
                    break;
            }
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
            while (log.Count > 30) log.RemoveAt(0);
        }
    }
}