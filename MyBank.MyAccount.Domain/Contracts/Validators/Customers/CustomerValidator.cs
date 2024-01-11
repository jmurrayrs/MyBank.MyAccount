using FluentValidation;
using MyBank.MyAccount.Domain.Aggregates.Costumers;

namespace MyBank.MyAccount.Domain.Contracts.Validators.Customers
{
    public class CustomerValidator
        : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            // RuleFor(customer => customer.Identification.Name)
            //     .NotEmpty().WithMessage("The name is necessary");

            // RuleFor(customer => customer.Identification.LastName)
            //     .NotEmpty().WithMessage("The lastname is necessary");

            // RuleFor(customer => customer.Document.CPF)
            //     .NotEmpty().WithMessage("The cpf is necessary");

            // RuleFor(customer => customer.Birthday)
            //     .NotEmpty().WithMessage("The born date is necessary");

            // RuleFor(customer => customer.Age)
            //     .GreaterThan(17).WithMessage("You must be 18 years old");
        }
    }
}