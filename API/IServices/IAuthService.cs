using API.DTOs.Auth;
using API.Entities;

namespace API.IServices
{
    public interface IAuthService
    {
        JwtDTO GenerateToken(User user);
    }
}
