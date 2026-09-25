using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> journal = new List<string>
        {
            "Подія 1: Запуск програми",
            "Подія 2: Користувач увійшов",
            "Подія 3: Виконано операцію",
            "Подія 4: Дані збережено",
            "Подія 5: Програму завершено"
        };

        journal.Reverse();

        Console.WriteLine("Журнал у зворотному порядку:");

        foreach (string entry in journal)
        {
            Console.WriteLine(entry);
        }
    }
}