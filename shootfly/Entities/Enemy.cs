using System;

namespace ConsoleShooter.Entities
{
    public class Enemy : Entity
    {
        private static Random rnd = new();

        public Enemy(int x, int y) : base(x, y, 'V') { }

        public void Update(int height)
        {
            if (rnd.NextDouble() < 0.05) X += rnd.Next(-1, 2);
            Y++;
            X = Math.Clamp(X, 0, 59);
        }
    }
}
