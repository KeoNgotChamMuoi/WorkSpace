namespace ConsoleShooter.Entities
{
    public class Player : Entity
    {
        public int Score { get; set; }

        public Player(int x, int y) : base(x, y, '^') { }

        public void Move(int dx, int maxWidth)
        {
            X = Math.Clamp(X + dx, 0, maxWidth - 1);
        }

        public Bullet Shoot() => new Bullet(X, Y - 1);
    }
}
