using System;
using System.Collections.Generic;

namespace TrainPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                
                Ticket ticket = new Ticket(1000);
                Carriage carriage = new Carriage(new Random().Next(18, 54));
                Train train = new Train();

                new Program().CurrentTrainRouteInfo();

                if (ticket.SellTicket() > 0)
                {
                    Console.WriteLine($"Количество проданных билетов: {ticket.SellTicket()}\n");
                    Console.WriteLine($"\nКоличество вагонов в поезде: {train.GiveNumberOfCarriages(carriage, ticket.SellTicket())}");
                }

                train.SendTrain();

                Console.ReadKey();
                Console.Clear();
            }
        }

        public void CurrentTrainRouteInfo()
        {
            string startStation;
            string arrivalStation;

            Console.WriteLine("\n\tУкажите направление...");
            Console.Write(" Откуда: ");
            startStation = Console.ReadLine();
            Console.Write(" Куда: ");
            arrivalStation = Console.ReadLine();
            Console.Clear();

            new TrainDirection(startStation, arrivalStation).ShowDirectionInfo();
        }
    }

    class Train
    {
        public List<Carriage> Carriages;

        public Train()
        {
            Carriages = new List<Carriage>();
        }

        public int GiveNumberOfCarriages(Carriage carriage, int numberOfTicketSold)
        {
            int countSeatsInCarreage = 0;
            int incompleteCarreage = numberOfTicketSold % carriage.SeatsNumber;
            int carreageNumber = 0;

            for (int i = 0; i < numberOfTicketSold; i++)
            {
                if (countSeatsInCarreage == carriage.TrainCarriage.Length - 1)
                {
                    carriage.TakeSeat(countSeatsInCarreage++);
                    AddCarriage(carriage);
                    Console.WriteLine($" Вагон: {++carreageNumber} - количество мест: {countSeatsInCarreage}");
                    countSeatsInCarreage = 0;
                }
                else
                {
                    carriage.TakeSeat(countSeatsInCarreage++);
                }
            }

            if (incompleteCarreage != 0)
            {
                countSeatsInCarreage = 0;

                for (int i = 0; i < incompleteCarreage; i++)
                {
                    carriage.TakeSeat(countSeatsInCarreage++);
                }

                AddCarriage(carriage);
                Console.WriteLine($" Вагон: {++carreageNumber} - количество мест: {countSeatsInCarreage}");
            }

            return Carriages.Count;
        }

        public void AddCarriage(Carriage carriage)
        {
            Carriages.Add(carriage);
        }

        public void SendTrain()
        {
            if (Carriages.Count > 0)
            {
                Console.WriteLine("\n\tПоезд отправляется\n");
            }
            else
            {
                Console.WriteLine("\n\tОтмена рейса\n");
            }
        }
    }

    class Carriage
    {
        public int SeatsNumber;
        public char[] TrainCarriage { get; }

        public Carriage(int seatsNumber = 54)
        {
            SeatsNumber = seatsNumber;
            TrainCarriage = new char[SeatsNumber];
        }

        public void TakeSeat(int countSeatsInCarreage)
        {
            TrainCarriage[countSeatsInCarreage] = 'X';
        }
    }

    class TrainDirection
    {
        private string _fromCity;
        private string _toCity;

        public TrainDirection(string fromCity, string toCity)
        {
            _fromCity = fromCity;
            _toCity = toCity;
        }

        public void ShowDirectionInfo()
        {
            Console.WriteLine($"\n Направление: {_fromCity} - {_toCity}\n");
        }
    }

    class Ticket
    {
        private int _maxTicketNumber;

        public Ticket(int maxTicketNumber)
        {
            _maxTicketNumber = maxTicketNumber;
        }

        public int SellTicket()
        {
            Random random = new Random();

            return random.Next(0, _maxTicketNumber);            
        }

    }
}
