using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tera.Domain.Interfaces.Email;
using Tera.Domain.Interfaces.Repository;
using Tera.Infrastructure.Data;
using Tera.Infrastructure.Data.repositories;
using Tera.Infrastructure.Email;

namespace Tera.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TeraDbContext>(options => options.UseInMemoryDatabase("TeraDbContext"));
        services.TryAddScoped<IUserRepository, UesrRepository>();
        services.TryAddScoped<IAccountRepository, AccountRepository>();
        services.TryAddScoped<IEmailSender, FakeEmailSender>();


        return services;
    }
}

