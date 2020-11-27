using FluentValidation;
using Service.Integration.Models;

namespace Service.Integration.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Address1).NotNull().NotEmpty().WithMessage("Address1 is required.");
            RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.State).NotNull().NotEmpty().WithMessage("State is required.");
            RuleFor(x => x.Country).NotNull().NotEmpty().WithMessage("Country is required.");
            RuleFor(x => x.PostalCode).NotNull().NotEmpty().WithMessage("Postal Code is required.");
        }
    }
}
