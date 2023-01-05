using System;

namespace Task6_PolyclinicWaitingTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oldLadies;
            int timePerPerson = 10;
            int hours;
            int minutes;
            int time = 60;

            Console.WriteLine("Ты заходишь в поликлинику\n"
                + "...и видишь огромную очередь из старушек\n");
            Console.Write("Сколько человек в очереди? ");
            oldLadies = Convert.ToInt32(Console.ReadLine());

            hours = oldLadies * timePerPerson / time;
            minutes = oldLadies * timePerPerson % time;

            Console.WriteLine($"Увы, придётся отстоять {hours} часов и {minutes} минут\n");  
        }
    }
}
