using System;

namespace SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            int sum = 0;

            for (int i = 0; i <= number; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Сумма всех положительных чисел меньше {number} (включая число),\n"
               + $"которые кратные 3 или 5 равно {sum}");
        }
    }
}
