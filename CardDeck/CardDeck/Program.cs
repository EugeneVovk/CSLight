using System;
using System.Collections.Generic;

namespace CardDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"\n\tПривет, как тебя зовут? ");
            string name = Console.ReadLine();

            Player player = new Player(name);

            Deck deck = new Deck();
            deck.CollectDeck();
            deck.ShuffleCards();

            int userNumberOfCard;
            int counCardInHand = 0;
            int userChoise;
            bool isWork = true;

            while (isWork)
            {
                Console.Write($"\n{player.Name}, перед тобою колода из {Deck.NUMBER_OF_CARDS} карт\n\n"
                    + " Ты можешь:\n"
                    + " 1 - тянуть одну карту\n"
                    + " 2 - вытянуть несколько карт\n"
                    + " 3 - раскрыть всё карты\n"
                    + " 4 - выйти из программы\n");

                Console.Write($"\n{player.Name}, твой выбор 1, 2, 3 или 4: ");

                if (int.TryParse(Console.ReadLine(), out userChoise))
                {
                    switch (userChoise)
                    {
                        case 1:
                            player.TakeCard(deck.PullCard());
                            counCardInHand++;
                            break;
                        case 2:
                            Console.Write("\nСколько хочешь вытянуть? ");
                            userNumberOfCard = Convert.ToInt32(Console.ReadLine());

                            try
                            {
                                for (int i = 0; i < userNumberOfCard; i++)
                                {
                                    player.TakeCard(deck.PullCard());
                                    counCardInHand++;
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine($"\n\t{player.Name}, ты хочешь {userNumberOfCard} карт,"
                                    + $"\n\tно колоде только {Deck.NUMBER_OF_CARDS}\n");
                            }

                            break;
                        case 3:
                            player.ShowCards();
                            break;
                        case 4:
                            Console.WriteLine($"\n\tПока, {player.Name}..\n");
                            isWork = false;
                            break;
                    }

                    if (counCardInHand >= Deck.NUMBER_OF_CARDS)
                    {
                        Console.WriteLine("\n\tУ тебя на руках все карты"
                            + $"\n\t{player.Name}, тебе пора уходить\nПока...");
                        isWork = false;
                    }
                    else
                    {
                        Console.WriteLine("\nВсего карт у тебя на руках: " + counCardInHand);
                        Console.WriteLine($"В колоде осталось {deck.RemainCardInDeck() - counCardInHand} карт");
                    }
                }
                else
                {
                    Console.WriteLine("\n\tНекорректный ввод. Попробуй ещё раз...");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        private string _name;
        private List<Card> _cardsInHand;

        public Player(string name)
        {
            _name = name;
            _cardsInHand = new List<Card>(Deck.NUMBER_OF_CARDS);
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public void TakeCard(Card card)
        {
            _cardsInHand.Add(card);
        }

        public void ShowCards()
        {
            for (int i = 0; i < _cardsInHand.Count; i++)
            {
                _cardsInHand[i].ShowCard();
            }
        }
    }

    class Card
    {
        private CardValue _value;
        private CardSuit _suit;

        public Card(CardValue cardValue, CardSuit cardSuit)
        {
            _value = cardValue;
            _suit = cardSuit;
        }

        public void ShowCard()
        {
            Console.WriteLine(" " + _value + " - " + _suit + " ");
        }
    }

    class Deck
    {
        public const int NUMBER_OF_CARDS = 36;
        private List<Card> _cards;
        private Random _random;
        private int _cardInUserHands;

        public Deck()
        {
            _cards = new List<Card>(NUMBER_OF_CARDS);
            _random = new Random();
        }

        public List<Card> CollectDeck()
        {
            foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
            {
                foreach (CardSuit cardSuite in Enum.GetValues(typeof(CardSuit)))
                {
                    _cards.Add(new Card(cardValue, cardSuite));
                }
            }

            return _cards;
        }

        public void ShuffleCards()
        {
            int randomCard;
            Card tempCard;

            for (int i = 0; i < _cards.Count; i++)
            {
                randomCard = _random.Next(0, _cards.Count);
                tempCard = _cards[i];
                _cards[i] = _cards[randomCard];
                _cards[randomCard] = tempCard;
            }
        }

        public void ShowDeck()
        {
            foreach (Card card in _cards)
            {
                card.ShowCard();
            }

            Console.WriteLine();
        }

        public void ShowCardByIndex(int index)
        {
            _cards[index].ShowCard();
        }

        public void DeleteCard(Card card)
        {
            _cards.Remove(card);
        }

        public int RemainCardInDeck()
        {
            return _cards.Count;
        }

        public Card PullCard()
        {
            if (_cardInUserHands < _cards.Count)
            {
                return _cards[_cardInUserHands++];
            }
            else
            {
                return null;
            }
        }
    }

    enum CardSuit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    enum CardValue
    {
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
