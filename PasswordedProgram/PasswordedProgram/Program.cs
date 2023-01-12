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
            string messageSuccess = "\n\tСекретное сообщение доступно!\n";
            string messageFail = "\n\tДоступ запрещён!\n";
            string messageWarning = "Пароль неверный!\nПопробуй ещё раз";
            int lastAttempt = 1;

            Console.WriteLine("\n\tПривет!\n");

            for (int i = passwordAttempt; i > 0; i--)
            {
                Console.Write("Введи пароль для доступа к тайному сообщению: ");
                enteredPassword = Console.ReadLine();

                if (userPassword == enteredPassword)
                {
                    Console.Clear();
                    DisplayMessage(messageSuccess, ConsoleColor.Green);
                    break;
                }
                else if (passwordAttempt == lastAttempt)
                {
                    Console.Clear();
                    DisplayMessage(messageFail, ConsoleColor.Red);
                }
                else
                {
                    DisplayMessage(messageWarning, ConsoleColor.Yellow);
                    Console.WriteLine($"Осталось попыток: {--passwordAttempt}\n");
                }
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

