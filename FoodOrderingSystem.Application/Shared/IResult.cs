﻿namespace FoodOrderingSystem.Application.Shared;

public interface IResult
{
    bool IsSuccess { get; set; }
    string Message { get; set; }
}
