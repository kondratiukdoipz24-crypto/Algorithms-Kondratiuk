
using System;
using System.Collections.Generic;

class Product
{
    public string Code { get; set; }
    public string Name { get; set; }

    
class Product
{
    public string Code { get; set; }
    public string Name { get; set; }

    public Product(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public override bool Equals(object obj)
    {
        return obj is Product other && Code == other.Code;
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(Code);
    }
}


    public override int GetHashCode()
{
    return StringComparer.Ordinal.GetHashCode(Code);
}

    // GetHashCode поки НЕ додаємо
}

class Program
{
    static void Main()
    {
        List<Product> items = new List<Product>
        {
            new Product("A-100", "Кабель USB-C"),
            new Product("B-205", "Миша бездротова"),
            new Product("A-100", "Кабель USB-C"),
            new Product("C-310", "Клавіатура"),
            new Product("D-415", "Монітор 24 дюйми"),
            new Product("B-205", "Миша бездротова"),
            new Product("E-520", "Навушники"),
            new Product("F-630", "Вебкамера")
        };

        HashSet<Product> unique = new HashSet<Product>();

        foreach (Product p in items)
        {
            unique.Add(p);
        }

        Dictionary<Product, int> stock = new Dictionary<Product, int>();

        stock[new Product("A-100", "Кабель USB-C")] = 17;
        stock[new Product("A-100", "Кабель USB-C")] = 25;

        Product a = new Product("A-100", "Кабель USB-C");
        Product b = new Product("A-100", "Кабель USB-C");

        Console.WriteLine("ДІАГНОСТИКА ДО ВИПРАВЛЕННЯ");
        Console.WriteLine("1. a.Equals(b): " + a.Equals(b));
        Console.WriteLine("2. unique.Count: " + unique.Count);
        Console.WriteLine("3. unique.Contains(a): " + unique.Contains(a));
        Console.WriteLine("4. stock.Count: " + stock.Count);
        Console.WriteLine("5. stock.ContainsKey(a): " + stock.ContainsKey(a));
    }
}
