using System;
/**
 * 1. Выбор опорного элемента
 * 2. Раставить элементы так, чтобы те что меньше опорного
 *    находились слева от него, а те что больше - справа
 * 3. Повторить первые два шага для элементов слева и справа от опорного
 */

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            FillArray(numbers);

            PrintArray(numbers);

            GetPivotIndex(numbers, 0, numbers.Length - 1);

            PrintArray(numbers);

            numbers = QuickSort(numbers, 0, numbers.Length - 1);

            PrintArray(numbers);
        }

        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {

            if (minIndex >= maxIndex)
            {
                return array;
            }

            int indexPivotPoint = GetPivotIndex(array, minIndex, maxIndex);

            QuickSort(array, minIndex, indexPivotPoint - 1);
            QuickSort(array, indexPivotPoint + 1, maxIndex);

            return array;
        }

        private static int GetPivotIndex(int[] array, int minIndex, int maxIndex)
        {
            int pivotPoint = array[maxIndex];
            int indexPivotPoint = minIndex - 1;

            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < pivotPoint)
                {
                    indexPivotPoint++;

                    Swap(ref array[i], ref array[indexPivotPoint]);
                }
            }

            indexPivotPoint++;

            Swap(ref array[maxIndex], ref array[indexPivotPoint]);

            return indexPivotPoint;
        }

        private static void Swap(ref int leftItem, ref int rightItem)
        {
            (leftItem, rightItem) = (rightItem, leftItem);
        }

        private static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
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
