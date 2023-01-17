using System;
using System.Collections.Generic;

namespace QueueExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // FIFO
            Queue<string> patientsInTheClinic = new Queue<string>();

            // 1. добавить в очередь
            patientsInTheClinic.Enqueue("Kate");
            patientsInTheClinic.Enqueue("Alex");
            patientsInTheClinic.Enqueue("Artsyom");
            patientsInTheClinic.Enqueue("Dmitriy");
            patientsInTheClinic.Enqueue("Saule");

            PrintCollection(patientsInTheClinic);

            // 2. забрать из очереди (выводит и удаляет)
            Console.WriteLine($"Сейчас на приём к врачу идёт - "
                + $"{patientsInTheClinic.Dequeue()}.");

            PrintCollection(patientsInTheClinic);

            // 3. обратиться к первому по очереди элементу (выводит)
            Console.WriteLine($"Следующий в очереди - "
                + $"{patientsInTheClinic.Peek()}.");

            PrintCollection(patientsInTheClinic);

        }

        private static void PrintCollection<T>(Queue<T> collection)
        {
            Console.WriteLine("\nСписок коллекции:");
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine('\n');
        }
    }
}
