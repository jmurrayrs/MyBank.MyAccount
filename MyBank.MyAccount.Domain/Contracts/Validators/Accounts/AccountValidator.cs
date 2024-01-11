using FluentValidation;
using MyBank.MyAccount.Domain.Aggregates.Accounts;

namespace MyBank.MyAccount.Domain.Contracts.Validators.Accounts
{
    public class AccountValidator
        : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            // RuleFor(account => account.Balance)
            //     .GreaterThan(0).WithMessage("The balance is incorrect");

            // RuleFor(account => account.Identification.LastName)
            //     .NotEmpty().WithMessage("The lastname is necessary");

            // RuleFor(account => account.Document.CPF)
            //     .NotEmpty().WithMessage("The cpf is necessary");

            // RuleFor(account => account.Birthday)
            //     .NotEmpty().WithMessage("The born date is necessary");

            // RuleFor(account => account.Age)
            //     .GreaterThan(17).WithMessage("You must be 18 years old");
        }
    }
}