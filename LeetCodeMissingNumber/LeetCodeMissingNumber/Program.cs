using System;
using System.Linq;
/**
* Дан массив массив nums, содержащий n различных чисел в диапазоне [0, n],
* Вернуть число из диапазона, которое отсутствует в массиве.
* 
* Решается с помощью формулы арифметической прогрессии:
* https://doc4web.ru/uploads/files/51/50501/hello_html_mfe2c122.gif
*/

namespace LeetCodeMissingNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 0, 1 };

            Console.WriteLine(MissingNumber(nums));
        }

        public static int MissingNumber(int[] nums)
        {
            int n = nums.Length;

            return n * (n + 1) / 2 - nums.Sum();
        }
    }
}
