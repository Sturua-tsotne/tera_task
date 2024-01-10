using Microsoft.AspNetCore.Mvc;

namespace Tera.Application.Common.Attribute;

public class JwtAuthorizationAttribute : TypeFilterAttribute
{
    public JwtAuthorizationAttribute() : base(typeof(JwtAuthorizationFilter))
    {
    }
}