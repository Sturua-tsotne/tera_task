using FluentValidation;
using Microsoft.OpenApi.Models;
using Tera.Application;
using Tera.Application.Common.Middlewares;
using Tera.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

services.AddControllers(option =>
{
    //option.Filters.Add(new JwtAuthorizationAttribute());
});
services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationLayerMarker>());
services.AddValidatorsFromAssemblyContaining<ApplicationLayerMarker>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "tera API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter your JWT token here",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
   {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
   });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddelweare>();
app.MapControllers();

app.Run();


