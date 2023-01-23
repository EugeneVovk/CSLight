using System;

namespace TankStateEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tank tank = new Tank(500, 50, 100, 500);
            Tank tank2 = new Tank();

            Console.WriteLine("Танк 1\n" + new string('-', 14));
            tank.ShowStats();
            tank.TakeDamage(100);
            tank.ShowStats();

            Console.WriteLine("Танк 2\n" + new string('-', 14));
            tank2.ShowStats();
        }
    }

    class Tank
    {
        private int _health;
        private int _armor;
        private int _damage;
        private int _speed;

        public Tank(int health, int armor, int damage, int speed)
        {
            if (health < 0)
            {
                health = 100;
            }
            else
            {
                _health = health;
            }
            _armor = armor;
            _damage = damage;
            _speed = speed;
        }

        public Tank()
        {
            _health = 100;
            _armor = 50;
            _damage = 100;
            _speed = 200;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Здоровье - {_health}\n"
                + $"Броня - {_armor}\n"
                + $"Урон - {_damage}\n"
                + $"Скорость - {_speed}\n");
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine("Был нанесён урон!");
            _health -= damage - _armor;
        }
    }
}
