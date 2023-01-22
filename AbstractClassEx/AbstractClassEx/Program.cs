using System;
using System.Runtime.InteropServices;
/**
* Абстрактный классы - это некие чертежи для будущих классов
* От абстрактных классов мы, как правило, наследуемся
* т.е. объект абстрактного класса создать нельзя.
* 
* В абстактных классах, как и в интерфейсах, 
* может быть один или несколько нереализованных методов.
* 
* В отличие от абстрактного класса, в интерфейсе:
*  - нельзя сделать поле (можно сделать свойство)
*  - нельзя создать уже реализованные методы
*/
namespace AbstractClassEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles =
            {
                new Car(),
                new Train()
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
                Console.WriteLine(new string('-', 40));
            }
        }
    }

    abstract class Vehicle
    {
        protected float Speed;

        public abstract void Move();

        public float GeyCurrentSpeed()
        {
            return Speed;
        }

    }

    class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Эта машина и она едет по асфальту");
        }
    }

    class Train : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Это поезд и он едет по рельсам");
        }
    }
}
