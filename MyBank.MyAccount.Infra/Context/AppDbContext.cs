using Microsoft.EntityFrameworkCore;
using MyBank.MyAccount.Domain.Aggregates.Costumers;

namespace MyBank.MyAccount.Infra.Context
{
    public class AppDbContext
        : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
        }
    }
}