using System;
/**
 * Полиморфизм - 
 *      это способность обьекта использовать методы производного класса;
 *      способность метода/функции обрабатывать данные разных типов;
 *      один интерфейс и множества реализаций;
 *      
 * Паттерн 'Цикл Обновления'
 * ps:
 * - Методы, которые требуют переопределения, называются абстрактными. 
 *   Логично, что если класс содержит хотя бы один абстрактный метод, то он тоже является абстрактным.
 * - Очевидно, что обьект абстрактного класса невозможно создать, иначе он не был бы абстрактным.
 * - Производный класс имеет свойства и методы, принадлежащие базовому классу,
 *   и, кроме того, может иметь собственные методы и свойства.
 * - Метод, переопределяемый в производном классе, называется виртуальным. 
 *   В базовом абстрактном классе об этом методе нет никакой информации.
 * - Суть абстрагирования в том, чтобы определять метод в том месте, 
 *   где есть наиболее полная информация о том, как он должен работать.
 */

namespace AdHocPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Behavior[] behaviors =
            {
                new Walker(),
                new Jumper()
            };

            while (true)
            {
                foreach (var behavior in behaviors)
                {
                    behavior.Update();
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }

    class Behavior
    {
        public virtual void Update() { }
    }

    //abstract class Behavior
    //{
    //    public abstract void Update();
    //}

    class Walker : Behavior
    {
        public override void Update()
        {
            Console.WriteLine("Иду");
        }
    }

    class Jumper : Behavior
    {
        public override void Update()
        {
            Console.WriteLine("Прыгаю");
        }
    }
}
