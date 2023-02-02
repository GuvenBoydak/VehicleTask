using FluentValidation;
using VehicleTask.Application.Features.Command.Boats.CreateBoat;

namespace VehicleTask.Application.Validations.Boats;

public class CreateBoatCommandValidator : AbstractValidator<CreateBoatCommand>
{
    public CreateBoatCommandValidator()
    {
        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand Field must not be empty.")
            .MaximumLength(50).WithMessage("Brand must be a maximum of 50 characters.");
        RuleFor(x => x.SeatCapacity)
            .NotEmpty().WithMessage("SeatCapacity Field must not be empty.")
            .GreaterThan(0).WithMessage("Entered SeatCapacity must be greater than zero");
    }
}