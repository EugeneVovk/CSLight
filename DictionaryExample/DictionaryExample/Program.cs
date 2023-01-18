using System;
using System.Collections.Generic;

namespace DictionaryExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ключ - значение, типа мапа(java)
            Dictionary<string, string> countriesCapitals = new Dictionary<string, string>();

            // 1. добавление элемента
            countriesCapitals.Add("Австралия", "Канберра");
            countriesCapitals.Add("США", "Вашингтон");
            countriesCapitals.Add("Германия", "Берлин");
            countriesCapitals.Add("Швейцария", "Берн");
            countriesCapitals.Add("Украина", "Киев");

            // 2. обращение к элементу с проверкой (обработки ошибки)
            if (countriesCapitals.ContainsKey("Украина"))
            {
                Console.WriteLine(countriesCapitals["Украина"]);
            }

            // 3. перебор коллекции
            Console.WriteLine("\nПеребор по ключу:");
            foreach (var key in countriesCapitals.Keys)
            {
                Console.Write(" " + key);
            }
            Console.WriteLine();

            Console.WriteLine("\nПеребор по значению:");
            foreach (var value in countriesCapitals.Values)
            {
                Console.Write(" " + value);
            }
            Console.WriteLine();

            Console.WriteLine("\nПеребор всего словаря:");
            PrintDic(countriesCapitals);

            // 4. удалить элементы из коллекции
            countriesCapitals.Remove("Швейцария");

            PrintDic(countriesCapitals);
        }

        private static void PrintDic<K, V>(Dictionary<K, V> dic)
        {
            foreach (var item in dic)
            {
                Console.WriteLine($" Страна - {item.Key},\tстолица - {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
