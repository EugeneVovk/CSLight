using System;

namespace InSeven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 5;
            int end = 96;
            int interval = 7;

            for (int i = start; i <= end; i += interval)
            {
                if (i != end)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("Вывод последовательности с помощью цикла for,\n"
                + "т.к. известны начальная и конечная границы чисел\n");
        }
    }
}
