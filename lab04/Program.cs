using System;

class Program
{
    static int comparisons = 0;

    static int LinearSearch(int[] items, int target)
    {
        for (int i = 0; i < items.Length; i++)
        {
            comparisons++;

            if (items[i] == target)
            {
                return i;
            }
        }

        return -1;
    }

    static int BinarySearch(int[] items, int target)
    {
        int low = 0;
        int high = items.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            comparisons++;

            if (items[mid] == target)
            {
                return mid;
            }

            if (items[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1;
    }

    static void Report(string name, int[] items, int target)
    {
        comparisons = 0;

        int index;

        if (name == "linear")
        {
            index = LinearSearch(items, target);
        }
        else
        {
            index = BinarySearch(items, target);
        }

        Console.WriteLine(
            $"{name,-8} target = {target,-3} index = {index,-3} comparisons = {comparisons}"
        );
    }

    static void Main()
    {
        int[] data =
        {
            42, 8, 60, 19, 3, 55, 12, 31,
            68, 24, 49, 37, 71, 5, 27
        };

        int[] sortedData =
        {
            3, 5, 8, 12, 19, 24, 27, 31,
            37, 42, 49, 55, 60, 68, 71
        };

        Console.WriteLine("LABORATORY WORK №4");
        Console.WriteLine("Search in data");
        Console.WriteLine();

        Console.WriteLine("Part 2. Search in sortedData");
        Console.WriteLine();

        int[] targets =
        {
            3, 71, 31, 1, 99, 50, 42
        };

        foreach (int target in targets)
        {
            Report("linear", sortedData, target);
            Report("binary", sortedData, target);
            Console.WriteLine();
        }

        Console.WriteLine("Part 2. One element array [42]");
        int[] oneElement = { 42 };
        Report("linear", oneElement, 42);
        Report("binary", oneElement, 42);
        Console.WriteLine();

        Console.WriteLine("Part 2. Empty array []");
        int[] empty = { };
        Report("linear", empty, 42);
        Report("binary", empty, 42);
        Console.WriteLine();

        Console.WriteLine("Part 3. Binary search on unsorted data");
        Report("binary", data, 55);
    }
}