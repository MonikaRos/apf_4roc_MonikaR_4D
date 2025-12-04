using System;

namespace UserApp.DataLayer.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
