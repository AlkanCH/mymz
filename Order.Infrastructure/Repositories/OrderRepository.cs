using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Interfaces;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
          => _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(Order order, CancellationToken ct = default)
          => await _context.Orders.AddAsync(order, ct);

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default)
          => await _context.Orders
              .Include(o => o.Items)
              .FirstOrDefaultAsync(o => o.Id == id, ct);
    }
}
