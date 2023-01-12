using System;

namespace PasswordedProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userPassword = "qwe123";
            int passwordAttempt = 3;
            string enteredPassword;
            string msgSuccess = "\n\tСекретное сообщение доступно!\n";
            string msgFail = "\n\tДоступ запрещён!\n";
            string msgWarning = "Пароль неверный!\nПопробуй ещё раз";
            int lastAttempt = 1;

            Console.WriteLine("\n\tПривет!\n");

            while (passwordAttempt > 0)
            {
                Console.Write("Введи пароль для доступа к тайному сообщению: ");
                enteredPassword = Console.ReadLine();

                if (userPassword == enteredPassword)
                {
                    Console.Clear();
                    DisplayMessage(msgSuccess, ConsoleColor.Green);
                    break;
                }
                else if (passwordAttempt == lastAttempt)
                {
                    Console.Clear();
                    DisplayMessage(msgFail, ConsoleColor.Red);
                }
                else
                {
                    DisplayMessage(msgWarning, ConsoleColor.Yellow);
                    Console.WriteLine($"Осталось попыток: {passwordAttempt - 1}\n");
                }

                passwordAttempt--;
            }
        }

        static void DisplayMessage(string message, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }
    }
}

