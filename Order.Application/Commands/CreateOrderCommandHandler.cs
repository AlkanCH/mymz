using MediatR;
using Order.Domain.Entities;
using Order.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Przykład: ustalamy cenę jednostkową przykładowo jako 100.0 dla każdego produktu
            var orderItems = request.Items
                .Select(item => (ProductId: item.ProductId, unitPrice: 100.0m, item.Quantity))
                .ToList();

            // Tworzymy nowe zamówienie
            var order = new Order.Domain.Entities.Order(request.UserId, orderItems);

            // Dodajemy zamówienie do repozytorium
            await _orderRepository.AddAsync(order, cancellationToken);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            // Zwracamy identyfikator utworzonego zamówienia
            return order.Id;
        }
    }
}
