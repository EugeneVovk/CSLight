using System;
using System.Linq;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            string[,] books =
            {
                { "Рентген", "Кюри", "Эйнштейн" },
                { "Фридман",  "Нэш", "Канеман" },
                { "Павлов", "Кандел", "Лоренц" }
            };

            while (isOpen)
            {
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("---------- Весь список учёных: ----------\n");
                for (int i = 0; i < books.GetLength(0); i++)
                {
                    for (int j = 0; j < books.GetLength(1); j++)
                    {
                        Console.Write(books[i, j] + " | ");
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\n\tБиблиотека\n");
                Console.WriteLine(
                      " 1 - Узнать имя учёного по индексу книги\n"
                    + " 2 - Найти книгу по фамилии учёного\n"
                    + " 3 - Выход\n"
                );
                Console.Write("Выберите пункт меню: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int row;
                        int column;
                        Console.Write("Введите номер полки: ");
                        row = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Введите номер стеллажа: ");
                        column = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("\n\tЭто учёный:  " + books[row, column]);
                        break;
                    case 2:
                        string author;
                        bool authorIsFound = false;
                        Console.Write("Введите фамилию учёного: ");
                        author = Console.ReadLine();
                        for (int i = 0; i < books.GetLength(0); i++)
                        {
                            for (int j = 0; j < books.GetLength(1); j++)
                            {
                                if (books[i, j].ToLower() == author.ToLower())
                                {
                                    Console.WriteLine($"\n\tУчёный '{books[i, j]}' находится "
                                        + $"на полке #{i + 1} стеллажа #{j + 1}\n\n");
                                    authorIsFound = true;
                                }
                            }
                        }
                        if (authorIsFound == false)
                        {
                            Console.WriteLine("\n\tТакого учёного нет в нашей библиотеке, увы..\n");
                        }
                        break;
                    case 3:
                        Console.Write("\nНажмите любую клавишу для продолжения...");
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда");
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        break;
                }

                if (isOpen)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
