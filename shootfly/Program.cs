using ConsoleShooter.Core;

namespace ConsoleShooter
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(60, 25);
            game.Run();
        }
    }
}
