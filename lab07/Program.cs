using System;
using System.Collections.Generic;

class Request
{
    public string Name { get; set; }
    public int Minutes { get; set; }

    public Request(string name, int minutes)
    {
        Name = name;
        Minutes = minutes;
    }
}

class Program
{
    static bool IsBalanced(string line)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in line)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}')
            {
                if (stack.Count == 0)
                    return false;

                char opening = stack.Pop();

                if ((ch == ')' && opening != '(') ||
                    (ch == ']' && opening != '[') ||
                    (ch == '}' && opening != '{'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    static int ProcessQueue(Queue<Request> requests)
    {
        if (requests.Count == 0)
        {
            Console.WriteLine("Немає заявок для обробки.");
            return 0;
        }

        int currentMinute = 0;
        int order = 1;
        int totalRequests = requests.Count;

        while (requests.Count > 0)
        {
            Request request = requests.Dequeue();

            int start = currentMinute;
            int finish = start + request.Minutes;

            Console.WriteLine(
                $"{order}. {request.Name} — з {start} до {finish} хв");

            currentMinute = finish;
            order++;
        }

        Console.WriteLine(
            $"Оброблено заявок: {totalRequests}, загальний час: {currentMinute} хв");

        return currentMinute;
    }

    static void Main()
    {
        string[] lines =
        {
            "",
            "a + b",
            "{[a] + (b)}",
            "([)]",
            "a)",
            "(a[b]",
            "f(x[1]) * {y + (z)}"
        };

        Console.WriteLine("Перевірка дужок:");

        foreach (string line in lines)
        {
            string shownLine = line == ""
                ? "(порожній рядок)"
                : line;

            Console.WriteLine(
                $"{shownLine} -> {(IsBalanced(line) ? "так" : "ні")}");
        }

        Queue<Request> requests = new Queue<Request>();

        requests.Enqueue(new Request("Довідка про навчання", 4));
        requests.Enqueue(new Request("Академічна відпустка", 7));
        requests.Enqueue(new Request("Копія наказу", 2));
        requests.Enqueue(new Request("Виписка з оцінками", 6));
        requests.Enqueue(new Request("Перескладання", 9));
        requests.Enqueue(new Request("Студентський квиток", 3));

        Console.WriteLine();
        Console.WriteLine("Обробка заявок:");

        ProcessQueue(requests);
    }
}