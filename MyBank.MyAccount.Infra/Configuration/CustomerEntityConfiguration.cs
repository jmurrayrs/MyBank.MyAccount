using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.MyAccount.Crosscutting.Enums.DomainDataTypes.Documents;
using MyBank.MyAccount.Domain.Aggregates.Costumers;

public class CustomerEntityConfiguration
    : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(customer => customer.Id);

        builder.OwnsOne(customer => customer.Identification, identification =>
        {
            identification.Property(i => i.Name).IsRequired().HasMaxLength(10);
            identification.Property(i => i.LastName).IsRequired().HasMaxLength(50);

        });

        builder.OwnsOne(customer => customer.Document, document =>
        {
            document.Property(d => d.Number).IsRequired().HasMaxLength(20);
            document.Property(d => d.DocumentType)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (EnumDocumentType)Enum.Parse(typeof(EnumDocumentType), v)
            );
        });

        builder.Property(customer => customer.Birthday).IsRequired();
        builder.Ignore(customer => customer.Age);
    }
}
