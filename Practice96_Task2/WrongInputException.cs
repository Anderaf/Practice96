using System;
using System.Collections.Generic;
using System.Text;

namespace Practice96_Task2
{
    internal class WrongInputException : Exception
    {
        public WrongInputException()
        {}
        public WrongInputException(string message) : base(message)
        {}
    }
}
