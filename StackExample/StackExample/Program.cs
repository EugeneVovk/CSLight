using System;
using System.Collections.Generic;

namespace StackExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LIFO последний вошёл первый вышел
            Stack<int> numbers = new Stack<int>();

            // 1. довление элемента
            numbers.Push(1);
            numbers.Push(2);
            numbers.Push(3);
            numbers.Push(4);
            numbers.Push(5);

            PrintCollection(numbers);

            // 2. извлечение элемента
            Console.WriteLine($"Извлечение элемента {numbers.Pop()}\n");

            // 3. получение первого элемента
            Console.WriteLine($"Первый элемент в стеке - {numbers.Peek()}\n");

            // 4. перебор коллекции
            while (numbers.Count > 0)
            {
                Console.WriteLine($" Следующий элемент в стеке - {numbers.Pop()}");
            }

            PrintCollection(numbers);

            List<int> nums = new List<int>();
            nums.Add(1);
            nums.Add(2);
            nums.Add(3);
            nums.Add(4);
            nums.Add(5);

            PrintCollection(nums);
        }

        private static void PrintCollection<T>(Stack<T> collection)
        {
            Console.WriteLine("\nСписок коллекции Stack:");
            if (collection.Count > 0)
            {
                foreach (var item in collection)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine('\n');
            }
            else
            {
                Console.WriteLine("\tНет элементов в коллекции");
            }
        }

        private static void PrintCollection<T>(List<T> collection)
        {
            Console.WriteLine("\nСписок коллекции List:");
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine('\n');
        }
    }
}
