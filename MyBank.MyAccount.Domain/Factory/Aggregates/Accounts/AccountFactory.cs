using MyBank.MyAccount.Domain.Aggregates.Accounts;
using MyBank.MyAccount.Domain.Aggregates.Costumers;

namespace MyBank.MyAccount.Domain.Factory.Aggregates.Accounts;
public sealed class AccountFactory
{
    public static Account Create(
            Customer customer,
            decimal balance
    ) => new Account(
            customer,
            balance
        );
}

