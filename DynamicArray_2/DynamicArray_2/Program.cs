using System;
using System.Collections.Generic;

namespace DynamicArray_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = new List<int>();

            UserActions(inputNumbers);
        }

        private static void PrintSumOfNumbers(List<int> numbers)
        {
            int sum = 0;

            if (numbers.Count <= 1)
            {
                Console.WriteLine("\n\tВведи хотя бы два числа :)");
                return;
            }

            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"\n\tСумма введённых тобою чисел - {sum}\n");
        }

        private static List<int> AddNumberToList(List<int> numbers, int number)
        {
            Console.WriteLine("\n\tЯ запомнил введённое тобою число\n");
            numbers.Add(number);

            return numbers;
        }

        private static string UserInput()
        {
            Console.Write("Поле для ввода: ");

            return Console.ReadLine();
        }

        private static void UserActions(List<int> numbers)
        {
            string userInput;
            bool isExitWord = true;

            while (isExitWord)
            {
                PrintMenu();

                userInput = UserInput();

                if (userInput == Exit())
                {
                    Console.WriteLine("\n\tДо встречи...\n");

                    isExitWord = false;
                }
                else if (userInput == "sum")
                {
                    PrintSumOfNumbers(numbers);
                }
                else if (int.TryParse(userInput, out int number))
                {
                    AddNumberToList(numbers, number);
                }
                else if (userInput == "delete")
                {
                    DeleteListValues(numbers);
                }
                else
                {
                    Console.WriteLine("\n\tНе получилось распознать твой ввод\n"
                        + " Давай ещё раз...\n");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DeleteListValues(List<int> numbers)
        {
            Console.WriteLine("\n\tМоя память чиста :)\n");
            numbers.Clear();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n\tДоступные операции:\n\n"
                + " - просто ввести любое число\n"
                + " - ввести - sum, чтобы суммировать все введённые тобою числа\n"
                + " - ввести - delete, что удалить все числа из памяти\n"
                + " - ввести - exit, чтобы выйти из программы\n");
        }

        private static string Exit(string exitWord = "exit")
        {
            return exitWord;
        }
    }
}
