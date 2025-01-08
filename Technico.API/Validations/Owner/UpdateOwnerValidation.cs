using FluentValidation;

namespace Technico.API.Validations.Owner
{
    public class UpdateOwnerValidation : AbstractValidator<UpdateOwnerDto>
    {
        public UpdateOwnerValidation()
        {
            RuleFor(x => x.VatNumber)
                .NotEmpty().WithMessage("VAT Number is required.")
                .Matches("^[0-9]+$").WithMessage("VAT Number must contain only digits.")
                .MaximumLength(15).WithMessage("VAT Number cannot exceed 15 digits.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d+$").WithMessage("Phone number must contain only numbers and optional '+' prefix.")
                .MaximumLength(20).WithMessage("Phone Number cannot exceed 20 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
