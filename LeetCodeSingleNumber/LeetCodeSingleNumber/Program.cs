using System;
/**
 * Дан непустой массив целых чисел nums, каждый элемент появляется дважды, 
 * за исключением одного, который появляется только один раз.
 * Найди это единственное число.
 * 
 * Решение через XOR, логическое сложение, 
 * т.е. если попадаются два одинаковых числа, то получатся 0.
 * А то число, которое не заXORится, сохранится в нашей маске * 
 */

namespace LeetCodeSingleNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 1, 2, 1, 2 };

            Console.WriteLine(SingleNumber(nums));
        }

        public static int SingleNumber(int[] nums)
        {
            int mask = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                mask ^= nums[i];
            }

            return mask;
        }
    }
}
