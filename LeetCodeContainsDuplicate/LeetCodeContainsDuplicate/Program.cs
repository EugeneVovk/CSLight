using System;
using System.Collections.Generic;
/**
* Дан массив чисел.
* Вернуть true, если какое-либо значение встречается в массиве минимум дважды, т.е. содержит дубликат
* Или вернуть false, если каждый элемент различен
*/

namespace LeetCodeContainsDuplicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 3 };

            Console.WriteLine(ContainsDuplicate(nums));
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);

            return nums.Length != set.Count;
        }
    }
}
