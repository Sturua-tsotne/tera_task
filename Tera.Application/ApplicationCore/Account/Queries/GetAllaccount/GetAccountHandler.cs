using AutoMapper;
using MediatR;
using Tera.Application.Common.Models.Response;
using Tera.Domain.Interfaces.Repository;

namespace Tera.Application.ApplicationCore.Account.Queries.GetAllaccount;

public class GetAccountHandler(IAccountRepository account, IMapper mapper) : IRequestHandler<GetAccountQuery, IEnumerable<AccountResponse>>
{
    public async Task<IEnumerable<AccountResponse>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<AccountResponse>>(await account.GetAllAsync());
    }
}
