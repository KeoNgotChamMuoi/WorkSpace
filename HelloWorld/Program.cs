using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Console.WriteLine("Hello World!");
            var c1 = new Class();
            Console.WriteLine($"HelloWorld! {c1.ReturnMessage()}");
        }
    }
}