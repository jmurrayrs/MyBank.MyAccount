using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBank.MyAccount.Application.Commands;
using MyBank.MyAccount.Domain.Interfaces.Repository;
using MyBank.MyAccount.Infra.Context;
using MyBank.MyAccount.Infra.Customers;
using Notificator.Interfaces;
using Notificator.NotificationContextPattern;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<INotificationContext, NotificationContext>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped(typeof(IRequestHandler<InsertCustomerCommand, Guid>), typeof(InsertCustomerCommandHandler));



builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext))));

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

var app = builder.Build();

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