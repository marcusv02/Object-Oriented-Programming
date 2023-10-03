using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Assignment3
{
    // Also inherits from 'Player' and then also 'Hand'.
    public class Computer : Player
    {
        // The same fields and lists as 'Human' are defined and declared here.
        public new List<Card> hand = new List<Card>();
        public List<Card> PlayCards = new List<Card>();
        public List<int> handvalues = new List<int>();
        public new int RoundScore;
        public new int Score = 0;
        public new int ID = 0;

        // In this version of the method, the computer plays 2 cards chosen from its hand at random.
        public override void Play()
        {
            Card Card1;
            Card Card2;
            var Random = new Random();

            int Card1Index = Random.Next(hand.Count);
            Card1 = hand[Card1Index];
            PlayCards.Add(Card1);
            hand.Remove(Card1);

            int Card2Index = Random.Next(hand.Count);
            Card2 = hand[Card2Index];
            PlayCards.Add(Card2);
            hand.Remove(Card2);


            Console.WriteLine("\nThe Computer plays:");
            foreach(Card i in PlayCards)
            {
                Console.WriteLine("The " + i.face + " of " + i.suit);
            }
            Console.WriteLine();

            RoundScore = Card1.value + Card2.value;

            PlayCards.Remove(Card1);
            PlayCards.Remove(Card2);
        }

        // Displays the random card in the computer's list called 'hand' that was drawn when finishing round 5 on a tie (when
        // the scores are equal).
        public override void PlayOne()
        {
            Card Card1 = hand[0];
            PlayCards.Add(Card1);
            hand.Remove(Card1);

            Console.WriteLine("\nThe computer took a random card from the deck to play.");
            Console.WriteLine("The computer played:\nThe " + Card1.face + " of " + Card1.suit);
            Console.WriteLine();

            RoundScore = Card1.value;

            PlayCards.Remove(Card1);
        }
    }
}
