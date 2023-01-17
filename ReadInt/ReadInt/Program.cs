using System;
/**
 * Написать функцию, которая запрашивает число у пользователя 
 * (с помощью метода Console.ReadLine() ) 
 * и пытается сконвертировать его в тип int (с помощью int.TryParse())
 * 
 * Если конвертация не удалась 
 * у пользователя запрашивается число повторно до тех пор, 
 * пока не будет введено верно. 
 * После ввода, который удалось преобразовать в число, 
 * число возвращается.
 * 
 * P.S Задача решается с помощью циклов
 * 
 * P.S Также в TryParse используется модфикатор параметра out 
 */

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
