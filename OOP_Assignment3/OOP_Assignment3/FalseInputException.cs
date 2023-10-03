using System;
namespace OOP_Assignment3
{
    // User-defined Exception to be used whenever an input is required
    public class FalseInputException : Exception
    {
        public FalseInputException(string message) : base(message)
        {

        }
    }
}
