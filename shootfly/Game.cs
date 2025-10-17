using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using ConsoleShooter.Entities;
using ConsoleShooter.Renderer;
using ConsoleShooter.Utils;

namespace ConsoleShooter.Core
{
    public class Game
    {
        private int width, height;
        private bool running = true;
        private Player player;
        private List<Enemy> enemies = new();
        private List<Bullet> bullets = new();
        private ConsoleRenderer renderer;
        private InputManager input;
        private Random rnd = new();

        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
            renderer = new ConsoleRenderer(width, height);
            input = new InputManager();
            player = new Player(width / 2, height - 3);
        }

        public void Run()
        {
            Console.CursorVisible = false;
            var sw = Stopwatch.StartNew();
            const int FPS = 60;
            double frameTime = 3000.0 / FPS;
            long prev = sw.ElapsedMilliseconds;

            while (running)
            {
                long now = sw.ElapsedMilliseconds;
                if (now - prev >= frameTime)
                {
                    HandleInput();
                    Update();
                    renderer.Render(player, enemies, bullets);
                    prev = now;
                }
                Thread.Sleep(1);
            }
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Game Over! Score: " + player.Score);
        }

        private void HandleInput()
        {
            var key = input.ReadKey();
            if (key == null) return;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    player.Move(-1, width);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    player.Move(1, width);
                    break;
                case ConsoleKey.Spacebar:
                    bullets.Add(player.Shoot());
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
            }
        }

        private void Update()
        {
            // update bullets
            bullets.ForEach(b => b.Update());
            bullets.RemoveAll(b => b.Y < 0);

            // update enemies
            if (rnd.NextDouble() < 0.05)
                enemies.Add(new Enemy(rnd.Next(0, width), 0));

            enemies.ForEach(e => e.Update(height));
            enemies.RemoveAll(e => e.Y > height);

            // collisions
            foreach (var b in bullets.ToArray())
                foreach (var e in enemies.ToArray())
                    if (b.Collides(e))
                    {
                        bullets.Remove(b);
                        enemies.Remove(e);
                        player.Score += 10;
                        break;
                    }

            // player hit
            foreach (var e in enemies)
                if (e.Collides(player))
                    running = false;
        }
    }
}
