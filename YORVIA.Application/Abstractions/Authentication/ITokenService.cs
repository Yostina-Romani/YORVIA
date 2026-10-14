namespace YORVIA.Application.Abstractions.Authentication
{
    public interface ITokenService
    {
        string GenerateToken(string userid, string email,IEnumerable<string>roles);
    }
}
