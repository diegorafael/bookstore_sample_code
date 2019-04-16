using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Views
{
    public class StockMovement
    {
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }

        internal BookStockMovement ToBookStockMovement(int bookId)
        {
            return new BookStockMovement
            {
                BookId = bookId,
                IncommingDate = this.MovementDate,
                IncommingUnits = this.Quantity
            };
        }
    }
}
