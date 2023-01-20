using System;

namespace BattleOfHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter fighter = new Fighter();

            Fighter[] fighters =
            {
                new Fighter("Джон", 500, 50, 0),
                new Fighter("Марк", 250, 25, 20),
                new Fighter("Алекс", 150, 100, 10),
                new Fighter("Джек", 300, 75, 5)
            };

            int fighterNumber;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                fighters[i].ShowStats();
            }

            Console.WriteLine("\n** " + new string('-', 25) + " **");
            Console.Write("\nВыберите номер первого бойца: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter firstFighter = fighters[fighterNumber];

            Console.Write("Выберите номер второго бойца: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter secondFighter = fighters[fighterNumber];
            Console.WriteLine("\n** " + new string('-', 25) + " **");

            // арена
            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                firstFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firstFighter.Damage);
                firstFighter.ShowCurrentHealth();
                secondFighter.ShowCurrentHealth();
            }

            fighter.ShowWinner(firstFighter, secondFighter);
        }
    }

    class Fighter
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;

        public Fighter() { }

        public Fighter(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public int Health
        {
            get
            {
                return _health;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"Боец - '{_name}'\n"
                + $" - здоровье: {_health}\n"
                + $" - наносимый урон: {_damage}\n"
                + $" - броня: {_armor}\n");
        }

        public void ShowCurrentHealth()
        {
            Console.WriteLine($"{_name} здоровье: {_health}\n");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage - _armor;
        }

        public void ShowWinner(Fighter firstFighter, Fighter secondFighter)
        {
            if (firstFighter._health <= 0 && secondFighter._health <= 0)
            {
                Console.WriteLine("\tНичья\n");
            }
            else if (firstFighter._health <= 0)
            {
                Console.WriteLine($"\tПобедил {secondFighter._name}\n");
            }
            else if (secondFighter._health <= 0)
            {
                Console.WriteLine($"\tПобедил {firstFighter._name}\n");
            }
        }
    }
}
