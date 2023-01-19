using System;
/**
 * Инкапсуляция - это сокрытие данных и состояния
 * от неправильного внешнего воздействия
 * 
 * Чтобы получить значение приватных полей класса
 * 1. можно сделать автореализуемое свойство 
 *      public int Y { get; private set; }
 * 2. либо обслуживаемое свойство, когда сеттеры открыты
 *      и мы может применять какие-то свои проверки
 * 3. либо создать свои методы, которые 
 *      присылали бы нам значения наших полей 
 * 
 * Player - игрок
 * Renderer - отрисовка игрока в консоли
 */
namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(55, 10);
            renderer.Draw(player.X, player.Y);
        }
    }

    class Renderer
    {
        public void Draw(int x, int y, char character = '@')
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(character);
            Console.ReadKey(true);
        }
    }

    class Player
    {
        // инкапсулируем поля игрока
        private int _x;
        private int _y;

        public Player(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // но чтобы получить доступ к полям, пишем методы
        //public int GetPositionX()
        //{
        //    return _x;
        //}

        //public int GetPositionY()
        //{
        //    return _y;
        //}

        // но в C# геттеры и сеттеры пишутся иначе
        public int X
        {
            get
            {
                return _x;
            }
            private set
            {
                if (X > 0 && X < 100)
                {
                    _x = value;
                }
            }
        }

        // или такое написание
        public int Y { get; private set; }

        // также можно сделать сет внутри контекста класса (т.е. в конструкторе)
        public Player()
        {
            X = X;
            Y = Y;
        }
    }
}
