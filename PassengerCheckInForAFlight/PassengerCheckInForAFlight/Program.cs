using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerCheckInForAFlight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sectors = { 6, 28, 15, 15, 17 };
            bool isOpen = true;

            while (isOpen)
            {
                Console.SetCursorPosition(0, 18);

                for (int i = 0; i < sectors.Length; i++)
                {
                    Console.WriteLine($"В секторе {i + 1} свободно {sectors[i]} мест");
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Регистрация рейса\n");
                Console.WriteLine("1 - забронировать места\n"
                    + "2 - выход из программы\n");
                Console.Write("Введите номер команды: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int userSector;
                        int userPlaceAmount;
                        Console.Write("В каком секторе вы хотите лететь? ");
                        userSector = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (sectors.Length < userSector || 0 > userSector)
                        {
                            Console.WriteLine("Такого сектора не существует");
                            break;
                        }

                        Console.Write("Сколько мест вы хотите забронировать? ");
                        userPlaceAmount = Convert.ToInt32(Console.ReadLine());
                        if (0 > userPlaceAmount)
                        {
                            Console.WriteLine("Неверное количество мест");
                            break;
                        }
                        if (sectors[userSector] < userPlaceAmount)
                        {
                            Console.WriteLine($"В секторе {userSector + 1} недостаточно мест для бронирования. "
                            + $"Остаток {sectors[userSector]}");
                            break;
                        }
                        sectors[userSector] -= userPlaceAmount;
                        Console.WriteLine("Бронирование успешно!");
                        break;
                    case 2:
                        isOpen = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
