using System;
using System.Collections.Generic;

class Phone
{
    public string Name;
    public int Price;

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price}");
    }
}

class Program
{
    static void Main()
    {
        Phone[] phones = new Phone[3];
        phones[0] = new Phone { Name = "iPhone", Price = 20000 };
        phones[1] = new Phone { Name = "Samsung", Price = 15000 };
        phones[2] = new Phone { Name = "Xiaomi", Price = 10000 };

        Console.WriteLine("Danh sách điện thoại ban đầu:");
        foreach (var i in phones)
        {
            i.ShowInfo();
        }

        Phone p1 = phones[0];
        p1.Price = 9999;

        Console.WriteLine("\nDanh sách điện thoại sau khi thay đổi giá của p1:");
        foreach (var i in phones)
        {
            i.ShowInfo();
        }

        // Phone là reference type nên thay đổi p1 ảnh hưởng đến phones[0]
      
        List<Phone> phoneList = new List<Phone>
        {
            new Phone { Name = "Oppo", Price = 12000 },
            new Phone { Name = "Vivo", Price = 13000 }
        };

        Console.WriteLine("\nDanh sách trong List:");
        foreach (var i in phoneList)
        {
            i.ShowInfo();
        }
    }
}