using MediatR;
using System;
using System.Collections.Generic;

namespace Order.Application.Commands.CreateOrder
{
    // Rejestrujemy komendę, która przyjmie identyfikator użytkownika i listę pozycji zamówienia 
    // (dla uproszczenia zakładamy, że cena jednostkowa jest ustalana w handlerze)
    public record CreateOrderCommand(Guid UserId, List<CreateOrderItemDto> Items) : IRequest<Guid>;

    // DTO przekazywany jako element listy - zawiera identyfikator produktu oraz ilość
    public record CreateOrderItemDto(Guid ProductId, int Quantity);
}
