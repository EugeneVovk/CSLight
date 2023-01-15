using System;
 
namespace DinamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isCounting = true;
            int size = 0;
            int[] memory = new int[1];
            string userInput;
            string displayTheTotal = "sum";
            string exitTheApp = "exit";

            while (isCounting)
            {
                Console.Write("\nТы можешь ввести:\n"
                    + "\n * любое целое число"
                    + "\n * или 'sum' - для суммирования всех введённых тобою чисел"
                    + "\n * или 'exit' - чтобы закрыть программу"
                    + "\n\nТвой выбор: ");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int result))
                {
                    Console.WriteLine($"\nВведено число {userInput}");
                    memory[size++] = result;
                    DisplayTheArray(memory);
                    memory = IncreaseArray(memory);
                }
                else
                {
                    if (displayTheTotal == userInput)
                    {
                        Console.WriteLine($"\n\tСумма всех чисел в массиве, "
                            + $"равна {SumAllElements(memory)}");
                    }
                    else if (exitTheApp == userInput)
                    {
                        Console.WriteLine("\n\tВыход из программы\n");
                        isCounting = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Непонятный ввод, попробуй ещё :)");
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void DisplayTheArray(int[] array)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Массив: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }

        private static int[] IncreaseArray(int[] sourceArray)
        {
            int[] targetArray = new int[sourceArray.Length + 1];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                targetArray[i] = sourceArray[i];
            }

            return targetArray;
        }

        private static int SumAllElements(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
