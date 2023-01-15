using System;
/**
 * Найти наибольший элемент матрицы A(10,10) 
 * и записать ноль в те ячейки, где он находятся. 
 * Вывести наибольший элемент, исходную и полученную матрицу.
 * Массив под измененную версию не нужен.
 */

namespace FindTheLargestMatrixElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }

            Console.WriteLine($"Наибольший элемент матрицы {FindTheLargestElement(matrix)}\n");

            Console.WriteLine("Исходная матрица:\n");
            DisplayTheMatrix(matrix);

            Console.WriteLine("\nНоль вместо максимального элемента в матрице:\n");
            DisplayTheMatrix(
                ZeroOutMatrixElement(matrix, FindTheLargestElement(matrix)));
        }

        private static void DisplayTheMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
        private static int FindTheLargestElement(int[,] matrix)
        {
            int largestElement = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (largestElement < matrix[i, j])
                    {
                        largestElement = matrix[i, j];
                    }
                }
            }

            return largestElement;
        }
        private static int[,] ZeroOutMatrixElement(int[,] matrix, int element)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == element)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return matrix;
        }
    }
}
