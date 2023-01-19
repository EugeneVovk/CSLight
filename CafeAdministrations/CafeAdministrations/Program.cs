using System;

namespace CafeAdministrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            Table table1 = new Table(1, 4);
            Table table2 = new Table(2, 8);

            // удобнее создавать столы в массиве и выводить через цикл
            Table[] tables = { table1, table2, new Table(3, 2), new Table(4, 2) };

            while (isOpen)
            {
                Console.WriteLine("\nАдминистрирование кафе\n");

                for (int i = 0; i < tables.Length; i++)
                {
                    tables[i].ShowInfo();
                }

                Console.Write("\nВведите номер стола: ");
                int chooseTable = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Введите количество мест для брони: ");
                int desiredSeats = Convert.ToInt32(Console.ReadLine());

                bool isReservationCompleted = tables[chooseTable].Reserve(desiredSeats);

                if (isReservationCompleted)
                {
                    Console.WriteLine("\n\tБронь прошла успешно!");
                }
                else
                {
                    Console.WriteLine("\n\tБронь не прошла. Недостаточно мест");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Table
    {
        public int Number;
        public int MaxSeats;
        public int FreeSeats;

        public Table(int number, int maxSeats)
        {
            Number = number;
            MaxSeats = maxSeats;
            FreeSeats = maxSeats;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Стол {Number}. Свободно мест {FreeSeats} из {MaxSeats}");
        }

        public bool Reserve(int seats)
        {
            if (FreeSeats >= seats)
            {
                FreeSeats -= seats;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
