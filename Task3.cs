using System;

/**
* Вы задаете вопросы пользователю, по типу "как вас зовут", "какой ваш знак зодиака" и тд,
* после чего, по данным, которые он ввел, формируете небольшой текст о пользователе.
* "Вас зовут Алексей, вам 21 год, вы водолей и работаете на заводе."
*/
namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string zodiac;
            int age;
            string work;

            Console.WriteLine("Как тебя зовут?");
            name = Console.ReadLine();
            Console.WriteLine("Какой твой знак зодиака?");
            zodiac = Console.ReadLine();
            Console.WriteLine("Сколько тебе лет?");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Кем ты работаешь?");
            work = Console.ReadLine();
            Console.WriteLine($"Тебя зовут {name}, тебе {age}, "
               + $"по знаку зодиака ты {zodiac} и работаешь как {work}.");
        }
    }
}
