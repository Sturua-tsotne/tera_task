using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Tera.Application.Common.Middlewares;

public class JwtMiddelweare(RequestDelegate next)
{

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken?.Claims != null)
            {
                var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "sub" || claim.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    context.Items["UserId"] = userIdClaim.Value;
                }
            }
        }

        await next(context);

    }
}
