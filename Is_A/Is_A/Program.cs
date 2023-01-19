using System;
/**
 * Связь Is-a
 * Под этим понятием скрывается отношение наследования 
 * 
 * Бой между двумя войнами
 * 
 * И рыцать, и варвар содержат в себе качества война:
 * - поведение (методы)
 * - состояние (поля)
 * При этом рыцарь и варвар обладают своими уникальными возможностями
 * 
 * Чтобы не дать возможность в Main() обращаться 
 * к полям классов наследников и тем самым их менять (читерить)
 * в базовом классе ставим модификатор protected, 
 * который позволяет получить доступ к полям и методам базового класса
 * только тем, кто от него унаследован
 * 
 * ключевое слово :base - вызов конструктора из базового класса
 */

namespace Is_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Knight warrior1 = new Knight(100, 10);
            Barbarian warrior2 = new Barbarian(100, 1, 7, 2);

            warrior1.TakeDamage(500);
            warrior2.TakeDamage(250);

            Console.Write("Рыцарь: ");
            warrior1.ShowInfo();
            Console.Write("Варвар: ");
            warrior2.ShowInfo();            
        }
    }

    class Warrior
    {
        // доступ только наследникам класса
        protected int Health;
        protected int Armor;
        protected int Damage;

        public Warrior(int health, int armor, int damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Health);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }

    class Knight : Warrior
    {
        // вызвать конструктор базового класса, через :
        public Knight(int health, int damage)
            : base(health, 5, damage) { }

        public void Pray()
        {
            Armor += 2;
        }
    }

    class Barbarian : Warrior
    {
        public int AttackSpeed;
        public Barbarian(int health, int armor, int damage, int attackSpeed)
            : base(health, armor, damage * attackSpeed)
        {
            AttackSpeed = attackSpeed;
        }

        public void Shout()
        {
            Health += 10;
            Armor -= 2;
        }
    }
}
