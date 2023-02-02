using FluentValidation;
using VehicleTask.Application.Features.Command.Buses.CreateBus;

namespace VehicleTask.Application.Validations.Buses;

public class CreateBusCommandValidator : AbstractValidator<CreateBusCommand>
{
    public CreateBusCommandValidator()
    {
        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand Field must not be empty.")
            .MaximumLength(50).WithMessage("Brand must be a maximum of 50 characters.");
        RuleFor(x => x.Wheel)
            .NotEmpty().WithMessage("Wheel Field must not be empty.")
            .GreaterThan(0).WithMessage("Entered Wheel must be greater than zero");
        RuleFor(x => x.SeatCapacity)
            .NotEmpty().WithMessage("SeatCapacity Field must not be empty.")
            .GreaterThan(0).WithMessage("Entered SeatCapacity must be greater than zero");
    }
}