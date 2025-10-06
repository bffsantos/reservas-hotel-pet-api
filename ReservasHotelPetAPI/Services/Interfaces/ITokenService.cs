using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ReservasHotelPetAPI.Services.Interfaces
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateAccesToken(IEnumerable<Claim> claims, IConfiguration config);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(String token, IConfiguration config);
    }
}
