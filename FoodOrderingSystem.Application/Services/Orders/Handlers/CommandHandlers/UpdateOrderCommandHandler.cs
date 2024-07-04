using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.Orders.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.Orders.Handlers.CommandHandlers;

public sealed class UpdateOrderCommandHandler(IOrdersMongoDbContext ordersMongo, 
    IMapper mapper) : ICommandHandler<UpdateOrderCommand,
    FoodOrderingSystem.Core.Entities.Order>

{

    private readonly IOrdersMongoDbContext _ordersMongo = ordersMongo;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<Order>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null && string.IsNullOrEmpty(request?.Id))
            {
                throw new FoodOrderException(nameof(request));
            }

            Order mapped = _mapper.Map<Order>(request);

            FilterDefinitionBuilder<Order> filter = new();
            ReplaceOneResult updated = await _ordersMongo.Orders
                .ReplaceOneAsync(filter
                .Where(x => x.Id == request.Id), mapped);

            if (updated == null) 
            {
                throw new FoodOrderException(nameof (updated));
            }

            Order getById = await _ordersMongo.Orders
                .Find(x => x.Id.Equals(request.Id))
                .FirstOrDefaultAsync();

            if (getById == null)
            {
                throw new FoodOrderException(nameof(getById));
            }

            return Result<Order>.Success(getById);
        }
        catch (FoodOrderException)
        {
            return Result<Order>.Failure(ErrorType.InvalidId);
        }
    }
}
