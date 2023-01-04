using System;
/**
 * Даны две переменные. 
 * Поменять местами значения двух переменных. 
 * Вывести на экран значения переменных до перестановки и после.
 * К примеру, есть две переменные имя и фамилия, они сразу инициализированные, 
 * но данные не верные, перепутанные. 
 * Вот эти данные и надо поменять местами через код.
 */
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
