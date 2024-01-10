namespace Tera.Application.Common.Helpers;

public static class PasswordHashHelper
{
    private const int SaltWorkFactor = 12;
    public static string HashPassword(this string password)
    {
        var sakt = BCrypt.Net.BCrypt.GenerateSalt(SaltWorkFactor);
        return BCrypt.Net.BCrypt.HashPassword(password, sakt);
    }

    public static bool VerifyPassword(this string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

}
