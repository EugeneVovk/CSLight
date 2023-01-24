using System;

namespace PropertyEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(40, 40);
            Renderer renderer = new Renderer();

            renderer.Draw(player.PositionX, player.PositionY, '@');
        }
    }

    class Player
    {
        private int _positionX;
        private int _positionY;

        public Player(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public int PositionX
        {
            get
            {
                return _positionX;
            }
        }

        public int PositionY
        {
            get
            {
                return _positionY;
            }
        }
    }

    class Renderer
    {
        public void Draw(int positionX, int positionY, char playerSymbol)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.WriteLine(playerSymbol);
        }
    }
}
