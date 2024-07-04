using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.OrderItem.Command;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.CommandHandlers;

public sealed class CreateOrderItemCommandHandler(IOrderItemMongoDbContext orderItem, 
	IMapper mapper) : ICommandHandler<CreateOrderItemCommand,
    FoodOrderingSystem.Core.Entities.OrderItem>
{

    private readonly IOrderItemMongoDbContext _orderItem = orderItem;
	private readonly IMapper _mapper = mapper;
    public async Task<Result<Core.Entities.OrderItem>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
		try
		{
            if (request == null)
			{
				throw new FoodOrderException(nameof(request));
			}

            Core.Entities.OrderItem mapped = _mapper.Map<Core.Entities.OrderItem>(request.OrderItemDto);

			await _orderItem.OrderItems.InsertOneAsync(mapped);

            Core.Entities.OrderItem user = await _orderItem
				.OrderItems
				.Find(x => x.Id == mapped.Id)
                .FirstOrDefaultAsync();

			if (user == null)
			{
				throw new FoodOrderException(nameof(user));
			}

			return Result<Core.Entities.OrderItem>.Success(user);

		}
		catch (FoodOrderException)
		{
			return Result<Core.Entities.OrderItem>.Failure(ErrorType.UnableToCreate);
		}
    }
}
