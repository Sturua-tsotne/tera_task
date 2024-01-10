using System.Reflection;
using Tera.Domain.Entities;

namespace Tera.Domain.Interfaces.Repository;

public interface IUserRepository : IBaseRepository<UserModel>
{
    Task<UserModel?> GetByEmailAsync(string email);
}
