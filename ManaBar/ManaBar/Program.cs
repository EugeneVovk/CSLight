using System;

namespace ManaBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float mana = 4;

            DrawManaBar(mana, 1);
        }

        private static void DrawManaBar(float valueMana, int position, char symbol = '_')
        {
            int maxValue = 10;
            float percentBarValue = Convert.ToSingle(valueMana) / maxValue * 100;

            string bar = "";

            for (int i = 0; i < valueMana; i++)
            {
                bar += '#';
            }

            Console.WriteLine($" Mana {percentBarValue}%");
            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.Write(bar);

            bar = "";

            for (float i = valueMana; i < maxValue; i++)
            {
                bar += symbol;
            }

            Console.Write(bar + ']');
            Console.WriteLine("\n\n\n");
        }
    }
}
