using MyBank.MyAccount.Domain.Aggregates.Costumers;
using MyBank.MyAccount.Domain.ValueObjects;

namespace MyBank.MyAccount.Domain.Factory.Aggregates.Customers;
public sealed class CustomerFactory
{
    public static Customer Create(
        Identification identification,
        Document document,
        DateTime birthday
    ) => new Customer(
            identification,
            document,
            birthday
        );
}
