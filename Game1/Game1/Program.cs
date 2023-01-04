using System;
/**
 * Программа, которая высчитывает урон, который доходит до персонажа
 * У нас есть: здоровье, броня и урон
 * Броня определяет процент того сколько урона вообще дойдёт
 */
namespace Game1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float health;
            int armor;
            int damage;
            int percentConverter = 100;

            Console.Write("Введите количество здоровья: ");
            health = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество брони: ");
            armor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество урона: ");
            damage = Convert.ToInt32(Console.ReadLine());

            //health -= Convert.ToSingle(damage) * armor / percentConverter;
            health -= Convert.ToSingle(damage) / percentConverter * armor;

            Console.WriteLine($"После атаки в {damage} урона, у вас осталось {health}% здоровья");
        }
    }
}
