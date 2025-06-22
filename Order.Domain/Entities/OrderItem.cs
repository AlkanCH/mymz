using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        private OrderItem() { }             // dla EF Core
        public OrderItem(Guid orderId, Guid productId, decimal price, int qty)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = price;
            Quantity = qty;
        }
    }
}
