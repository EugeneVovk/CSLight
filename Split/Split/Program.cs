using System;

namespace Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titleString = "Научим делать игры на Unity";
            string[] strings = titleString.Split(' ');

            foreach (string word in strings)
            {
                Console.WriteLine(word);
            }
        }
    }
}
