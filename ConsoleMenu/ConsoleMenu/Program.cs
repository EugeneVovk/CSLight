using System;
using System.Threading;
/**
* При помощи всего, что вы изучили, создать приложение, которое может обрабатывать команды. 
* 
* Т.е. вы создаете меню, ожидаете ввода нужной команды, после чего выполняете действие, которое присвоено этой команде.
* 
* Примеры команд (требуется 4-6 команд, придумать самим):
* SetName – установить имя;
* ChangeConsoleColor- изменить цвет консоли;
* SetPassword – установить пароль;
* WriteName – вывести имя (после ввода пароля);
* Esc – выход из программы.
* Программа не должна завершаться после ввода, пользователь сам должен выйти из программы при помощи команды.
*/
namespace ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = "Ann";
            string userPassword = "qwe123";
            string confirmPassword = "";
            bool isWork = true;
            bool isVerified = false;

            Console.BackgroundColor = default;
            ConsoleColor defaulColor = Console.ForegroundColor;

            Console.WriteLine("\n\tПривет!");
            Console.SetCursorPosition(5, 5);
            Console.Write("Введи своё имя: ");
            userName = Console.ReadLine();

            while (isWork)
            {
                Console.Clear();

                while (!isVerified)
                {
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
                        isVerified = true;
                    }

                    Console.Clear();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t{userName}, поздравляю!"
                    + $"\n   Регистрация прошла успешно\n");
                Console.ForegroundColor = defaulColor;
                Console.WriteLine("Для выхода нажми Esc");
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        isWork = false;
                        break;
                }
            }
        }
    }
}
