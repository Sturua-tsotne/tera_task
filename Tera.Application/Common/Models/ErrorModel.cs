using System.Text.Json.Serialization;
using System.Net;

namespace Tera.Application.Common.Models;

public class ErrorModel(string message = default)
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = message;

    [System.Text.Json.Serialization.JsonIgnore]
    public HttpStatusCode StatusCodes { get; set; }= HttpStatusCode.OK;

    public override string ToString()
    {
        return System.Text.Json.JsonSerializer.Serialize(this);
    }
}
