using Microsoft.IdentityModel.Tokens;
using ReservasHotelPetAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ReservasHotelPetAPI.Services
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GenerateAccesToken(IEnumerable<Claim> claims, IConfiguration config)
        {
            var key = config.GetSection("JWT").GetValue<string>("SecretKey") ?? throw new InvalidOperationException("Invalid secret key");

            var privatekey = Encoding.UTF8.GetBytes(key);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(privatekey), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(config.GetSection("JWT").GetValue<double>("TokenValidityInMinutes")),
                Audience = config.GetSection("JWT").GetValue<string>("ValidAudience"),
                Issuer = config.GetSection("JWT").GetValue<string>("ValidIssuer"),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return token;
        }

        public string GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[128];

            using var randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(secureRandomBytes);

            var refreshToken = Convert.ToBase64String(secureRandomBytes);

            return refreshToken;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration config)
        {
            var secretkey = config.GetSection("JWT").GetValue<string>("SecretKey") ?? throw new InvalidOperationException("Invalid secret key");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
