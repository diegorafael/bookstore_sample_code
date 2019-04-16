using System;

namespace Domain.DTO
{
    public class BookStockMovement
    {
        public int BookId { get; set; }
        public int IncommingUnits { get; set; }
        public DateTime IncommingDate { get; set; }
        public DateTime RegisterDate { get; }

        public BookStockMovement()
        {
            RegisterDate = DateTime.Now;
        }
    }
}
