using MediatR;
using Tera.Application.Common.Helpers;
using Tera.Application.Common.Interface;
using Tera.Application.Common.Models;
using Tera.Application.Common.Models.Response;
using Tera.Domain.Interfaces.Repository;

namespace Tera.Application.ApplicationCore.Users.Queries.Auth;

public class AuthHandler(IUserRepository repository, ITokenService service) : IRequestHandler<AuthRequest, Maybe<AuthResponse>>
{
    public async Task<Maybe<AuthResponse>> Handle(AuthRequest request, CancellationToken cancellationToken)
    {
        var response = new Maybe<AuthResponse>()
        {
            Result = new AuthResponse()
        };
        var user = await repository.GetByEmailAsync(request.Email);

        if (user is null)
        {
            response.Message = ErrorHelper.Messages.UserNotFound;
            response.StatusCodes = System.Net.HttpStatusCode.BadRequest;
            return response;
        }

        if (!request.Password.VerifyPassword(user.PasswordHash))
        {
            response.Message = ErrorHelper.Messages.passwordIsIncorect;
            response.StatusCodes = System.Net.HttpStatusCode.BadRequest;
            return response;
        }

        response.Result.Token = service.GenerateToken(user.Id.ToString(), user.Email);

        return response;

    }
}
