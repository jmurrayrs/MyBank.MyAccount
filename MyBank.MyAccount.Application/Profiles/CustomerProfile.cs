using AutoMapper;
using MyBank.MyAccount.Application.Models.Customers;
using MyBank.MyAccount.Domain.Aggregates.Costumers;

namespace MyBank.MyAccount.Application.Profiles
{
    public class CustomerProfile
        : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>();
        }
    }
}