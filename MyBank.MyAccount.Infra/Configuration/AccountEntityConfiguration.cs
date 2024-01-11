using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBank.MyAccount.Domain.Aggregates.Accounts;

namespace MyBank.MyAccount.Infra.Configuration
{
    public class AccountEntityConfiguration
        : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Balance).HasPrecision(9, 2);

            builder.HasOne(x => x.Customer);
        }
    }
}