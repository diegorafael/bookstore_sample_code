using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class OversellingStockException : Exception
    {
        public int Oversell { get; }
        public override string Message => $"Can not oversell stock in {Oversell} units";
        public OversellingStockException(int oversell)
        {
            Oversell = oversell;
        }
    }
}
