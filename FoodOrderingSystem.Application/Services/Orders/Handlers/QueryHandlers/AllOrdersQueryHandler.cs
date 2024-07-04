using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.Orders.Query;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.Orders.Handlers.QueryHandlers;

internal class AllOrdersQueryHandler(IOrdersMongoDbContext ordersMongo) : IQueryHandler<AllOrdersQuery,
    IList<FoodOrderingSystem.Core.Entities.Order>>
{
    private readonly IOrdersMongoDbContext _ordersMongo = ordersMongo;
    public async Task<Result<IList<Order>>> Handle(AllOrdersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null)
            {
                throw new FoodOrderException(nameof(request));
            }

            List<Order> lists = await _ordersMongo.Orders
                .Find(_ => true)
                .ToListAsync();

            if (lists == null)
            {
                throw new FoodOrderException(nameof (lists));
            }

            return Result<IList<Order>>.Success(lists);
        }
        catch (FoodOrderException)
        {
            return Result<IList<Order>>.Failure(ErrorType.None);
        }
    }
}
