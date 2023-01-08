using System;

namespace StopWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stopWord = "FLUGGAENKDECHIOEBOLSEN";
            string userStopWord = null;

            while (stopWord != userStopWord)
            {
                Console.Write("Скажите особое слово: ");
                userStopWord = Console.ReadLine();
            }

            Console.WriteLine($"\nВы сказали '{userStopWord}'\nВаше право :)");
        }
    }
}
