using System;
using System.Collections.Generic;

namespace OOP_Assignment3
{
    // A child class to the 'Player' class
    public class Human : Player
    {
        // Human player contains its own new 'hand' list (from the 'Hand' class), as well a list called 'PlayCards' which
        // will hold the 2 cards the human player will play, and the fields from the 'Player' class.
        public new List<Card> hand = new List<Card>();
        public List<Card> PlayCards = new List<Card>();
        public new int RoundScore;
        public new int Score = 0;
        public new int ID = 1;
        

        // Displays the cards the player can play.
        protected override void Display()
        {
            int p = 1;
            Console.WriteLine("\nHere are the cards in your hand:");
            foreach(Card i in hand)
            {
                Console.WriteLine("{0}: The " + i.face + " of " + i.suit, p);
                p++;
            }
            Console.WriteLine();
        }

        // asks user for 2 cards to play from their hand. These cards are then added to the 'PlayCards' list and removed from the hand.
        // The console then shows which cards the user chose and adds the total card value. The cards are then removed from the
        // 'PlayCards' list
        public override void Play()
        {
            Display();

            Console.WriteLine("Which 2 cards would you like to play?");
            Console.WriteLine("Enter the first card's order number, hit enter, then the second card's order number:");

            // Exceptions thrown here to be caught in main.
            int input1 = Convert.ToInt32(Console.ReadLine());
            if (input1 < 1 || input1 > hand.Count)
            {
                throw new FalseInputException("\nInput must be within the given range!");
            }
            
            int input2 = Convert.ToInt32(Console.ReadLine());
            if (input2 < 1 || input2 > hand.Count)
            {
                throw new FalseInputException("\nInput must be within the given range!");
            }

            if (input1 == input2)
            {
                throw new FalseInputException("\nPlease choose two different cards!");
            }

            Card Card1 = hand[input1 - 1];
            Card Card2 = hand[input2 - 1];

            PlayCards.Add(Card1);
            PlayCards.Add(Card2);

            hand.Remove(Card1);
            hand.Remove(Card2);

            Console.WriteLine("\nYou've played:");
            foreach (Card i in PlayCards)
            {
                Console.WriteLine("The " + i.face + " of " + i.suit);
            }
            Console.WriteLine();

            RoundScore = Card1.value + Card2.value;

            PlayCards.Remove(Card1);
            PlayCards.Remove(Card2);
        }

        // The random card that is drawn to the human player is then played.
        public override void PlayOne()
        {
            Card Card1 = hand[0];
            PlayCards.Add(Card1);
            hand.Remove(Card1);

            Console.WriteLine("\nYou took a random card from the deck to play.");
            Console.WriteLine("You've played:\nThe " + Card1.face + " of " + Card1.suit);
            Console.WriteLine();

            RoundScore = Card1.value;

            PlayCards.Remove(Card1);
        }
    }
}
