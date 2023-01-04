using System;
/**
 * Легенда:
 * Вы заходите в поликлинику и видите огромную очередь из старушек, 
 * вам нужно рассчитать время ожидания в очереди.
 * 
 * Формально:
 * Пользователь вводит кол-во людей в очереди.
 * Фиксированное время приема одного человека всегда равно 10 минутам.
 * Пример ввода: Введите кол-во старушек: 14
 * Пример вывода: "Вы должны отстоять в очереди 2 часа и 20 минут."
 */
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
