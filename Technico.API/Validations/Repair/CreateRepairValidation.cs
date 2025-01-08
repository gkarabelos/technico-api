using FluentValidation;
using Technico.Core.DTOs.Repair;

namespace Technico.API.Validations.Repair
{
    public class CreateRepairValidation : AbstractValidator<CreateRepairDto>
    {
        public CreateRepairValidation()
        {
            RuleFor(r => r.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(r => r.Type)
                .NotEmpty().WithMessage("Repair type is required.")
                .MaximumLength(50).WithMessage("Repair type cannot exceed 50 characters.");

            RuleFor(r => r.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(r => r.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Repair cost must be a positive value.")
                .PrecisionScale(10, 2, true).WithMessage("Repair cost must have up to 10 digits with 2 decimal places.");

            RuleFor(r => r.PropertyId)
                .NotEmpty().WithMessage("Property ID is required.");
        }
    }
}
