using FluentValidation;
using VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;

namespace VehicleTask.Application.Validations.Buses;

public class HeadlightsOnOrOffByBusIdCommandValidator : AbstractValidator<HeadlightsOnOrOffByBusIdCommand>
{
    public HeadlightsOnOrOffByBusIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id Field must not be empty.");
        RuleFor(x => x.IsHeadlightOn)
            .NotEmpty().WithMessage("IsHeadlightOn Field must not be empty.");
    }
}