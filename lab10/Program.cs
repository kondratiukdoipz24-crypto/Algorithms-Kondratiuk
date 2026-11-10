
using System;
using System.Collections.Generic;

class Request
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public int Seq { get; set; }

    public Request(string name, int priority, int seq)
    {
        Name = name;
        Priority = priority;
        Seq = seq;
    }
}

class Program
{
    static void Main()
    {
        List<Request> incoming = new List<Request>
        {
            new Request("Оновити підпис у листі", 3, 1),
            new Request("Сервер не відповідає", 1, 2),
            new Request("Не друкує принтер", 2, 3),
            new Request("Не працює термінал оплати", 1, 4),
            new Request("Змінити шпалери", 3, 5)
        };

        Request late = new Request(
            "Відвалився інтернет у відділі", 1, 6);

        ProcessAll(incoming);

        ProcessStable(incoming);

        ProcessWithLate(incoming, late);
    }

    // Задача 1. Обробка тільки за пріоритетом
    static void ProcessAll(List<Request> incoming)
    {
        PriorityQueue<Request, int> queue =
            new PriorityQueue<Request, int>();

        foreach (Request request in incoming)
        {
            queue.Enqueue(request, request.Priority);
        }

        Console.WriteLine("\nЗАДАЧА 1. ОБРОБКА ЗА ПРІОРИТЕТОМ");

        int number = 1;

        while (queue.Count > 0)
        {
            Request request = queue.Dequeue();

            Console.WriteLine(
                $"{number}. {request.Name} | Пріоритет: {request.Priority} | Seq: {request.Seq}");

            number++;
        }
    }

    // Задача 2. Стабільний порядок
    static void ProcessStable(List<Request> incoming)
    {
        PriorityQueue<Request, (int Priority, int Seq)> queue =
            new PriorityQueue<Request, (int Priority, int Seq)>();

        foreach (Request request in incoming)
        {
            queue.Enqueue(
                request,
                (request.Priority, request.Seq));
        }

        Console.WriteLine("\nЗАДАЧА 2. СТАБІЛЬНИЙ ПОРЯДОК");

        int number = 1;

        while (queue.Count > 0)
        {
            Request request = queue.Dequeue();

            Console.WriteLine(
                $"{number}. {request.Name} | Пріоритет: {request.Priority} | Seq: {request.Seq}");

            number++;
        }
    }

    // Задача 3. Додавання нової заявки під час обробки
    static void ProcessWithLate(
        List<Request> incoming, Request late)
    {
        PriorityQueue<Request, (int Priority, int Seq)> queue =
            new PriorityQueue<Request, (int Priority, int Seq)>();

        foreach (Request request in incoming)
        {
            queue.Enqueue(
                request,
                (request.Priority, request.Seq));
        }

        Console.WriteLine("\nЗАДАЧА 3. НОВА ЗАЯВКА ПІД ЧАС ОБРОБКИ");

        int number = 1;

        // Обробляємо перші дві заявки
        for (int i = 0; i < 2; i++)
        {
            Request request = queue.Dequeue();

            Console.WriteLine(
                $"{number}. {request.Name} | Пріоритет: {request.Priority} | Seq: {request.Seq}");

            number++;
        }

        // Додаємо нову критичну заявку
        queue.Enqueue(late, (late.Priority, late.Seq));

        // Продовжуємо обробку
        while (queue.Count > 0)
        {
            Request request = queue.Dequeue();

            Console.WriteLine(
                $"{number}. {request.Name} | Пріоритет: {request.Priority} | Seq: {request.Seq}");

            number++;
        }
    }
}
