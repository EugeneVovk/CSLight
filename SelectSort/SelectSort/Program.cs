using System;

namespace SelectSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            FillArray(numbers);

            PrintArray(numbers);

            SelectSort(numbers);

            PrintArray(numbers);
        }

        private static void SelectSort(int[] array)
        {
            int minIndexOfValue;

            for (int i = 0; i < array.Length; i++)
            {
                minIndexOfValue = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[minIndexOfValue] > array[j])
                    {
                        minIndexOfValue = j;
                    }
                }

                (array[minIndexOfValue], array[i]) = (array[i], array[minIndexOfValue]);
            }
        }

        private static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        private static void FillArray(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-99, 100);
            }
        }
    }
}
