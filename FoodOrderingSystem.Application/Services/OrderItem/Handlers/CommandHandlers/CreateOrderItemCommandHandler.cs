using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.OrderItem.Command;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.CommandHandlers;

public sealed class CreateOrderItemCommandHandler(IOrderItemMongoDbContext orderItem) : ICommandHandler<CreateOrderItemCommand,
    FoodOrderingSystem.Core.Entities.OrderItem>
{

    private readonly IOrderItemMongoDbContext _orderItem = orderItem;
    public async Task<Result<Core.Entities.OrderItem>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
		try
		{
            if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			Core.Entities.OrderItem orderItem_ = new()
			{
				OrderId = request.OrderItemDto.OrderId,
				FoodItemId = request.OrderItemDto.FoodItemId,
				FoodName = request.OrderItemDto.FoodName,
				Quantity = request.OrderItemDto.Quantity,
				ItemPrice = request.OrderItemDto.ItemPrice,
			};

			await _orderItem.OrderItems.InsertOneAsync(orderItem_);


			return Result<Core.Entities.OrderItem>.Success(orderItem_);

		}
		catch (FoodOrderException)
		{

			return Result<Core.Entities.OrderItem>.Failure(ErrorType.UnableToCreate);
		}
    }
}
