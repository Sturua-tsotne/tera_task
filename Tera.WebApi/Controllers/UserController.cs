using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tera.Application.ApplicationCore.Users.Commands.CreateUser;
using Tera.Application.ApplicationCore.Users.Queries.Auth;
using Tera.Application.Common.Models.Response;

namespace Tera.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : ControllerBase
{

    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request, CancellationToken cancellationToken = default)
    {
        var response = await sender.Send(request, cancellationToken);
        return StatusCode(Convert.ToInt32(response.StatusCodes), response);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Login([FromBody] AuthRequest request, CancellationToken cancellationToken = default)
    {
        var response = await sender.Send(request, cancellationToken);
        return StatusCode(Convert.ToInt32(response.StatusCodes), response);
    }

}
