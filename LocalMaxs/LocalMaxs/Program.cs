using System;

namespace LocalMaxs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 99);
            }

            DisplayTheArray(array);

            DisplayLocalMax(array);
        }

        private static void DisplayTheArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        private static void DisplayLocalMax(int[] array)
        {
            int count = 1;

            if (array[0] > array[1])
            {
                Console.WriteLine($" {count++} Локальный максимум - {array[0]}");
            }

            for (int i = 1; i < array.Length - 1; i++)
            {

                if (array[i] > array[i - 1] && array[i] > array[i + 1])
                {
                    Console.WriteLine($" {count++} Локальный максимум - {array[i]}");
                }
            }

            if (array[array.Length - 1] > array[array.Length - 2])
            {
                Console.WriteLine($" {count++} Локальный максимум - {array[array.Length - 1]}");
            }

            Console.WriteLine();
        }
    }
}
