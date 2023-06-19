using System;

namespace PickACardUI
{
    internal class CardPicker
    {
        private static readonly Random random = new();

        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];

            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = $"{RandomValue().PadLeft(2)} of {RandomSuit()}";
            }
            return pickedCards;
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
