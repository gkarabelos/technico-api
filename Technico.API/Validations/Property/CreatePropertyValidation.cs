using FluentValidation;
using Technico.Core.DTOs.Property;

namespace Technico.API.Validations.Property
{
    public class CreatePropertyValidation : AbstractValidator<CreatePropertyDto>
    {
        public CreatePropertyValidation()
        {
            RuleFor(p => p.E9)
                .NotEmpty().WithMessage("Property ID is required.")
                .Matches("^[0-9]+$").WithMessage("Property ID must contain only digits.")
                .MaximumLength(20).WithMessage("Property ID cannot exceed 20 digits.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(p => p.OwnerId)
                .NotEmpty().WithMessage("Owner ID is required.");
        }
    }
}
