using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tera.Application.Common.Models;

namespace Tera.Application.ApplicationCore.Account.Commands.CreateTransfer;

public record TransferRequest : IRequest<ErrorModel>
{
    [JsonIgnore]
    [Required]
    public int UserId { get; set; }
    [Required]
    public int FromAccountId { get; set; }
    [Required]
    public int ToAccountId { get; set; }
    [Required]
    public decimal Amount { get; set; }
};
