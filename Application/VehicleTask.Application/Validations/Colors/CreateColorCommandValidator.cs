using FluentValidation;
using VehicleTask.Application.Features.Command.Color.CreateColor;

namespace VehicleTask.Application.Validations.Colors;

public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
{
    public CreateColorCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name Field must not be empty.")
            .MaximumLength(50).WithMessage("Name must be a maximum of 50 characters.");
    }
}