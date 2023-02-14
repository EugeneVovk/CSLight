using System;
using System.Collections.Generic;
/**
 * Найдите все числа, исчезнувшие в массиве
 * Дан массив nums из n целых чисел, где nums[i] находится в диапазоне [1, n], где n - длина массива
 * Вернуть массив всех целых чисел в диапазоне [1, n], которые не отображаются в nums.
 * 
 * Решение через CyclicSort, т.е. мы берём число и заранее знаем, на каком индексе оно должно стоять
 * Следовательно, мы знаем диапазон и поэтому мы раставляем прправильным индексам числа массива
 * и если мы встретили дубликат, мы идём дальше
 */

namespace LeetCodeCyclicSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 3, 2, 7, 8, 2, 3, 1 };

            foreach(int num in FindDisappearedNumbers(nums)) {
                Console.Write(num + " ");
            }
            Console.WriteLine();

        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            int i = 0;
            int position;
            IList<int> miss = new List<int>();

            while (i < nums.Length)
            {
                position = nums[i] - 1; // correct position

                if (nums[i] != nums[position])
                {
                    (nums[i], nums[position]) = (nums[position], nums[i]);
                }
                else
                {
                    i += 1;
                }
            }

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j + 1)
                {
                    miss.Add(j + 1);
                }
            }

            return miss;
        }
    }
}
