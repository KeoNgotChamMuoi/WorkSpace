namespace ConsoleShooter.Entities
{
    public abstract class Entity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; protected set; }

        protected Entity(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public virtual void Update() { }

        public bool Collides(Entity other) => X == other.X && Y == other.Y;
    }
}
