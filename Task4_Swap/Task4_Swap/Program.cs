using System;

namespace Task4_Swap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "John";
            string surname = "Paul";

            Console.WriteLine($"Before Swap:\n\tname = {name},\n\tsurname = {surname}");

            string temp = name;
            name = surname;
            surname = temp;

            Console.WriteLine($"After Swap:\n\tname = {name},\n\tsurname = {surname}");
        }
    }
}
