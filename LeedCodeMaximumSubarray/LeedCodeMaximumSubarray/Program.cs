using System;
/**
 * Дан целочисленный массив nums, 
 * найти подмассив с наибольшей суммой и вернуть его сумму.
 * 
 * Решение берём текущюю сумму и в неё постоянно складываем последовательно числа
 * но если получилось так, что при сложении к текущей сумме текущего числа 
 * мы получаем значение хуже чем если бы мы начали отчёт i-того числа (на котором мы сейчас)
 * то лучше с него и начать.
 * И на каждой итерации мы перезаписываем максимальнуб сумму элементов
 */

namespace LeetCodeMaximumSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Console.WriteLine(MaxSubArray(nums));
        }

        public static int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = nums[0];
            int num;

            for (int i = 1; i < nums.Length; i++)
            {
                num = nums[i];
                currentSum = Math.Max(currentSum + num, num);
                maxSum = Math.Max(currentSum, maxSum);
            }

            return maxSum;
        }
    }
}
