using FluentValidation;
using Service.Integration.Models;

namespace Service.Integration.Validators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerFirstName).NotNull().NotEmpty().WithMessage("Customer Name is required.");
            RuleFor(x => x.CustomerLastName).NotNull().NotEmpty().WithMessage("Customer Name is required.");
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.CustomerMailId).EmailAddress();
        }
    }
}
