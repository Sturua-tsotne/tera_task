namespace Tera.Application.Common.Interface;

public interface ITokenService
{
    string GenerateToken(string userId, string username);
    bool ValidateToken(string token);
}