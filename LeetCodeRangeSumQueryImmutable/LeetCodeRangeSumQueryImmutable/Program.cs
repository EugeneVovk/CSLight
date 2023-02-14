using System;
using System.Collections.Generic;
/**
* Дан целочисленный массив nums, обработайте несколько запросов следующего типа:
* Вычислите сумму элементов nums между индексами left и right включительно, где left <= right.
* 
* т.е. нам нужно реализовать два метода у класса NumArray, 
* в которых подаётся массив и диапазон массива.
* Следовательно, надо посчитать сумму этого диапазона
* 
* Решение: в методе NumArray будем хранить сумму предыдущих элементов,
* т.к. суммировать в методе SumRange будет дорого
*/

namespace LeetCodeRangeSumQueryImmutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class NumArray
    {
        private int[] _sums;

        public NumArray(int[] nums)
        {
            int currentSum = 0;
            List<int> sums = new List<int>();

            foreach (int num in nums)
            {
                currentSum += num;
                sums.Add(currentSum);
            }
            
            _sums = sums.ToArray();
        }

        public int SumRange(int left, int right)
        {
            if (left == 0)
            {
                return _sums[right];
            }

            return _sums[right] - _sums[left-1];
        }
    }
}
