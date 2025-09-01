using System;

class Program
{
    static void Main()
    {
        const int rate = 23000;

        Console.Write("Enter USD: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int usd))
        {
            int vnd = usd * rate;
            Console.WriteLine($"{usd} USD = {vnd} VND");
        }
        else
        {
            Console.WriteLine("Giá trị nhập vào không hợp lệ!");
        }
    }
}
