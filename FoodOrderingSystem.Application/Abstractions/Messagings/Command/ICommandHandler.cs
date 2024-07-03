using FoodOrderingSystem.Application.Shared;
using MediatR;

namespace FoodOrderingSystem.Application.Abstractions.Messagings.Command;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}


public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
     where TCommand : ICommand<TResponse>
    where TResponse : class

{
}





