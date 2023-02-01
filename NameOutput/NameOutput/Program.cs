using System;

namespace NameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            char userSymbol;
            int column = 3;
            int middleLine;
            int count = 0;

            Console.WriteLine("Привет!");
            Console.Write("Как тебя зовут? ");
            userName = Console.ReadLine();
            Console.Write("Введи любой символ ");
            userSymbol = Convert.ToChar(Console.ReadLine());
                        
            middleLine = (userSymbol + userName + userSymbol).Length;

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < middleLine; j++)
                {
                    if (i == 1 && j > 0 && j < middleLine - 1)
                    {
                        Console.Write(userName[count++]);
                    }
                    else
                    {
                        Console.Write(userSymbol);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
