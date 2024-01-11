using System.Reflection;

using Microsoft.EntityFrameworkCore;

using HaidaiTech.Notificator.Interfaces;
using HaidaiTech.Notificator.NotificationContextMessages;
using HaidaiTech.Notificator.NotificationContextPattern;

using MediatR;

using MyBank.MyAccount.Application.Commands;
using MyBank.MyAccount.Domain.Interfaces.Repository;
using MyBank.MyAccount.Infra.Context;
using MyBank.MyAccount.Infra.Repository;
using MyBank.MyAccount.Infra.UoW;
using MyBank.MyAccount.Domain.Aggregates.Accounts;
using MyBank.MyAccount.Domain.Aggregates.Costumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext))));

builder.Services.AddScoped(typeof(INotificationContext<NotificationContextMessage>), typeof(NotificationContext<NotificationContextMessage>));
builder.Services.AddTransient(typeof(IRepository<Account>), typeof(GenericRepository<Account>));
builder.Services.AddTransient(typeof(IRepository<Customer>), typeof(GenericRepository<Customer>));
builder.Services.AddScoped(typeof(IRequestHandler<InsertCustomerCommand, Guid>), typeof(InsertCustomerCommandHandler));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped<DbContext, AppDbContext>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = Assembly.Load("MyBank.MyAccount.Application");

builder.Services.AddAutoMapper(assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
    cfg.Lifetime = ServiceLifetime.Scoped;
});

try
{
    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{

    var g = ex;

}