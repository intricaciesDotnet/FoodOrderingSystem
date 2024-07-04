using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.Orders.Query;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.Orders.Handlers.QueryHandlers;

internal class GetOrdersByIdQueryHandler(IOrdersMongoDbContext ordersMongo,
    IMapper mapper) : IQueryHandler<GetOrderByIdQuery,
    FoodOrderingSystem.Core.Entities.Order>
{
    private readonly IOrdersMongoDbContext _ordersMongo = ordersMongo;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<Order>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null && string.IsNullOrEmpty(request?.Id))
            {
                throw new FoodOrderException(nameof(request));
            }

            Order byIdOrderItem = await _ordersMongo
                .Orders
                .Find(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (byIdOrderItem == null)
            {
                throw new FoodOrderException(nameof(byIdOrderItem));
            }

            return Result<Core.Entities.Order>.Success(byIdOrderItem);
        }
        catch (FoodOrderException)
        {
            return Result<Order>.Failure(ErrorType.InvalidId);
        }
    }
}
