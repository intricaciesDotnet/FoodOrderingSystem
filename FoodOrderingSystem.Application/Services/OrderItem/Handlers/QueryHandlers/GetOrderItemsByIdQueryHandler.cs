using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.OrderItem.Query;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.QueryHandlers;

public sealed class GetOrderItemsByIdQueryHandler(IOrderItemMongoDbContext orderItem, 
    IMapper mapper) : IQueryHandler<GetOrderItemByIdQuery,
    FoodOrderingSystem.Core.Entities.OrderItem>
{
    private readonly IOrderItemMongoDbContext _orderItem = orderItem;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<Core.Entities.OrderItem>> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null && string.IsNullOrEmpty(request?.Id))
            {
                throw new FoodOrderException(nameof(request));
            }

            Core.Entities.OrderItem byIdOrderItem = await _orderItem
                .OrderItems
                .Find(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (byIdOrderItem == null)
            {
                throw new FoodOrderException(nameof(byIdOrderItem));
            }

            return Result<Core.Entities.OrderItem>.Success(byIdOrderItem);
        }
        catch (FoodOrderException)
        {
            return Result<Core.Entities.OrderItem>.Failure(ErrorType.InvalidId);
        }
    }
}
