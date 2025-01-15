using FluentValidation;
using Technico.Core.DTOs.Owner;

namespace Technico.API.Validations.Owner
{
    public class UpdateOwnerValidation : AbstractValidator<UpdateOwnerDto>
    {
        public UpdateOwnerValidation()
        {
            RuleFor(o => o.VatNumber)
                .NotEmpty().WithMessage("VAT Number is required.")
                .Matches("^[0-9]+$").WithMessage("VAT Number must contain only digits.")
                .MaximumLength(15).WithMessage("VAT Number cannot exceed 15 digits.");

            RuleFor(o => o.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(o => o.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(o => o.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(o => o.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d+$").WithMessage("Phone number must contain only numbers and optional '+' prefix.")
                .MaximumLength(20).WithMessage("Phone Number cannot exceed 20 characters.");

            RuleFor(o => o.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(o => o.Type)
                .IsInEnum().WithMessage("Type of user must be 0 (Admin) or 1 (Owner).");
        }
    }
}
