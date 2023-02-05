using System;
using System.Collections.Generic;

namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ageCount = 0;

            List<Fish> fishes = new List<Fish>()
            {
                new Fish("Гуппи", 3),
                new Fish("Гуппи", 4),
                new Fish("Гуппи", 5),
                new Fish("Неоны", 5),
                new Fish("Неоны", 6),
                new Fish("Неоны", 7),
                new Fish("Меченосец", 4),
                new Fish("Данио", 5),
                new Fish("Гурами", 4),
                new Fish("Барбус", 6),
                new Fish("Барбус", 7),
                new Fish("Барбус", 8),
                new Fish("Петушок", 4),
                new Fish("Петушок", 5),
                new Fish("Моллинезия", 4),
                new Fish("Моллинезия", 5),
                new Fish("Анциструс", 10)
            };

            Aquarium aquarium = new Aquarium(fishes);

            while (aquarium.Fishes.Count > 0)
            {
                Console.WriteLine($"Возраст аквариума: {ageCount}");

                for (int i = 0; i < aquarium.Fishes.Count; i++)
                {
                    aquarium.Fishes[i].Age--;

                    if (aquarium.Fishes[i].Age <= 0)
                    {
                        Console.Write("\n\tПогибла");
                        aquarium.Fishes[i].ShowFish();
                        aquarium.Fishes.Remove(aquarium.Fishes[i]);
                    }

                }

                if (aquarium.Fishes.Count > 0)
                {
                    Console.WriteLine($"\t\t\tРыб в аквариуме: {aquarium.Fishes.Count}");
                }
                else
                {
                    Console.WriteLine("\n\tЖивых рыбок не осталось\n"
                        + " Теперь спокойно можно помыть аквариум\n\n");
                }

                Console.ReadKey();

                ageCount++;
            }
        }
    }

    class Aquarium
    {
        public List<Fish> Fishes { get; }

        public Aquarium(List<Fish> fishes)
        {
            Fishes = fishes;
        }

        public void AddFish(Fish fish)
        {
            Fishes.Add(fish);
        }

        public void RemoveFish(Fish fish)
        {
            Fishes.Remove(fish);
        }
    }

    class Fish
    {
        private string _name;
        public int Age { get; set; }

        public Fish(string name, int age)
        {
            _name = name;
            Age = age;
        }

        public void ShowFish()
        {
            Console.WriteLine($" название: {_name}");
        }
    }
}
