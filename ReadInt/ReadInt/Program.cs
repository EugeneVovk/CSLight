using System;

namespace ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputANumberFromTheConsole();
        }

        private static void InputANumberFromTheConsole()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            bool isNotNumber = true;


            while (isNotNumber)
            {
                Console.Write("Введи целое число: ");

                var valueInput = Console.ReadLine();
                bool success = int.TryParse(valueInput, out int number);

                if (success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\tУдалось преобразовать '{valueInput}' в число {number}\n");
                    isNotNumber = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\tКонвертация значения '{valueInput ?? "<null>"}' не удалась\n");
                }

                Console.ForegroundColor = defaultColor;
            }
        }
    }
}
