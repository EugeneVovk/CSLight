using System;

namespace Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            PrintArray(array);

            ShuffleArray(array);

            PrintArray(array);
        }

        private static void ShuffleArray(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                Swap(array, i, i + random.Next(array.Length - i));
            }
        }

        private static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        private static void PrintArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
