using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Persistence.Abstractions.Interfaces;

public interface IBaseService<TIn> where TIn : class
{
    Task<IResult> AddAsync(TIn inputValue, CancellationToken cancellationToken);
    Task<IResult> GetAllAsync(CancellationToken cancellationToken);
    Task<IResult> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IResult> UpdateAsync(string id, TIn inputValue, CancellationToken cancellationToken);
}
