
using AutoMapper;
using MyBank.MyAccount.Application.Models.Customers;
using MyBank.MyAccount.Domain.ValueObjects;

namespace MyBank.MyAccount.Application.Profiles
{
    public class DocumentProfile
        : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentModel, Document>();
        }
    }
}