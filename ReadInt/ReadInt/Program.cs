using System;

namespace ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputNumberFromConsole();
        }

        private static int InputNumberFromConsole()
        {
            int userNumber = -1;
            bool isNotNumber = true;

            ConsoleColor defaultColor = Console.ForegroundColor;

            while (isNotNumber)
            {
                Console.Write("Введи целое число: ");

                var valueInput = Console.ReadLine();
                bool success = int.TryParse(valueInput, out int number);

                if (success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\tУдалось преобразовать '{valueInput}' в число {number}\n");
                    userNumber = number;
                    isNotNumber = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\tКонвертация значения '{valueInput ?? "<null>"}' не удалась\n");
                }

                Console.ForegroundColor = defaultColor;
            }

            return userNumber;
        }
    }
}
