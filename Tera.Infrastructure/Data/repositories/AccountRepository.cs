using Tera.Domain.Entities;
using Tera.Domain.Interfaces.Repository;

namespace Tera.Infrastructure.Data.repositories;

public class AccountRepository(TeraDbContext context) : BaseRepository<AccountModel>(context), IAccountRepository
{
}
