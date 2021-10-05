
using MyProject.Domain.Identity;
using MyProject.Domain.Token.JWT;
using System.Threading.Tasks;

namespace MyProject.Services.DomainServices.Token
{
    public interface IJwtManager
    {
        Task<AccessToken> GenerateAsync(User user);
        string ReadToken(string jwtInput);
        string GetEmailFromToken(string JwtToken);
    }
}