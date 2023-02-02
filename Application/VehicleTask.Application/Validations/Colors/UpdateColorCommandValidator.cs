using FluentValidation;
using VehicleTask.Application.Features.Command.Color.UpdateColor;

namespace VehicleTask.Application.Validations.Colors;

public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
{
    public UpdateColorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id Field must not be empty.");
    }
}