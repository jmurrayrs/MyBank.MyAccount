using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBank.MyAccount.Domain.Aggregates.Accounts;
using MyBank.MyAccount.Domain.Aggregates.Costumers;
using MyBank.MyAccount.Infra.Configuration;

namespace MyBank.MyAccount.Infra.Context
{
    public class AppDbContext
        : DbContext
    {

        public const string DEFAULT_SCHEMA = nameof(MyBank.MyAccount);
        public static string DEFAULT_MIGRATIONS_TABLE => "__EFMigrationsHistory";
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);

            modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var connectionString = builder.GetConnectionString(nameof(AppDbContext));

            optionsBuilder.UseNpgsql(
                connectionString,
                x => x.MigrationsHistoryTable(AppDbContext.DEFAULT_MIGRATIONS_TABLE,
                nameof(MyBank.MyAccount)));

            base.OnConfiguring(optionsBuilder);
        }

        public override void Dispose() =>
            base.Dispose();
    }
}