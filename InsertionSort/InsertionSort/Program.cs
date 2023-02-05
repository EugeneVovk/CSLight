using System;

namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            FillArray(numbers);

            PrintArray(numbers);

            InsertSort(numbers);

            PrintArray(numbers);
        }

        private static void InsertSort(int[] array)
        {
            int indexNumberToChange;
            int currentNumber;

            for (int i = 0; i < array.Length; i++)
            {
                indexNumberToChange = i;
                currentNumber = array[i];

                while (indexNumberToChange > 0 && currentNumber < array[indexNumberToChange - 1])
                {
                    array[indexNumberToChange] = array[indexNumberToChange - 1];
                    indexNumberToChange--;
                }

                array[indexNumberToChange] = currentNumber;
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
