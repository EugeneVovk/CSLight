using System;

namespace NameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = "";
            char userSymbol;

            Console.WriteLine("Привет!");
            Console.Write("Как тебя зовут? ");
            userName = Console.ReadLine();
            Console.Write("Введи любой символ ");
            userSymbol = Convert.ToChar(Console.ReadLine());

            int sizeName = userName.Length;
            int row = sizeName + 2;
            int column = 3;
            int count = 0;

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (i == 1 && j > 0 && j < row - 1)
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
