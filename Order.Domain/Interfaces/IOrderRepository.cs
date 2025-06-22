using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain.Entities;


namespace Order.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order.Domain.Entities.Order order, CancellationToken ct = default); // Fully qualify 'Order' to avoid ambiguity  
        Task<Order.Domain.Entities.Order?> GetByIdAsync(Guid id, CancellationToken ct = default); // Fully qualify 'Order' to avoid ambiguity  
        IUnitOfWork UnitOfWork { get; }
    }
}
