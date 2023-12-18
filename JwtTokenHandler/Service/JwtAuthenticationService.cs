using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Wiz.Token.Service;

public class JwtAuthenticationService : IJwtAuthenticationService
{

    private readonly IJwtParams _jwtParams;
    private static readonly string token = "";


    public JwtAuthenticationService(IJwtParams jwtParams)
    {
        _jwtParams = jwtParams;
    }

    public string GenerateToken(string username, string userType, string agencyCode)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes(_jwtParams.GetJwtKey());

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, userType),
                new Claim("agencyId", agencyCode)
            }),

            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string returnToken = tokenHandler.WriteToken(token);

        return returnToken;
    }


}
