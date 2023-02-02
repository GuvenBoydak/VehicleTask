using FluentValidation;
using VehicleTask.Application.Features.Command.Buses.UpdateBus;

namespace VehicleTask.Application.Validations.Buses;

public class UpdateBusCommandValidator : AbstractValidator<UpdateBusCommand>
{
    public UpdateBusCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id Field must not be empty.");
    }
}