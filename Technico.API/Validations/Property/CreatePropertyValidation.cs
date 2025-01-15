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
                .MaximumLength(20).WithMessage("Property ID cannot exceed 20 digits.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(p => p.Type)
                .IsInEnum().WithMessage("Type of property must be 0 (Detached House), 1 (Maisonet) or 2 (Apartment Building).");

            RuleFor(p => p.OwnerId)
                .NotEmpty().WithMessage("Owner ID is required.");
        }
    }
}
