using System;

class Program
{
    static void Main()
    {
        const int N = 5;

        string[] events =
        {
            "Подія 1",
            "Подія 2",
            "Подія 3",
            "Подія 4",
            "Подія 5",
            "Подія 6",
            "Подія 7",
            "Подія 8"
        };

        string[] lastEvents = new string[N];

        int nextPosition = 0;
        int count = 0;

        foreach (string eventItem in events)
        {
            lastEvents[nextPosition] = eventItem;

            nextPosition = (nextPosition + 1) % N;

            if (count < N)
            {
                count++;
            }
        }

        Console.WriteLine("Останні 5 подій:");

        int startPosition;

        if (count == N)
        {
            startPosition = nextPosition;
        }
        else
        {
            startPosition = 0;
        }

        for (int i = 0; i < count; i++)
        {
            int index = (startPosition + i) % N;
            Console.WriteLine(lastEvents[index]);
        }
    }
}