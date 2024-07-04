using MediatR;

namespace FoodOrderingSystem.Persistence.Services;

public abstract class BaseAbstractService(ISender sender)
{
    protected readonly ISender Sender = sender; 
}
