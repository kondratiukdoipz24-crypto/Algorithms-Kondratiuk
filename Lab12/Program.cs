
using System;

class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class Program
{
    static int compareCount = 0;

    static void Main()
    {
        Node root = null;

        int[] values = { 42, 18, 65, 9, 27, 55, 90, 33 };

        foreach (int value in values)
        {
            root = Insert(root, value);
        }

        Console.WriteLine("СИМЕТРИЧНИЙ ОБХІД:");
        Inorder(root);

        Console.WriteLine("\n\nКІЛЬКІСТЬ ВУЗЛІВ: " + CountNodes(root));

        compareCount = 0;
        bool found55 = Search(root, 55);
        Console.WriteLine("\nПошук 55: " + (found55 ? "Так" : "Ні"));
        Console.WriteLine("Порівнянь: " + compareCount);

        compareCount = 0;
        bool found30 = Search(root, 30);
        Console.WriteLine("\nПошук 30: " + (found30 ? "Так" : "Ні"));
        Console.WriteLine("Порівнянь: " + compareCount);

        Console.WriteLine("\nГЛИБИНА ДЕРЕВА: " + GetDepth(root));

        root = Insert(root, 27);
        Console.WriteLine("\nКількість вузлів після повторної вставки 27: "
            + CountNodes(root));
    }

    static Node Insert(Node node, int key)
    {
        if (node == null)
        {
            return new Node(key);
        }

        if (key < node.Value)
        {
            node.Left = Insert(node.Left, key);
        }
        else if (key > node.Value)
        {
            node.Right = Insert(node.Right, key);
        }

        return node;
    }

    static bool Search(Node node, int key)
    {
        if (node == null)
        {
            return false;
        }

        compareCount++;

        if (node.Value == key)
        {
            return true;
        }

        if (key < node.Value)
        {
            return Search(node.Left, key);
        }

        return Search(node.Right, key);
    }

    static void Inorder(Node node)
    {
        if (node == null)
        {
            return;
        }

        Inorder(node.Left);
        Console.Write(node.Value + " ");
        Inorder(node.Right);
    }

    static int CountNodes(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }

    static int GetDepth(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftDepth = GetDepth(node.Left);
        int rightDepth = GetDepth(node.Right);

        return 1 + Math.Max(leftDepth, rightDepth);
    }
}
