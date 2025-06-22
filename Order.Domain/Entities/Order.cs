using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public enum OrderStatus { Pending, Confirmed, Cancelled }

    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public OrderStatus Status { get; private set; }
        public decimal TotalAmount => _items.Sum(i => i.UnitPrice * i.Quantity);

        private Order() { }                // dla EF Core
        public Order(Guid userId, IEnumerable<(Guid productId, decimal price, int qty)> items)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            foreach (var (p, price, qty) in items)
                AddItem(p, price, qty);
            Status = OrderStatus.Pending;
        }

        public void AddItem(Guid productId, decimal unitPrice, int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be > 0");
            _items.Add(new OrderItem(Id, productId, unitPrice, quantity));
        }

        public void Confirm() => Status = OrderStatus.Confirmed;
        public void Cancel() => Status = OrderStatus.Cancelled;
    }
}
