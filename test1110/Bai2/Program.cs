using System;
using System.Collections;

public delegate void DiscountEventHandler(string name, int oldPrice, int newPrice);

class Phone
{
    public string Name;
    public int Price;

    // Event
    public event DiscountEventHandler OnDiscount;

    public void ApplyDiscount(int percent)
        {
            int oldPrice = Price;
            int newPrice = Price - Price * percent / 100;
            Price = newPrice;
            if (OnDiscount != null)
            OnDiscount(Name, oldPrice, newPrice);
    }
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price}");
    }
    
}

class Store
{
    private ArrayList phones = new ArrayList();
    public void AddPhone(Phone p)
    {
        phones.Add(p);
    }

    public void DiscountAll(int percent)
    {
        foreach (Phone p in phones)
        {
            p.ApplyDiscount(percent);
        }
    }
}

class Program
{
    static void Main()
    {
        Store store = new Store();
        Phone p1 = new Phone { Name = "Nokia", Price = 5000 };
        Phone p2 = new Phone { Name = "Nokia1", Price = 20000 };
        Phone p3 = new Phone { Name = "Nokia2", Price = 15000 };
        p1.OnDiscount += ShowDiscountMessage;
        p2.OnDiscount += ShowDiscountMessage;
        p3.OnDiscount += ShowDiscountMessage;
        static void ShowDiscountMessage(string name, int oldPrice, int newPrice)
        {
            Console.WriteLine($"[EVENT] {name}: {oldPrice} -> {newPrice}");
        }
        store.AddPhone(p1);
        store.AddPhone(p2);
        store.AddPhone(p3);
        store.DiscountAll(10);
        Console.WriteLine("\nSau khi giảm giá:");
        p1.ShowInfo();
        p2.ShowInfo();
        p3.ShowInfo();
    }
    class SmartPhone : Phone
    {
        public string OS;
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Name: {Name}, Price: {Price}, OS: {OS}");
        }
    }
}

