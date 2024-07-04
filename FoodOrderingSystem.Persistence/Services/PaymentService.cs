using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.Orders.Command;
using FoodOrderingSystem.Application.Services.Payment.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using MediatR;

namespace FoodOrderingSystem.Persistence.Services;

public sealed class PaymentService : BaseAbstractService, IPaymentService
{
    public PaymentService(ISender sender) : base(sender)
    {
    }

    public async Task<IResult> AddAsync(PaymentDto inputValue, CancellationToken cancellationToken)
    {
        try
        {
            PaymentDto validDto = inputValue ?? throw new ArgumentNullException(nameof(inputValue));

            CreatePaymentCommand command = new CreatePaymentCommand(inputValue);

            Result<Payment> paymentResult = await Sender.Send(command, cancellationToken);

            return paymentResult.IsSuccess ?
                paymentResult :
                Result<Payment>.Failure(ErrorType.BadRequest);
        }
        catch (UserNotCreatedException ex)
        {
            return Result<Payment>.Failure(ErrorType.BadRequest);
        }
    }

    public Task<IResult> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateAsync(string id, PaymentDto inputValue, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
