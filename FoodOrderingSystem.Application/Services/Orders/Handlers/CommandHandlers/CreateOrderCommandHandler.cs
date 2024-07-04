using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.Orders.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.Orders.Handlers.CommandHandlers;

internal class CreateOrderCommandHandler(IOrdersMongoDbContext ordersMongo,
    IMapper mapper) : ICommandHandler<CreateOrderCommand,
    FoodOrderingSystem.Core.Entities.Order>
{
    private readonly IOrdersMongoDbContext _ordersMongo = ordersMongo;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null)
            {
                throw new FoodOrderException(nameof(request));
            }

            Order mapped = _mapper.Map<Order>(request.OrderDto);

            await _ordersMongo.Orders.InsertOneAsync(mapped);

            Order newOrderCreated = await _ordersMongo.Orders
                .Find(x => x.Id == mapped.Id)
                .FirstOrDefaultAsync();

            if (newOrderCreated == null)
            {
                throw new FoodOrderException(nameof (newOrderCreated));
            }

            return Result<Order>.Success(newOrderCreated);

        }
        catch (FoodOrderException)
        {
            return Result<Order>.Failure(ErrorType.UnableToCreate);
        }
    }
}
