using System;

namespace HR_files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] employeeNames = new string[0];
            string[] employeePositions = new string[0];
            string userInput;
            bool isUserWorking = true;

            while (isUserWorking)
            {
                DisplayMenu();
                Console.Write("Выбери операцию: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDossie(ref employeeNames, ref employeePositions);
                        break;
                    case "2":
                        DisplayDossier(employeeNames, employeePositions);
                        break;
                    case "3":
                        DeleteDossier(ref employeeNames, ref employeePositions);
                        break;
                    case "4":
                        FindBySurname(employeeNames, employeePositions);
                        break;
                    case "5":
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

        private static void AddDossie(ref string[] names, ref string[] positions)
        {
            AddName(ref names);
            AddPosition(ref positions);
            Console.WriteLine("\n\tДосье добавлено успешно!");
        }

        private static string[] AddName(ref string[] names)
        {
            Console.Write("\nВведи имя: ");
            return AddElementFromConsole(ref names);
        }

        private static string[] AddPosition(ref string[] positions)
        {
            Console.Write("Введи должность: ");
            return AddElementFromConsole(ref positions);
        }

        private static string[] AddElementFromConsole(ref string[] array)
        {
            array = IncreaseArray(ref array);
            array[array.Length - 1] = Console.ReadLine();
            return array;
        }

        private static string[] IncreaseArray(ref string[] array)
        {
            string[] newArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private static void DisplayDossier(string[] employeeNames, string[] employeePositions)
        {
            Console.WriteLine("\nВывод досье:");

            if (employeeNames.Length <= 0)
            {
                Console.WriteLine("\n\tДосье нет");
            }
            else if (employeeNames.Length == employeePositions.Length)
            {
                for (int i = 0; i < employeeNames.Length; i++)
                {
                    Console.WriteLine($" {i + 1}. {employeeNames[i]} - {employeePositions[i]}");
                }
            }
        }

        private static void DeleteDossier(ref string[] names, ref string[] positions)
        {
            if (names.Length <= 0)
            {
                Console.WriteLine("\n\tДосье нет");
            }
            else
            {
                int dossierNumber;
                int size = 0;
                string[] tempNames = new string[names.Length - 1];
                string[] tempPositions = new string[positions.Length - 1];

                Console.Write("\nВведи номер досье для удаления: ");
                dossierNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine($"\n Удаляю {names[dossierNumber]} - {positions[dossierNumber]}");

                for (int i = 0; i < names.Length; i++)
                {
                    if (i != dossierNumber)
                    {
                        tempNames[size] = names[i];
                        tempPositions[size] = positions[i];
                        size++;
                    }
                }

                names = tempNames;
                positions = tempPositions;

                Console.WriteLine("\n\tДосье успешно удалено!");
            }
        }

        private static void FindBySurname(string[] names, string[] positions)
        {
            if (names.Length <= 0)
            {
                Console.WriteLine("\n\tДосье нет");
            }
            else
            {
                string surname;

                Console.Write("\nВведи фамилию сотрудника: ");
                surname = Console.ReadLine();

                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i].Contains(surname))
                    {
                        Console.WriteLine($" {i + 1}. {names[i]} - {positions[i]}");
                        break;
                    }

                    Console.WriteLine("По такой фамилии нет досье");
                }
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
                + " 4 - поиск по фамилии\n"
                + " 5 - выход\n");
        }
    }
}
