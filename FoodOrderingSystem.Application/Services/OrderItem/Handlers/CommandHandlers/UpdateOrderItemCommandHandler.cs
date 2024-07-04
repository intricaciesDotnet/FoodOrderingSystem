using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.OrderItem.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.CommandHandlers;

public sealed class UpdateOrderItemCommandHandler(IOrderItemMongoDbContext orderItem,
	IMapper mapper) : ICommandHandler<UpdateOrderItemCommand,
    FoodOrderingSystem.Core.Entities.OrderItem>
{

	private readonly IOrderItemMongoDbContext _orderItem = orderItem;
	private readonly IMapper _mapper = mapper;
    public async Task<Result<Core.Entities.OrderItem>> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
		try
		{
			if (request == null && string.IsNullOrEmpty(request?.Id))
			{
				throw new FoodOrderException(nameof(request));
			}

            Core.Entities.OrderItem mapped = _mapper.Map<Core.Entities.OrderItem>(request.OrderItemDto);

            FilterDefinitionBuilder<Core.Entities.OrderItem> filter = new();

            ReplaceOneResult result = await _orderItem
                .OrderItems
                .ReplaceOneAsync(filter.Where(x => x.Id == request.Id), mapped);

			if (result == null)
			{
				throw new FoodOrderException(nameof (result));
			}

            Core.Entities.OrderItem updatedOrderItem = await _orderItem
				.OrderItems
				.Find(x => x.Id.Equals(request.Id))
				.FirstOrDefaultAsync();

			if (updatedOrderItem == null)
			{
				throw new FoodOrderException(nameof (updatedOrderItem));
			}

			return Result<Core.Entities.OrderItem>.Success(updatedOrderItem);

        }
		catch (FoodOrderException)
		{

			return Result<Core.Entities.OrderItem>.Failure(ErrorType.InvalidId);
		}
    }
}
