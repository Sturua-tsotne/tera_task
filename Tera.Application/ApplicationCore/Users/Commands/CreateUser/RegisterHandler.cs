using AutoMapper;
using MediatR;
using Tera.Application.Common.Helpers;
using Tera.Application.Common.Models;
using Tera.Application.Common.Models.Response;
using Tera.Domain.Entities;
using Tera.Domain.Interfaces.Repository;

namespace Tera.Application.ApplicationCore.Users.Commands.CreateUser;

public class RegisterHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<UserRegisterRequest, Maybe<RegisterResponse>>
{
    public async Task<Maybe<RegisterResponse>> Handle(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var response = new Maybe<RegisterResponse>();

        if (await repository.GetByEmailAsync(request.Email) is not null)
        {
            response.Message = ErrorHelper.Messages.EmailAlreadyExists;
            response.StatusCodes = System.Net.HttpStatusCode.BadRequest;
            return response;
        }
        request.Password = request.Password.HashPassword();
        response.Result = mapper.Map<RegisterResponse>(await repository.AddAsync(mapper.Map<UserModel>(request)));

        return response;
    }
}
