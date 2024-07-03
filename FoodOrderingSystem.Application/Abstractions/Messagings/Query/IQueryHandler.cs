using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Shared;
using MediatR;

namespace FoodOrderingSystem.Application.Abstractions.Messagings.Query;



public interface IQueryHandler<ICommand> : IRequestHandler<IQuery, Result>
    where ICommand : IQuery
{
}


public interface IQueryHandler<IQuery, TResponse> : IRequestHandler<IQuery, Result<TResponse>>
     where IQuery : IQuery<TResponse>
    where TResponse : class

{
}


