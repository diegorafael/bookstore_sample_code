using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        public override string Message => "Element not found";
    }
}
