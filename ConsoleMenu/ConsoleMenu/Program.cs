using System;

namespace ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            string userPassword;
            string confirmPassword;
            bool isWork = true;
            bool isVerified = true;

            Console.BackgroundColor = default;
            ConsoleColor defaulColor = Console.ForegroundColor;

            Console.WriteLine("\n\tПривет!");
            Console.SetCursorPosition(5, 5);
            Console.Write("Введи своё имя: ");
            userName = Console.ReadLine();

            while (isWork)
            {
                Console.Clear();

                while (isVerified)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.Write("Введи пароль: ");
                    userPassword = Console.ReadLine();
                    Console.Write("Подтверди пароль: ");
                    confirmPassword = Console.ReadLine();

                    if (userPassword != confirmPassword)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = default;
                        isVerified = false;
                    }

                    Console.Clear();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t{userName}, поздравляю!"
                    + $"\n   Регистрация прошла успешно\n");
                Console.ForegroundColor = defaulColor;
                Console.WriteLine("Для выхода нажми Esc");
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    isWork = false;
                }
            }
        }
    }
}
