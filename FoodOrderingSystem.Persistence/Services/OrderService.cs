using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.OrderItem.Command;
using FoodOrderingSystem.Application.Services.Orders.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using MediatR;

namespace FoodOrderingSystem.Persistence.Services;

public sealed class OrderService : BaseAbstractService, IOrderService
{
    public OrderService(ISender sender) : base(sender)
    {
    }

    public async Task<IResult> AddAsync(OrderDto inputValue, CancellationToken cancellationToken)
    {
        try
        {
            OrderDto validDto = inputValue ?? throw new ArgumentNullException(nameof(inputValue));

            CreateOrderCommand command = new CreateOrderCommand(inputValue);

            Result<Order> orderResult = await Sender.Send(command, cancellationToken);

            return orderResult.IsSuccess ?
                orderResult :
                Result<Order>.Failure(ErrorType.BadRequest);
        }
        catch (UserNotCreatedException ex)
        {
            return Result<Order>.Failure(ErrorType.BadRequest);
        }
    }

    public Task<IResult> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateAsync(string id, OrderDto inputValue, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
