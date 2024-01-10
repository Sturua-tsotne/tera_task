using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tera.Application.ApplicationCore.Account.Commands.CreateAccount;
using Tera.Application.ApplicationCore.Account.Commands.CreateTransfer;
using Tera.Application.ApplicationCore.Account.Queries.GetAllaccount;
using Tera.Application.Common.Attribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tera.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[JwtAuthorization]
public class AccountController(ISender sender) : ControllerBase
{
    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer(TransferRequest request, CancellationToken cancellationToken = default)
    {
        request.UserId = Convert.ToInt32(HttpContext.Items["UserId"]);
        var response = await sender.Send(request, cancellationToken);
        return StatusCode(Convert.ToInt32(response.StatusCodes), response);
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        return Ok(await sender.Send(new GetAccountQuery(), cancellationToken));
    }

    [HttpPost]
    public async Task Post(CreateAccountRequest request, CancellationToken cancellationToken = default)
    {
        request.UserId =Convert.ToInt32( HttpContext.Items["UserId"]);
        await sender.Send(request, cancellationToken);
    }
}
