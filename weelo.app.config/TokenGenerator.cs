using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Weelo.App.Api.Config
{
    public static class TokenGenerator
    {
        public static String Generate(String UserName, int UserID)
        {
            var key = TokenConfiguration.GetSecretKey();
            var claims = new ClaimsIdentity(new Claim[] {
                            new Claim(ClaimTypes.Name, UserName),
                            new Claim(ClaimTypes.PrimarySid, UserID.ToString())
                        });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(AppConfiguration.Instance.Read("TokenMinutesExpire"))),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }


    }
}
