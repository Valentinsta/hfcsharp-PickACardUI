using System;
using System.Collections.Generic;

namespace PickACardUI
{
    internal class CardPicker
    {
        private static readonly Random random = new();
        private static int cardCounter = 0;

        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            HashSet<string> pickedCardSet = new HashSet<string>();

            for (int i = 0; i < numberOfCards; i++)
            {
                string card = GenerateRandomCard(pickedCardSet);
                pickedCards[i] = card;
                pickedCardSet.Add(card);
            }

            return pickedCards;
        }

        private static string GenerateRandomCard(HashSet<string> pickedCardSet)
        {
            string card;
            int maxAttempts = 52;

            do
            {
                card = $"{RandomValue(),2} of {RandomSuit()}";
                maxAttempts--;
            } while (pickedCardSet.Contains(card) && maxAttempts > 0);

            if (maxAttempts == 0)
            {
                throw new InvalidOperationException("Cannot generate a unique card.");
            }

            cardCounter++;

            return card;
        }


        private static string RandomSuit()
        {
            int value = random.Next(1, 5);
            return value switch
            {
                1 => "♠️",
                2 => "♥️",
                3 => "♣️",
                _ => "♦️",
            };
        }

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            return value switch
            {
                1 => "A",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => value.ToString(),
            };
        }

        private static double[] Doubles(int count)
        {
            double[] randomDoubles = new double[count];
            for (int i = 0; i < randomDoubles.Length; i++)
            {
                randomDoubles[i] = random.NextDouble();
            }
            return randomDoubles;
        }
    }
}
