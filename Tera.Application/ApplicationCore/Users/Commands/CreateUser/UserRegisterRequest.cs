using FluentValidation;
using MediatR;
using Tera.Application.Common.Helpers;
using Tera.Application.Common.Models;
using Tera.Application.Common.Models.Request;
using Tera.Application.Common.Models.Response;

namespace Tera.Application.ApplicationCore.Users.Commands.CreateUser;

public record UserRegisterRequest() : BaseAuthUserRequest, IRequest<Maybe<RegisterResponse>>;

public class RegisterUserValidator : AbstractValidator<UserRegisterRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Password).NotEmpty().WithMessage(ErrorHelper.Messages.RequiredPassword);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ErrorHelper.Messages.InvalidEmail);
    }
}