using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 52 unique cards are created by iterating through the lists (13 times for each 'face' and 'value'
            // for each suit). These are added to the 'deck' list in the 'Deck' class. 
            List<string> SuitList = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades"};
            List<string> FaceList = new List<string> { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Jack", "Queen", "King", "Ace"};
            List<int> ValueList = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    Card card = new Card();
                    card.suit = SuitList[i];
                    card.face = FaceList[j];
                    card.value = ValueList[j];

                    Deck.deck.Add(card);
                }
            }

            // Important variables to determine the play of the game are set, as well as instantiating the 'Human'
            // and 'Computer' classes to create the two players.
            int HandsToWin = 0;
            int Playing = 1;
            int NumofGamesPlayed = 0;
            Human Human1 = new Human();
            Computer Computer1 = new Computer();


            // Shuffles the deck, deals 10 cards to each player, (re)sets their scores and order IDs and begins the rounds.
            void Game()
            {
                Deck.deck.Shuffle();
                Console.WriteLine("\nThe deck has been shuffled.");
                Deck.DealHuman(Human1, 10);
                Console.WriteLine("You are dealt 10 cards...");
                Deck.DealComputer(Computer1, 10);
                Console.WriteLine("... and so is the computer.\nLet the game begin!");
                Console.WriteLine();
                Human1.Score = 0;
                Computer1.Score = 0;
                Human1.ID = 1;
                Computer1.ID = 0;
                FiveRounds();
            }

            // Iterates 5 times to allow 5 rounds to be played. 'If' statements allow for the person who won the last round
            // to play first, or whoever has the higher score if it's a tie.
            void FiveRounds()
            {
                for (int Round = 1; Round <= 5; Round ++)
                {
                    if (Human1.ID == 1)
                    {
                        HumanFirst(Human1, Computer1);
                    }
                    else if (Computer1.ID == 1)
                    {
                        Computer1.Play();
                        ComputerFirst(Computer1, Human1);
                    }
                    else if (Human1.ID == 0 && Computer1.ID == 0)
                    {
                        if (Human1.Score > Computer1.Score)
                        {
                            HumanFirst(Human1, Computer1);
                        }
                        else if (Computer1.Score > Human1.Score)
                        {
                            Computer1.Play();
                            ComputerFirst(Computer1, Human1);
                        }
                        else
                        {
                            HumanFirst(Human1, Computer1);
                        }
                    }
                }
                // The scores are printed and calls the function to asks to play again.
                Console.WriteLine("After 5 rounds, here are the scores.");
                Console.WriteLine("You: {0} \nComputer: {1}", Human1.Score, Computer1.Score);
                Console.WriteLine();

                NumofGamesPlayed++;

                AfterFiveRounds(Human1, Computer1);
            }

            // Called when the human player plays their cards first. It handles exceptions for when the inputs are incorrect,
            // prints a message telling them so, and recalls the method to try again.
            void HumanFirst(Human human, Computer computer)
            {
                try
                {
                    human.Play();
                    computer.Play();
                    Compare(human, computer);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease enter a number!");
                    HumanFirst(Human1, Computer1);
                }
                catch (FalseInputException e)   // Custom exeption, 'FalseInputException'.
                {
                    Console.WriteLine(e.Message);
                    HumanFirst(Human1, Computer1);
                }
            }

            // Has the same functionality as the method above, but allows the computer to play first instead.
            void ComputerFirst(Computer computer, Human human)
            {
                try
                {
                    human.Play();
                    Compare(human, computer);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease enter a number!");
                    ComputerFirst(Computer1, Human1);
                }
                catch (FalseInputException e)
                {
                    Console.WriteLine(e.Message);
                    ComputerFirst(Computer1, Human1);
                }
            }

            // The values of each player's cards are compared. The winner's score increases by the number of sets of cards won
            // (typically 2, but 4 unless cards are won after a tie).
            void Compare(Human human, Computer computer)
            {
                if (human.RoundScore > computer.RoundScore)
                {
                    Console.WriteLine("This round's winner: You");
                    Console.WriteLine();
                    HandsToWin += 2;
                    human.Score += HandsToWin;

                    HandsToWin = 0;
                    human.RoundScore = 0;
                    computer.RoundScore = 0;

                    human.ID = 1;
                    computer.ID = 0;
                }
                else if (human.RoundScore < computer.RoundScore)
                {
                    Console.WriteLine("This round's winner: Computer");
                    Console.WriteLine();
                    HandsToWin += 2;
                    computer.Score += HandsToWin;

                    HandsToWin = 0;
                    human.RoundScore = 0;
                    computer.RoundScore = 0;

                    human.ID = 0;
                    computer.ID = 1;
                }
                else if (human.RoundScore == computer.RoundScore)
                {
                    Console.WriteLine("This round is a tie!");
                    Console.WriteLine();
                    HandsToWin += 2;

                    human.RoundScore = 0;
                    computer.RoundScore = 0;

                    human.ID = 0;
                    computer.ID = 0;
                }
            }

            // This method is called after the 5 rounds (all cards in players' hand have been played). If the fifth round ended in
            // a tie and their scores are the same, one card is taken by random from the dack and dealt the each player. Whhoever's
            // card has a higher value wins.
            void AfterFiveRounds(Human human, Computer computer)
            {
                while ((human.ID == 0 && computer.ID == 0) && (human.Score == computer.Score))
                {
                    Deck.DealHuman(Human1);
                    Deck.DealComputer(Computer1);

                    human.PlayOne();
                    computer.PlayOne();
                    Compare(Human1, Computer1);
                }

                if (human.Score > computer.Score)
                {
                    Console.WriteLine("Congratulations! You win!");
                    Console.WriteLine();
                    PlayAgain_Question();
                }
                else if (human.Score < computer.Score)
                {
                    Console.WriteLine("Oh dear... the computer has won.");
                    Console.WriteLine();
                    PlayAgain_Question();
                }
            }

            // The player is then asked if they want to play again. If the inputs are incorrect, necessary exception
            // handling takes care if them. Although, when this method is called after a second game, the player is told
            // there are no more cards to play, and ends the game.
            void PlayAgain_Question()
            {
                try
                {
                    if (NumofGamesPlayed < 2)
                    {
                        Console.WriteLine("\nWould you like 10 more cards be dealt to each player and play again?");
                        Console.WriteLine("Either type '1' for yes, or '2' for no:");
                        Playing = Int32.Parse(Console.ReadLine());

                        if (Playing == 1)
                        {
                            Game();
                        }
                        else if (Playing == 2)
                        {
                            End();
                        }
                        else if (Playing < 1 || Playing > 2)
                        {
                            throw new FalseInputException("\nPlease either enter '1' or '2'!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThere are not enough cards in the deck to play again");
                        End();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease either enter '1' or '2'!");
                    PlayAgain_Question();
                }
                catch (FalseInputException e)
                {
                    Console.WriteLine(e.Message);
                    PlayAgain_Question();
                }
            }

            // The game ends and the user is thanked for playing, which is nice!
            void End()
            {
                Console.WriteLine("\nThank you very much for playing!");
            }



            // This message greets the player telling them the rules of the game.
            Console.WriteLine("Welcome to the card game 'Lincoln'! You and a computer player will be" +
                " dealt ten cards each, and choose two cards to play each round. Whoever plays\nthe cards with " +
                "the highest total value wins the round and plays first next round. After you have played all of " +
                "your cards, the winner is decided\nby who has the highest number of rounds won. If both of you " +
                "have won the same number of rounds (i.e. a tie on round 5 with two wins each) then you\nwill take " +
                "one card each from the deck and compare until a winner is decided. By the way, the Ace has the highest value!");

            // The whole game playes as long as the game isn't being played more than twice, and the player chooses to play
            // again when asked.
            while (Playing == 1 && NumofGamesPlayed < 2)
            {
                Game();
            }
        }
    }
}
