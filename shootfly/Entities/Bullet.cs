namespace ConsoleShooter.Entities
{
    public class Bullet : Entity
    {
        public Bullet(int x, int y) : base(x, y, '|') { }

        public override void Update() => Y--;
    }
}
