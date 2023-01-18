using System;
using System.Collections.Generic;

namespace ExplanatoryDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("List",
                "Эта коллекция представляет простейший список однотипных объектов");
            dictionary.Add("LinkedList",
                "Эта коллекция представляет двухсвязный список,\n"
               + " в котором каждый элемент хранит ссылку одновременно на следующий и на предыдущий элемент");
            dictionary.Add("Queue",
                "Эта коллекция представляет обычную очередь,\n"
               + " которая работает по алгоритму FIFO (\"первый вошел - первый вышел\")");
            dictionary.Add("Stack",
               "Эта коллекция использует алгоритм LIFO (\"последний вошел - первый вышел\").\n"
               + " При такой организации каждый следующий добавленный элемент помещается поверх предыдущего.\n"
               + " Извлечение из коллекции происходит в обратном порядке -\n"
               + " извлекается тот элемент, который находится выше всех в стеке");
            dictionary.Add("Dictionary",
                "Эта коллекция представляет собой словарь,\n"
               + " в котором объекты хранятся в виде пар \"ключ-значение\"");

            UserActions(dictionary);
        }

        private static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}\n");
            }
            Console.WriteLine();
        }

        private static string GetValueFromUser()
        {
            Console.Write("Введи название коллекции (например: List): ");

            return Console.ReadLine().Trim();
        }

        private static void PrintValueByKey(Dictionary<string, string> dictionary, string key)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            if (dictionary.ContainsKey(key))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t{dictionary[key]}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tУвы... Такого в этом словаре нет\n");
            }

            Console.ForegroundColor = defaultColor;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nПривет!\n"
                + "Это словарь по C#, глава Kоллекции.\n"
                + "\nТы можешь выбрать:\n\n"
                + " 1 - Посмотреть весь словарь\n"
                + " 2 - Найти значение слова\n"
                + " 3 - Выход\n");
        }

        private static void Exit(ref bool isUserWorking)
        {
            isUserWorking = false;
            Console.WriteLine("\n\tВыход из программы\n");
        }

        private static void UserActions(Dictionary<string, string> dictionary)
        {
            const string ONE = "1";
            const string TWO = "2";
            const string THREE = "3";
            string userInput;
            bool isUserWorking = true;

            while (isUserWorking)
            {
                PrintMenu();

                Console.Write("Выбери операцию: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ONE:
                        PrintDictionary(dictionary);
                        break;
                    case TWO:
                        PrintValueByKey(dictionary, GetValueFromUser());
                        break;
                    case THREE:
                        Exit(ref isUserWorking);
                        break;
                    default:
                        Console.WriteLine("\n\tВыбрана неверная операция!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
