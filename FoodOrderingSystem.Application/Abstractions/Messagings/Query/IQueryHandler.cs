using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Shared;
using MediatR;

namespace FoodOrderingSystem.Application.Abstractions.Messagings.Query;

public interface IQueryHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}


public interface IQueryHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
     where TCommand : ICommand<TResponse>
    where TResponse : class

{
}


