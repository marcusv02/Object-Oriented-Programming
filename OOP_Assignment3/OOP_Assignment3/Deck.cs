using System;
using System.Collections.Generic;

namespace OOP_Assignment3
{
    public static class Deck
    {
        // An empty list is created which will hold all 52 cards.
        public static List<Card> deck = new List<Card>();
        private static Random rand = new Random();
        

        // Shuffles the deck.
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // When called, the human player is dealt 10 cards. After a card is dealt, it gets removed from the deck permanently.
        public static void DealHuman(Human human, int n)
        {
            for (int i = 0; i <= n - 1; i++)
            {
                human.hand.Add(deck[i]);
            }
            deck.RemoveRange(0, n);
        }

        // The computer player is dealt 10 cards too.
        public static void DealComputer(Computer computer, int n)
        {
            for (int i = 0; i <= n - 1; i++)
            {
                computer.hand.Add(deck[i]);
            }
            deck.RemoveRange(0, n);
        }

        // The human player is dealt only 1 card from the deck at random.
        public static void DealHuman(Human human)
        {
            int RandomCard = rand.Next(deck.Count);
            human.hand.Add(deck[RandomCard]);

            deck.Remove(deck[RandomCard]);
        }

        // The computer player is dealt 1 card at random from the deck.
        public static void DealComputer(Computer computer)
        {
            int RandomCard = rand.Next(deck.Count);
            computer.hand.Add(deck[RandomCard]);

            deck.Remove(deck[RandomCard]);
        }
    }
}
