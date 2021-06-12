using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NationalParkSystem.Entities;
using NationalParkSystem.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NationalParkSystem.Authorization
{
  public interface IJwtUtils
  {
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
  }

  public class JwtUtils : IJwtUtils
  {
    private readonly AppSettings _appSettings;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
      _appSettings = appSettings.Value;
    }

    public string GenerateToken(User user)                                                                                 // generates the JWT token, which remains active for 7 days
    {
      var tokenHandler = new JwtSecurityTokenHandler();                                                                     // instantiates a token handler
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);                                                               // generates array of bytes converted from the secret in appsettings.json
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),                                        // instatiates a user claim for this user
        Expires = DateTime.UtcNow.AddDays(7),                                                                               // sets an expiration for the JWT
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)  // generates security key based on the converted secret
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);                                                                // creates the JWT token with required attributes
      return tokenHandler.WriteToken(token);                                                                                // returns the token to the authentication method
    }

    public int? ValidateToken(string token)
    {
      if (token == null)
          return null;

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      try
      {
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

        return userId;
      }
      catch
      {
        return null;
      }
    }
  }
}