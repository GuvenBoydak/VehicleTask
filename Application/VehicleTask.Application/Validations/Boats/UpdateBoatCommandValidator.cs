using FluentValidation;
using VehicleTask.Application.Features.Command.Boats.UpdateBoat;

namespace VehicleTask.Application.Validations.Boats;

public class UpdateBoatCommandValidator : AbstractValidator<UpdateBoatCommand>
{
    public UpdateBoatCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id Field must not be empty.");
    }
}