using FluentValidation;
using FluentValidation.Results;

namespace MyBank.MyAccount.Crosscutting.Validators.Domain;
public class Contract<T>
{
    private readonly IValidator<T> _validator;

    public Contract(IValidator<T> validator)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public ValidationResult Validate(T instance)
        => _validator.Validate(instance);

}