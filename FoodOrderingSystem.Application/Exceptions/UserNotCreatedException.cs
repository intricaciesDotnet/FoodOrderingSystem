namespace FoodOrderingSystem.Application.Exceptions;

public class UserNotCreatedException : Exception
{
    public UserNotCreatedException(string message) : base(message)
    {
        
    }
}
