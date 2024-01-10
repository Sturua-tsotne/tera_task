namespace Tera.Application.Common.AppSettings;

public class AppSettings
{
    public Jwt jwt { get; set; } = null!;

}

public class Jwt
{
    public string SecretKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}
