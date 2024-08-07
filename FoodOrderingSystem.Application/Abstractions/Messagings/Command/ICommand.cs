﻿using FoodOrderingSystem.Application.Shared;
using MediatR;

namespace FoodOrderingSystem.Application.Abstractions.Messagings.Command;

public interface ICommand : IRequest<Result>
{
}


public interface ICommand<T> : IRequest<Result<T>>
    where T : class
{
}



