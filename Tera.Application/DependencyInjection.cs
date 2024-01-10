using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tera.Application.Common.AppSettings;
using Tera.Application.Common.Helpers;
using Tera.Application.Common.Interface;
using Tera.Application.Service;
using Microsoft.Extensions.Logging;

namespace Tera.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddLogging(builder =>
        {
            builder.AddConsole();
        });
      
        services.Configure<AppSettings>(configuration.GetSection(Helper.Key.AppSettings));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<ITokenService, TokenService>();

       
        return services;
    }
}
