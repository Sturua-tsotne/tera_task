using Microsoft.EntityFrameworkCore;
using Tera.Domain.Entities;
using Tera.Domain.Interfaces.Repository;

namespace Tera.Infrastructure.Data.repositories;

public class UesrRepository(TeraDbContext context) : BaseRepository<UserModel>(context), IUserRepository
{
    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        return await _dbSet.SingleOrDefaultAsync(x => x.Email == email);
    }
}
