using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime PublishingDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual int StockQuantity { get; internal set; }
        public virtual decimal Price { get; internal set; }

        internal void IncreaseStock(int incommingUnits)
        {
            StockQuantity += incommingUnits;
        }
        internal void DecreaseStock(int outcommingUnits)
        {
            if (StockQuantity == 0)
                throw new EmptyStockException();

            var remainingUnits = StockQuantity - outcommingUnits;
            if (remainingUnits < 0)
                throw new OversellingStockException(remainingUnits);

            StockQuantity -= outcommingUnits;
        }
    }
}
