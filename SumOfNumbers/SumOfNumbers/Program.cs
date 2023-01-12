using System;

namespace SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 100;
            int divisibleByThree = 3;
            int divisibleByFive = 5;
            int sum = 0;
            Random random = new Random();
            int number = random.Next(0, maxNumber);

            for (int i = 0; i <= number; i++)
            {
                if (i % divisibleByThree == 0 || i % divisibleByFive == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Сумма всех положительных чисел меньше {number} (включая число),\n"
               + $"которые кратные {divisibleByThree} или {divisibleByFive} равно {sum}");
        }
    }
}
