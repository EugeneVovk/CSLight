using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace HR_files_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> employees = new Dictionary<string, string>();

            UserActions(employees);
        }

        private static void UserActions(Dictionary<string, string> employees)
        {
            const string ONE = "1";
            const string TWO = "2";
            const string THREE = "3";
            const string FOUR = "4";

            string userInput;
            bool isUserWorking = true;

            while (isUserWorking)
            {
                DisplayMenu();
                userInput = UserInput();

                switch (userInput)
                {
                    case ONE:
                        AddDossier(employees);
                        break;
                    case TWO:
                        DisplayDossier(employees);
                        break;
                    case THREE:
                        DeleteDossier(employees);
                        break;
                    case FOUR:
                        Exit(ref isUserWorking);
                        break;
                    default:
                        Console.WriteLine("\n\tВыбрана неверная операция!!!");
                        break;
                }

                Console.Write("\n\n\n\nДля продолжения нажмите любую клавишу...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static string UserInput()
        {
            Console.Write("Выбери операцию: ");
            return Console.ReadLine();
        }

        private static void AddDossier(Dictionary<string, string> employees)
        {
            employees.Add(AddName(), AddPosition());
            Console.WriteLine("\n\tДосье добавлено успешно!");
        }

        private static string AddName()
        {
            Console.Write("\nВведи ФИО сотрудника: ");
            return Console.ReadLine();
        }

        private static string AddPosition()
        {
            Console.Write("Введи его должность: ");
            return Console.ReadLine();
        }

        private static void DisplayDossier(Dictionary<string, string> employees)
        {
            int counter = 0;

            Console.WriteLine("\nВывод досье:");

            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine($" {++counter}. {employee.Key} - {employee.Value}");
                }
            }
            else
            {
                Console.WriteLine("\n\tДосье нет");
            }
        }

        private static void DeleteDossier(Dictionary<string, string> employees)
        {
            string surname;

            Console.Write("\nВведи фамилию сотрудника: ");
            surname = Console.ReadLine();

            if (employees.Remove(surname))
            {
                Console.WriteLine("\n\tДосье успешно удалено!");
            }
            else
            {
                Console.WriteLine("\n\tДосье такого нет");
            }
        }

        private static void Exit(ref bool isUserWorking)
        {
            isUserWorking = false;
            Console.WriteLine("\n\tВыход из программы");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n\tМеню:\n\n"
                + " 1 - добавить досье\n"
                + " 2 - вывести всё досье\n"
                + " 3 - удалить досье\n"
                + " 4 - выход\n");
        }
    }
}
