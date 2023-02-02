using System;
using System.Threading;

namespace ThreeCurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string RubToUsdMenu = "1";
            const string RubToEuroMenu = "2";
            const string UsdToRubMenu = "3";
            const string EuroToRubMenu = "4";
            const string UsdToEuroMenu = "5";
            const string EuroToUsdMenu = "6";
            const string UsdToBtcMenu = "7";
            const string BtcToUsdMenu = "8";

            float userRub;
            float userUsd;
            float userEuro;
            float userBtc;
            float rubToUsd = 69.80f;
            float rubToEuro = 73.25f;
            float usdToRub = 72.65f;
            float usdToEuro = 1.08f;
            float euroToRub = 77.35f;
            float euroToUsd = 0.93f;
            float usdToBtc = 18101.0f;
            float btcToUsd = 18102.0f;
            float exchangeCurrencyCount;
            bool wantToChangeMoney = true;
            string userReply;
            string selectedOperation;
            string messageSuccess = "\n\tОперация прошла успешно!";
            string messageFail = "\n\tУвы, недостаточное количество средсв!";
            string answerYes = "Да";
            string answerNo = "Нет";
            int oneSecond = 1000;

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

                if (userReply == answerNo)
                {
                    wantToChangeMoney = false;
                }
                else if (userReply == answerYes)
                {
                    Console.WriteLine($"\nКурс валют на сегодня:\n"
                       + $"\n\tUSD: {rubToUsd} / {usdToRub}"
                       + $"\n\tEUR: {rubToEuro} / {euroToRub}"
                       + $"\n\tBTC: {usdToBtc} / {btcToUsd}"
                       );
                    Console.WriteLine("\nВыбери необходимую операцию:\n\n"
                        + $" {RubToUsdMenu} - обменять рубли на доллары\n"
                        + $" {RubToEuroMenu} - обменять рубли на евро\n"
                        + $" {UsdToRubMenu} - обменять доллары на рубли\n"
                        + $" {EuroToRubMenu} - обменять евро на рубли\n"
                        + $" {UsdToEuroMenu} - обменять доллары на евро\n"
                        + $" {EuroToUsdMenu} - обменять евро на доллары\n"
                        + $" {UsdToBtcMenu} - купить биткоин на доллары\n"
                        + $" {BtcToUsdMenu} - продать биткоин на доллары\n"
                        );
                    Console.Write("Твой выбор: ");
                    selectedOperation = Console.ReadLine();

                    switch (selectedOperation)
                    {
                        case RubToUsdMenu:
                            Console.Write("Обмен рублей на доллары\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userRub >= exchangeCurrencyCount)
                            {
                                userRub -= exchangeCurrencyCount;
                                userUsd += exchangeCurrencyCount / rubToUsd;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        case RubToEuroMenu:
                            Console.Write("Обмен рубли на евро\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userRub >= exchangeCurrencyCount)
                            {
                                userRub -= exchangeCurrencyCount;
                                userEuro += exchangeCurrencyCount / rubToEuro;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        case UsdToRubMenu:
                            Console.Write("Обмен доллары на рубли\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userUsd >= exchangeCurrencyCount)
                            {
                                userUsd -= exchangeCurrencyCount;
                                userRub += exchangeCurrencyCount * usdToRub;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        case EuroToRubMenu:
                            Console.Write("Обмен евро на рубли\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userEuro >= exchangeCurrencyCount)
                            {
                                userEuro -= exchangeCurrencyCount;
                                userRub += exchangeCurrencyCount * euroToRub;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        case UsdToEuroMenu:
                            Console.Write("Обмен доллары на евро\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userUsd >= exchangeCurrencyCount)
                            {
                                userUsd -= exchangeCurrencyCount;
                                userEuro += exchangeCurrencyCount / usdToEuro;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        case EuroToUsdMenu:
                            Console.Write("Обмен евро на доллары\n"
                                + "Сколько хочешь обменять? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userEuro >= exchangeCurrencyCount)
                            {
                                userEuro -= exchangeCurrencyCount;
                                userUsd += exchangeCurrencyCount / euroToUsd;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        case UsdToBtcMenu:
                            Console.Write("Покупка биткоина/ов за доллары\n"
                                + "Сколько хочешь купить? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userUsd >= exchangeCurrencyCount)
                            {
                                userUsd -= exchangeCurrencyCount;
                                userBtc += exchangeCurrencyCount / usdToBtc;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        case BtcToUsdMenu:
                            Console.Write("Продажа биткоина/ов за доллары\n"
                                + "Сколько хочешь продать? ");
                            exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                            if (userBtc >= exchangeCurrencyCount)
                            {
                                userBtc -= exchangeCurrencyCount;
                                userUsd += exchangeCurrencyCount * btcToUsd;
                                Console.WriteLine(messageSuccess);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(messageFail);
                            }

                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n\tНеверная операция!");
                            break;
                    }

                    Thread.Sleep(oneSecond);
                }
            }

            Console.Clear();
            Console.WriteLine("\n\tПока!\n\n");
        }
    }
}
