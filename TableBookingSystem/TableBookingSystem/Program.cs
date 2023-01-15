using System;
/**
 * Система брони
 * Кафе
 * В кафе есть столы и места
 * А если за столом мест с достатком, то могут к ним кого-то подсадить
 */
namespace TableBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool cafeIsOpen = true;
            int[] tables = { 2, 2, 2, 4, 2, 6, 2, 3, 4, 8 };
            string selectOperation;

            Console.WriteLine("\nТебя приветствует система бронирования столов!\n");

            while (cafeIsOpen)
            {
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("\nСписок столов:");
                for (int i = 0; i < tables.Length; i++)
                {
                    //Console.WriteLine($" Стол #{i + 1} - {tables[i]} чел.");
                    Console.WriteLine($" За столом #{i + 1} свободно {tables[i]} мест");
                }

                Console.SetCursorPosition(0, 2);
                Console.WriteLine("\nВыбери операцию:\n"
                    + " 1 - забронировать место\n"
                    + " 2 - выход из программы\n"
                    + " -------------------------\n");

                Console.Write("Твой выбор ");
                selectOperation = Console.ReadLine();

                switch (selectOperation)
                {
                    case "1":
                        int userTable;
                        int userSeat;

                        Console.WriteLine("\nБронирование стола");
                        Console.Write("\nЗа каким столом ты хочешь забронировать место? ");
                        userTable = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (userTable >= tables.Length || userTable < 0)
                        {
                            Console.WriteLine("\n\tНеправильно выбран стол");
                            break;
                        }
                        Console.Write("Сколько мест ты хочешь забронировать? ");
                        userSeat = Convert.ToInt32(Console.ReadLine());

                        if (tables[userTable] < userSeat || userSeat < 0)
                        {
                            Console.WriteLine($"За столом #{tables[userTable]} недостаточно мест");
                            break;
                        }
                        tables[userTable] -= userSeat;

                        Console.WriteLine("\n\tБронирование прошло успешно!");
                        break;
                    case "2":
                        Console.WriteLine("\nВыход из программы\n");
                        cafeIsOpen = false;
                        break;
                    default:
                        Console.WriteLine("\nВыбрана неверная операция");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
