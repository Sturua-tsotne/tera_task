using MediatR;
using System.Transactions;
using Tera.Application.Common.Helpers;
using Tera.Application.Common.Models;
using Tera.Domain.Interfaces.Repository;

namespace Tera.Application.ApplicationCore.Account.Commands.CreateTransfer;

public class TransferHandler(IAccountRepository account) : IRequestHandler<TransferRequest, ErrorModel>
{
    public async Task<ErrorModel> Handle(TransferRequest request, CancellationToken cancellationToken)
    {

        var response = new ErrorModel();
        var fromAccount = await account.GetByIdAsync(request.FromAccountId);
        if (fromAccount.UserId != request.UserId)
        {
            response.StatusCodes = System.Net.HttpStatusCode.BadRequest;
            response.Message = ErrorHelper.Messages.IncorectData;
            return response;
        }
        var toAccount = await account.GetByIdAsync(request.ToAccountId);

        if (fromAccount == null || toAccount == null)
        {
            response.StatusCodes = System.Net.HttpStatusCode.BadRequest;
            response.Message = ErrorHelper.Messages.IncorectData;
            return response;
        }

        if (fromAccount.Balance < request.Amount)
        {
            response.StatusCodes = System.Net.HttpStatusCode.BadRequest;
            response.Message = ErrorHelper.Messages.NotMoney;
            return response;
        }

        using (var transaction = new TransactionScope())
        {

            fromAccount.Balance -= request.Amount;
            toAccount.Balance += request.Amount;

            await account.UpdateAsync(fromAccount);
            await account.UpdateAsync(toAccount);

            transaction.Complete();
        }

        return response;
    }
}
