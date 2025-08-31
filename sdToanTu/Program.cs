using System;

namespace sdToanTu
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            float width, height, area;
            Console.WriteLine("Enter Width:");
            width = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter height:");
            height = float.Parse(Console.ReadLine());
            area = width * height;
            Console.WriteLine("Area is:"+ area);
        }
    }
}