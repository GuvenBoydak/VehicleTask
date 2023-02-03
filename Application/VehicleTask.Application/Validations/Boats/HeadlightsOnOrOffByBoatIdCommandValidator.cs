using FluentValidation;
using VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;

namespace VehicleTask.Application.Validations.Boats;

public class HeadlightsOnOrOffByBoatIdCommandValidator : AbstractValidator<HeadlightsOnOrOffByBoatIdCommand>
{
    public HeadlightsOnOrOffByBoatIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id Field must not be empty.");
    }
}