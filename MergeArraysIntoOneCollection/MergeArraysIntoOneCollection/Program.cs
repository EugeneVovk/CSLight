using System;
using System.Collections.Generic;

namespace MergeArraysIntoOneCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = { "1", "2", "1" };
            string[] array2 = { "3", "2" };            

            var list = new List<string>();

            list.AddRange(array1);
            list.AddRange(array2);

            PrintCollection(list);
            SortList(list);
        }

        private static void SortList(List<string> list)
        {
            var set = new SortedSet<string>();

            foreach (var item in list)
            {
                set.Add(item);                
            }

            foreach (var item in set)
            {
                Console.Write(item + " ");
            }
        }

        private static void PrintCollection<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item+" ");
            }

            Console.WriteLine();
        }
    }
}
