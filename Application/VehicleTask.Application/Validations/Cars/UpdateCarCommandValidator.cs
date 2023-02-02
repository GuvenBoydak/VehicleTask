using FluentValidation;
using VehicleTask.Application.Features.Command.Car.UpdateCar;

namespace VehicleTask.Application.Validations.Cars;

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id Field must not be empty.");
    }
}