using System;

namespace GuessANumber_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number;
            int upperBoundary;
            int lowerBoundary;
            int attempts = 3;
            int userInput;

            number = random.Next(0, 100);
            upperBoundary = random.Next(number + 1, number + 10);
            lowerBoundary = random.Next(number - 10, number);

            Console.Write($"\nПривет!\n"
                + $"Я загадал число от нуля до ста,\n"
                + $"оно больше чем {lowerBoundary}, но меньше чем {upperBoundary}.\n"
                );

            while (attempts-- > 0)
            {
                Console.Write("Что это за число? ");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (number == userInput)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\tТы прав! Это число {number}\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Попробуй ещё раз\n");
                }
            }

            if (attempts < 0)
            {
                Console.Clear();
                Console.WriteLine($"\n\t\tУвы..."
                    + $"\n\n\tВозможно, тебе повезёт в следующий раз"
                    + $"\n\n\tЭто было число {number}\n");
            }
        }
    }
}
