namespace MyBank.MyAccount.Application.Models.Customers;

public sealed class CustomerModel
{
    public IdentificationModel Identification { get; set; } = default!;
    public DocumentModel Document { get; set; } = default!;
    public DateTime Birthday { get; set; } = default!;
}
