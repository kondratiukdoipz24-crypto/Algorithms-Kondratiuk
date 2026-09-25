using System;

class Program
{
    static void Main()
    {
        int[] months = { 1, 3, 3, 5, 7, 7, 7, 10, 12 };
        double[] amounts = { 1200, 500, 700, 1500, 300, 450, 250, 900, 1100 };

        double[] totals = new double[12];

        for (int i = 0; i < months.Length; i++)
        {
            int monthIndex = months[i] - 1;
            totals[monthIndex] += amounts[i];
        }

        Console.WriteLine("Підсумки за місяцями:");

        for (int i = 0; i < totals.Length; i++)
        {
            Console.WriteLine($"Місяць {i + 1}: {totals[i]}");
        }
    }
}
