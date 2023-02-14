using System;
/**
 * Дано целое число n, верните массив ans длины n + 1 такой, 
 * что для каждого i (0 <= i <= n) 
 * ans[i] - это число единиц в двоичном представлении i.
 * 
 * т.е. нам дано число n и нам нужно вывести массив того,
 * сколько от нуля до n в двоичном представлении у каждого числа единичек
 */
namespace LeetCodeCountingBits
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] CountBits(int n)
        {
            int[] memo = new int[n + 1];

            for (int i = 1; i < memo.Length; i++)
            {
                memo[i] = memo[i >> 1] + i % 2;
            }

            return memo;
        }
    }
}
