using System;
using System.Threading;

namespace ThreeCurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float userRub = 0;
            float userUsd = 0;
            float userEuro = 0;
            float userBtc = 0;
            float rubToUsd = 69.80f;
            float rubToEuro = 73.25f;
            float usdToRub = 72.65f;
            float usdToEuro = 1.08f;
            float euroToRub = 77.35f;
            float euroToUsd = 0.93f;
            float usdToBtc = 18101.0f;
            float btcToUsd = 18102.0f;
            float exchangeCurrencyCount = 0;
            bool wantToChangeMoney = true;
            string userReply = "";
            string selectedOperation;
            string msgSuccess = "\n\tОперация прошла успешно!";
            string msgFail = "\n\tУвы, недостаточное количество средсв!";

            Console.WriteLine("\nПривет! Это конвертер валют");
            Console.Write("\nСколько у тебя рублей: ");
            userRub = Convert.ToSingle(Console.ReadLine());
            Console.Write("Сколько у тебя долларов: ");
            userUsd = Convert.ToSingle(Console.ReadLine());
            Console.Write("Сколько у тебя евро: ");
            userEuro = Convert.ToSingle(Console.ReadLine());
            Console.Write("Сколько у тебя биткойна/ов: ");
            userBtc = Convert.ToSingle(Console.ReadLine());
            Console.Clear();

            while (wantToChangeMoney)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"\nТвой баланс:"
                   + $"\n - рубли: {userRub}"
                   + $"\n - доллары: {userUsd}"
                   + $"\n - евро: {userEuro}"
                   + $"\n - биткоин: {userBtc}"
                   );

                Console.Write("\nТы хочешь обменять деньги? Да/Нет ");
                userReply = Console.ReadLine();

                if (userReply == "Нет")
                {
                    wantToChangeMoney = false;
                    break;
                }
                else if (userReply == "Да")
                {
                    Console.WriteLine($"\nКурс валют на сегодня:\n"
                       + $"\n\tUSD: {rubToUsd} / {usdToRub}"
                       + $"\n\tEUR: {rubToEuro} / {euroToRub}"
                       + $"\n\tBTC: {usdToBtc} / {btcToUsd}"
                       );
                    Console.WriteLine("\nВыбери необходимую операцию:\n\n"
                        + " 1 - обменять рубли на доллары\n"
                        + " 2 - обменять рубли на евро\n"
                        + " 3 - обменять доллары на рубли\n"
                        + " 4 - обменять евро на рубли\n"
                        + " 5 - обменять доллары на евро\n"
                        + " 6 - обменять евро на доллары\n"
                        + " 7 - купить биткоин на доллары\n"
                        + " 8 - продать биткоин на доллары\n"
                        );
                    Console.Write("Твой выбор: ");
                    selectedOperation = Console.ReadLine();

                    switch (selectedOperation)
                    {
                        case "1":
                            Console.Write("Обмен рублей на доллары\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userRub >= exchangeCurrencyCount)
                            {
                                userRub -= exchangeCurrencyCount;
                                userUsd += exchangeCurrencyCount / rubToUsd;
                                Console.WriteLine(msgSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        case "2":
                            Console.Write("Обмен рубли на евро\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userRub >= exchangeCurrencyCount)
                            {
                                userRub -= exchangeCurrencyCount;
                                userEuro += exchangeCurrencyCount / rubToEuro;
                                Console.WriteLine(msgSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        case "3":
                            Console.Write("Обмен доллары на рубли\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userUsd >= exchangeCurrencyCount)
                            {
                                userUsd -= exchangeCurrencyCount;
                                userRub += exchangeCurrencyCount * usdToRub;
                                Console.WriteLine(msgSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        case "4":
                            Console.Write("Обмен евро на рубли\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userEuro >= exchangeCurrencyCount)
                            {
                                userEuro -= exchangeCurrencyCount;
                                userRub += exchangeCurrencyCount * euroToRub;
                                Console.WriteLine(msgSuccess);

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        case "5":
                            Console.Write("Обмен доллары на евро\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userUsd >= exchangeCurrencyCount)
                            {
                                userUsd -= exchangeCurrencyCount;
                                userEuro += exchangeCurrencyCount / usdToEuro;
                                Console.WriteLine(msgSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        case "6":
                            Console.Write("Обмен евро на доллары\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userEuro >= exchangeCurrencyCount)
                            {
                                userEuro -= exchangeCurrencyCount;
                                userUsd += exchangeCurrencyCount / euroToUsd;
                                Console.WriteLine(msgSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        case "7":
                            Console.Write("Покупка биткоина/ов за доллары\n"
                                + "Сколько хочешь купить? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userUsd >= exchangeCurrencyCount)
                            {
                                userUsd -= exchangeCurrencyCount;
                                userBtc += exchangeCurrencyCount / usdToBtc;
                                Console.WriteLine(msgSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        case "8":
                            Console.Write("Продажа биткоина/ов за доллары\n"
                                + "Сколько хочешь продать? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userBtc >= exchangeCurrencyCount)
                            {
                                userBtc -= exchangeCurrencyCount;
                                userUsd += exchangeCurrencyCount * btcToUsd;
                                Console.WriteLine(msgSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(msgFail);
                            }

                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\n\tНеверная операция!");
                            break;
                    }
                    
                    Thread.Sleep(1000);
                }
            }

            Console.Clear();
            Console.WriteLine("\n\tПока!\n\n");
        }
    }
}
