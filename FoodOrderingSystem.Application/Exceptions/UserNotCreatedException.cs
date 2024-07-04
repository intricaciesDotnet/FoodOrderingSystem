namespace FoodOrderingSystem.Application.Exceptions;

public class UserNotCreatedException : Exception
{
    public UserNotCreatedException(string message) : base(message)
    {

    }
}

public class FoodOrderException : Exception
{
    public FoodOrderException(string? message) : base(message)
    {
    }
}

