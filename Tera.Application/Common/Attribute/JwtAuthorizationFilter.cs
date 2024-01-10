using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tera.Application.Common.Interface;

namespace Tera.Application.Common.Attribute;

public class JwtAuthorizationFilter(ITokenService TokenValidationService) : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var token = authorizationHeader.Substring("Bearer ".Length).Trim();

        if (!TokenValidationService.ValidateToken(token))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}