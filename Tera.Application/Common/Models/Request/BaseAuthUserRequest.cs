using System.ComponentModel.DataAnnotations;

namespace Tera.Application.Common.Models.Request;

public record BaseAuthUserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    //TODO: add SensitiveData atribute
    public string Password { get; set; } = null!;
}

