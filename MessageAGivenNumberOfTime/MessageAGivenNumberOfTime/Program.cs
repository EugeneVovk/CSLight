using System;

namespace MessageAGivenNumberOfTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userReply;
            int numberOfLoop;

            Console.WriteLine("Что ты хочешь сказать?");
            userReply= Console.ReadLine();
            Console.WriteLine("Сколько раз ты готов это повторить?");
            numberOfLoop= Convert.ToInt32(Console.ReadLine()); 

            for (int i = 0; i < numberOfLoop; i++)
            {
                Console.WriteLine(userReply);
            }
        }
    }
}
