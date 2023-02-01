using System;
using System.Threading;

namespace MultiplesNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userNumber;
            int lowerLimit = 100;
            int upperLimit = 999;
            int countMultiples = 0;
            int threeSecondWaite = 3000;

            Console.SetCursorPosition(5, 5);
            Console.WriteLine("Давай поиграем!\n");
            Console.Write(" Введи любое число от 1 до 27 включительно: ");
            userNumber= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n ...а я постараюсь вывести количество "
                + $"трехзначных натуральных чисел, которые кратны {userNumber}.");

            for(int i = userNumber; i < 1000; i+= userNumber) {

                if (i >= lowerLimit && i <= upperLimit )
                {
                    countMultiples++;
                }
            }

            Thread.Sleep(threeSecondWaite);

            Console.WriteLine("\n\tТа-дам: " + countMultiples + "\n");
        }
    }
}
