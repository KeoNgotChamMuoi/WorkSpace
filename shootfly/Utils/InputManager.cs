using System;

namespace ConsoleShooter.Utils
{
    public class InputManager
    {
        public ConsoleKey? ReadKey()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(true).Key;
            return null;
        }
    }
}
