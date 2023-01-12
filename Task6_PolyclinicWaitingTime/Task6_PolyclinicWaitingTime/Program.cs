using System;

namespace Task6_PolyclinicWaitingTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oldLadiesInQueue;
            int waitHours;
            int waitMinutes;
            int fixedTimePerPerson = 10;
            int numberOfMinutesPerHour = 60;

            Console.WriteLine("Ты заходишь в поликлинику\n"
                + "...и видишь огромную очередь из старушек\n");
            Console.Write("Сколько человек в очереди? ");
            oldLadiesInQueue = Convert.ToInt32(Console.ReadLine());

            int totalWaitTime = oldLadiesInQueue * fixedTimePerPerson;

            waitHours = totalWaitTime / numberOfMinutesPerHour;
            waitMinutes = totalWaitTime % numberOfMinutesPerHour;

            Console.WriteLine($"Увы, придётся отстоять {waitHours} часов и {waitMinutes} минут\n");  
        }
    }
}
