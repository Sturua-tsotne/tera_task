using MediatR;
using Tera.Application.Common.Models.Response;

namespace Tera.Application.ApplicationCore.Account.Queries.GetAllaccount;
public record GetAccountQuery : IRequest<IEnumerable<AccountResponse>>;
