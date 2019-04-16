using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class EmptyStockException : Exception
    {
        public override string Message => "The stock is empty";
    }
}
