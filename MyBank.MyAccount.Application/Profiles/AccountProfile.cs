

using AutoMapper;
using MyBank.MyAccount.Application.Models.Accounts;
using MyBank.MyAccount.Domain.Aggregates.Accounts;


namespace MyBank.MyAccount.Application.Profiles
{
    public class AccountProfile
        : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, Account>();
        }
    }
}