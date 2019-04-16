using System;

namespace Domain.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public decimal Price { get; }
        public override string Message => $"'{Price.ToString("N2")}' is invalid as a price";

        public InvalidPriceException(decimal price)
        {
            Price = price;
        }
    }
}
