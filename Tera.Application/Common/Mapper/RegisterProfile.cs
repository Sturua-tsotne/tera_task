using AutoMapper;
using Tera.Application.ApplicationCore.Users.Commands.CreateUser;
using Tera.Application.Common.Models.Response;
using Tera.Domain.Entities;

namespace Tera.Application.Common.Mapper;

public class RegisterProfile : Profile
{
    public RegisterProfile()
    {
        CreateMap<UserRegisterRequest, UserModel>().ForMember(u => u.PasswordHash, r => r.MapFrom(src => src.Password));
        CreateMap<UserModel, RegisterResponse>();
    }
}
