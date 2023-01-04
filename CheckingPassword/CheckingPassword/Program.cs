using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "123qwe";
            string userInput;

            Console.Write("Введите пароль: ");
            userInput = Console.ReadLine();

            if (userInput == password)
            {
                Console.WriteLine("Пароль принят.\nДоступ к базе данных разрешён.\n");
            }
            else
            {
                Console.WriteLine("Неверный пароль.\nДоступ закрыт.\n");
            }
        }
    }
}
