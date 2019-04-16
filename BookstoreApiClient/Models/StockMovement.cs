using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreApiClient.Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
