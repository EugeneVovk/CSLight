using System;
/**
 * Интерфейс - набор методов без реализации
 * 
 * Все нереализованные методы, которые определены внутри интерфейса
 * должны быть реализованы в классах наследниках
 * 
 * По интерфейсы мы можем хранить объекты
 */

namespace InterfaceEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMovable car = new Car();
            IMovable human = new Human();
        }
    }

    interface IMovable
    {
        /**
         * Метод отвечает за то, чтобы что-то двигать
         */
        void Move();
        void ShowNewSpeed();
    }

    interface IBurnable
    {
        void Burn();
    }

    class Car : Vehicle, IMovable, IBurnable
    {
        public void Burn()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
        }

        public void ShowNewSpeed()
        {

        }
    }

    class Human : IMovable
    {
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void ShowNewSpeed()
        {
            throw new NotImplementedException();
        }
    }

    class Vehicle
    {

    }
}
