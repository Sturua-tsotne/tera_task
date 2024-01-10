using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tera.Application.Common.Models;

namespace Tera.Application.ApplicationCore.Account.Commands.CreateAccount;

public record CreateAccountRequest : IRequest<ErrorModel>
{
    [JsonIgnore]
    [Required]
    public int UserId { get; set; }
    [Required]
    public decimal Balance { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}
