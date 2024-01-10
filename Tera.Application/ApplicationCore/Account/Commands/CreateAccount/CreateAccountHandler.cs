using AutoMapper;
using MediatR;
using Tera.Application.Common.Helpers;
using Tera.Application.Common.Models;
using Tera.Domain.Entities;
using Tera.Domain.Interfaces.Repository;

namespace Tera.Application.ApplicationCore.Account.Commands.CreateAccount;

public class CreateAccountHandler(IAccountRepository accountRepo, IUserRepository userRepo, IMapper mapper) : IRequestHandler<CreateAccountRequest, ErrorModel>
{
    public async Task<ErrorModel> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var response= new ErrorModel();
        var user = await userRepo.GetByIdAsync(request.UserId);
        if (user is null)
        {
            response.StatusCodes= System.Net.HttpStatusCode.BadRequest;
            response.Message = ErrorHelper.Messages.IncorectData;
            return response;
        }

        await accountRepo.AddAsync(mapper.Map<AccountModel>(request));

        return response;
    }
}
