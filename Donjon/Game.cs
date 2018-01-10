
using Donjon.Entities;
using System;

namespace Donjon
{
    internal class Game
    {
        private Map map;
        private bool playing;

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
            map = new Map(width: 10, height: 10);
            map.Hero = new Hero();



            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        private void Play()
        {
            Draw();
            playing = true;
            while (playing)
            {
                PlayerAction();
                Draw();
            }
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
            var targetX = map.Hero.X + x;
            var targetY = map.Hero.Y + y;

            if (map.InvalidCell(targetX, targetY)) return;

            map.Hero.X = targetX;
            map.Hero.Y = targetY;
        }

        private void Draw()
        {
            Console.CursorVisible = false;
            Console.Clear();
            map.Draw();
        }
    }
}