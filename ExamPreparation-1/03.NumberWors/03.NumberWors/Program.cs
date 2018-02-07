using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    class Program
    {
        private static int MaxRounds = 1000000;
        static void Main(string[] args)
        {
            var firstCards = new Queue<string>(Console.ReadLine().Split());
            var secondCards = new Queue<string>(Console.ReadLine().Split());

            var roundsCounter = 0;
            var gameOver = false;
            while (roundsCounter < MaxRounds && firstCards.Count >= 1 && secondCards.Count >= 1 && !gameOver)
            {
                roundsCounter++;
                var firstCard = firstCards.Dequeue();
                var secondCard = secondCards.Dequeue();
                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstCards.Enqueue(firstCard);
                    firstCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard) < GetNumber(secondCard))
                {
                    secondCards.Enqueue(secondCard);
                    secondCards.Enqueue(firstCard);
                }
                else
                {
                    var listOfCards = new List<string>() { firstCard, secondCard };
                    while (!gameOver)
                    {
                        if (firstCards.Count >= 3 && secondCards.Count >= 3)
                        {
                            var firstSum = 0;
                            var secondSum = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                firstCard = firstCards.Dequeue();
                                secondCard = secondCards.Dequeue();
                                listOfCards.Add(firstCard);
                                listOfCards.Add(secondCard);
                                firstSum += GetChar(firstCard);
                                secondSum += GetChar(secondCard);
                            }
                            if (firstSum > secondSum)
                            {
                                TakeCards(listOfCards, firstCards);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                TakeCards(listOfCards, secondCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            var result = "";
            if (firstCards.Count > secondCards.Count)
            {
                result = "First player wins";
            }
            else if (firstCards.Count < secondCards.Count)
            {
                result = "Second player wins";
            }
            else
            {
                result = "Draw";
            }
            Console.WriteLine($"{result} after {roundsCounter} turns");
        }

        private static void TakeCards(List<string> listOfCards, Queue<string> winerCards)
        {
            foreach (var card in listOfCards.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)))
            {
                winerCards.Enqueue(card);
            }
        }

        static int GetNumber(string Card)
        {
            return int.Parse(Card.Substring(0, Card.Length - 1));
        }

        static int GetChar(string Card)
        {
            return Card[Card.Length - 1];
        }
    }
}
