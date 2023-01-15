using System;

namespace MatrixStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int row = random.Next(2, 10);
            int column = random.Next(2, 5);
            int[,] array = new int[column, row];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(1, 10);
                }
            }

            Console.WriteLine("Исходная матрица:\n");
            DisplayTheMatrix(array);

            Console.WriteLine($"\nСумма второй строки - {AdditionSecondLine(array)}\n"
                + $"Произведение первого столбца - {MultiplicationFirstColumn(array)}\n");
        }

        private static void DisplayTheMatrix(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int AdditionSecondLine(int[,] array)
        {
            int sumOfAddition = 0;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sumOfAddition += array[1, i];
            }

            return sumOfAddition;
        }

        private static int MultiplicationFirstColumn(int[,] array)
        {
            int sumOfMultiplication = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sumOfMultiplication *= array[i, 0];
            }

            return sumOfMultiplication;
        }
    }
}
