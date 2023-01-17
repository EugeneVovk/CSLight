using System;
using System.Collections.Generic;

namespace ListExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> socialNetworks = new List<string>();

            // 1. добавление элементов в список - O(1)
            socialNetworks.Add("YouTube");
            socialNetworks.Add("Facebook");
            socialNetworks.Add("Instagram");
            socialNetworks.Add("Twitter");

            // 2. вставка в произвольное место - O(n) -
            // линейное увеличение сложноти от количества элементов в списке
            socialNetworks.Insert(1, "TikTok");

            // 3. удаление элемента из списка - O(n)
            // удаление последнего элемента - O(1), т.к. ничего сдвигать не надо
            socialNetworks.Remove("Facebook");
            socialNetworks.RemoveAt(1);

            // 4. сортировка списка - быстрая сортировка
            socialNetworks.Sort();

            // 5. получение элемента по индексу
            Console.WriteLine(socialNetworks[1]);

            // 6. получение индекса по значению
            Print(socialNetworks);
            Console.WriteLine("Твиттер в коллекции находится на позицииЖ " 
                + socialNetworks.IndexOf("Twitter"));

            // 7. добавление элементов из массива/списка
            string[] socialNetworksArray = { "VK", "Telegram", "Discord" };
            List<string> socialNetworksList = new List<string>();
            socialNetworksList.AddRange(socialNetworksArray);
            socialNetworksList.AddRange(socialNetworks);

            // 8. очистить лист
            socialNetworksList.Clear();

            // 9. получить размер коллекции
            Console.WriteLine($"\nРазмер коллекции - {socialNetworksList.Count} элементов");

            Print(socialNetworksList);
        }

        private static void Print<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine('\n');
        }
    }
}
