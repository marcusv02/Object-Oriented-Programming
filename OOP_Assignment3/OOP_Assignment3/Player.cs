using System;
using System.Collections.Generic;

namespace OOP_Assignment3
{
    // Class 'Player' inherits from class 'Hand'
    public class Player : Hand
    {
        // Fields are declared for the classes that will inherit from this one.
        public int RoundScore;
        public int Score;
        public int ID;


        // These methods will all be overriden in the children classes.
        public virtual void Play()
        {

        }

        public virtual void PlayOne()
        {

        }

        protected virtual void Display()
        {

        }
    }
}
