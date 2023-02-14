using System;
/**
* Дан массив целых чисел nums и целочисленное значение target, 
* Вернуть индексы двух чисел таким образом, чтобы они в сумме составляли target.
* Вы можете предположить, что каждый входной сигнал будет иметь ровно одно решение, 
* и вы не можете использовать один и тот же элемент дважды.
*/

namespace LeetCodeTwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 3 };
            int target = 6;

            foreach(int num in TwoSum(nums, target))
            {
                Console.Write(num + " ");
            }
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int diff;

            for (int i = 0; i < nums.Length; i++)
            {
                diff = target - nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == diff)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
    }
}
