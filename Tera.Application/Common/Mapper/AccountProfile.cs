using AutoMapper;
using Tera.Application.ApplicationCore.Account.Commands.CreateAccount;
using Tera.Application.Common.Models.Response;
using Tera.Domain.Entities;

namespace Tera.Application.Common.Mapper;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountModel, AccountResponse>();
        CreateMap<CreateAccountRequest, AccountModel>();
    }
}
