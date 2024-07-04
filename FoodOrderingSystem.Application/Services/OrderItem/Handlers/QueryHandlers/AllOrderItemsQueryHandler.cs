using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.OrderItem.Query;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.QueryHandlers;

public sealed class AllOrderItemsQueryHandler(IOrderItemMongoDbContext orderItem,
    IMapper mapper) : IQueryHandler<AllOrderItemsQuery,
    IList<FoodOrderingSystem.Core.Entities.OrderItem>>
{
    private readonly IOrderItemMongoDbContext _orderItem = orderItem;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<IList<Core.Entities.OrderItem>>> Handle(AllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null)
            {
                throw new FoodOrderException(nameof(request));
            }

            List<Core.Entities.OrderItem> lists = await _orderItem
                .OrderItems
                .Find(_ => true)
                .ToListAsync();

            if (lists == null)
            {
                throw new FoodOrderException($"{nameof(lists)}");
            }

            return Result<IList<Core.Entities.OrderItem>>.Success(lists);
        }
        catch (FoodOrderException)
        {
            return Result<IList<Core.Entities.OrderItem>>.Failure(ErrorType.BadRequest);
        }
    }
}
