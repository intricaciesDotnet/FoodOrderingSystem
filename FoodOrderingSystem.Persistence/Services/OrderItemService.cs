using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.FoodItem.Command;
using FoodOrderingSystem.Application.Services.OrderItem.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using MediatR;

namespace FoodOrderingSystem.Persistence.Services;

public sealed class OrderItemService : BaseAbstractService, IOrderItemService
{
    public OrderItemService(ISender sender) : base(sender)
    {
    }

    public async Task<IResult> AddAsync(OrderItemDto inputValue, CancellationToken cancellationToken)
    {
        try
        {
            OrderItemDto validDto = inputValue ?? throw new ArgumentNullException(nameof(inputValue));

            CreateOrderItemCommand command = new CreateOrderItemCommand(inputValue);

            Result<OrderItem> orderItemResult = await Sender.Send(command, cancellationToken);

            return orderItemResult.IsSuccess ?
                orderItemResult :
                Result<OrderItem>.Failure(ErrorType.BadRequest);
        }
        catch (UserNotCreatedException ex)
        {
            return Result<OrderItem>.Failure(ErrorType.BadRequest);
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

    public Task<IResult> UpdateAsync(string id, OrderItemDto inputValue, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
