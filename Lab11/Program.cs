
using System;
using System.Collections.Generic;

class Node
{
    public string Title { get; set; }
    public List<Node> Children { get; set; }

    public Node(string title, List<Node> children)
    {
        Title = title;
        Children = children;
    }
}

class Program
{
    static int callCount = 0;

    static void Main()
    {
        Node menu = new Node("Головне меню", new List<Node>
        {
            new Node("Файл", new List<Node>
            {
                new Node("Новий", new List<Node>()),
                new Node("Зберегти", new List<Node>())
            }),
            new Node("Правка", new List<Node>
            {
                new Node("Копіювати", new List<Node>())
            }),
            new Node("Вигляд", new List<Node>
            {
                new Node("Масштаб", new List<Node>
                {
                    new Node("Збільшити", new List<Node>()),
                    new Node("Зменшити", new List<Node>())
                })
            }),
            new Node("Довідка", new List<Node>())
        });

        Console.WriteLine("ДЕРЕВО МЕНЮ:");
        PrintMenu(menu, 0);

        Console.WriteLine("\nПІДРАХУНОК:");
        int total = CountItems(menu);
        Console.WriteLine("Кількість пунктів: " + total);
        Console.WriteLine("Кількість викликів countItems: " + callCount);

        Console.WriteLine("\nПОШУК:");
        Console.WriteLine("Зберегти: " + Find(menu, "Зберегти"));
        Console.WriteLine("Масштаб: " + Find(menu, "Масштаб"));
        Console.WriteLine("Довідка: " + Find(menu, "Довідка"));
        Console.WriteLine("Експорт: " + Find(menu, "Експорт"));

        Console.WriteLine("\nДОДАТКОВА ПЕРЕВІРКА:");
        Console.WriteLine("Глибина дерева: " + GetDepth(menu));
        Console.WriteLine("Кількість пунктів без дітей: " + CountLeaves(menu));
    }

    static void PrintMenu(Node node, int level)
    {
        Console.WriteLine(new string(' ', level * 2) + node.Title);

        foreach (Node child in node.Children)
        {
            PrintMenu(child, level + 1);
        }
    }

    static int CountItems(Node node)
    {
        callCount++;

        int count = 1;

        foreach (Node child in node.Children)
        {
            count += CountItems(child);
        }

        return count;
    }

    static bool Find(Node node, string name)
    {
        if (node.Title == name)
            return true;

        foreach (Node child in node.Children)
        {
            if (Find(child, name))
                return true;
        }

        return false;
    }

    static int GetDepth(Node node)
    {
        int maxDepth = 0;

        foreach (Node child in node.Children)
        {
            int depth = GetDepth(child);
            if (depth > maxDepth)
                maxDepth = depth;
        }

        return maxDepth + 1;
    }

    static int CountLeaves(Node node)
    {
        if (node.Children.Count == 0)
            return 1;

        int count = 0;

        foreach (Node child in node.Children)
        {
            count += CountLeaves(child);
        }

        return count;
    }
}
