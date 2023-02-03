using FluentValidation;
using VehicleTask.Application.Features.Command.Car.HeadlightsOnOrOffByCarId;

namespace VehicleTask.Application.Validations.Cars;

public class HeadlightsOnOrOffByCarIdCommandValidator : AbstractValidator<HeadlightsOnOrOffByCarIdCommand>
{
    public HeadlightsOnOrOffByCarIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id Field must not be empty.");
    }
}