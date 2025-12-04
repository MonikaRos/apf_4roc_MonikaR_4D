using System;
using System.Collections.Generic;

namespace UserApp.DataLayer.Entities
{
    public class OrderStatus : BaseEntity
    {
        public int OrderStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
