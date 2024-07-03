using FoodOrderingSystem.Application.Shared;
using MediatR;

namespace FoodOrderingSystem.Application.Abstractions.Messagings.Query;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TInput> : IRequest<Result<TInput>>
    where TInput : class
{
}
