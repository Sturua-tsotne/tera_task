using MediatR;
using Tera.Application.Common.Models;
using Tera.Application.Common.Models.Request;
using Tera.Application.Common.Models.Response;

namespace Tera.Application.ApplicationCore.Users.Queries.Auth;

public record AuthRequest : BaseAuthUserRequest, IRequest<Maybe<AuthResponse>>;
