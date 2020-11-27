using FluentValidation;
using Service.Integration.Models;

namespace Service.Integration.Validators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerName).NotNull().NotEmpty().WithMessage("Customer Name is required.");
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Address is required.");
        }
    }
}
