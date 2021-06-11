using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using NationalParkSystem.Entities;
using NationalParkSystem.Helpers;
using NationalParkSystem.Models;

namespace NationalParkSystem.Services
{
  public interface IUserService
  {
    AuthenticateResponse Authenticate(AuthenticateRequest model);
  }

  public class UserService : IUserService
  {
    private List<User> _users = new List<User>
    {
      new User { Id = 1, FirstName = "Jonathan", LastName = "Stull", Username = "Jonathan", Password = "jonathan" }         // hard-coded user; this implementation doesn't handle user registration
    };

    private readonly AppSettings _appSettings;                                                                              // appsettings property; correlated with AppSettings class, which has property Secret

    public UserService(IOptions<AppSettings> appSettings)                                                                   // instantiates class with user secret in appsettings.json
    {
      _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)                                                     // custom authentication method
    {
      var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);                 // validates user with username and password

      if (user == null) return null;                                                                                        // returns nothing if no input

      var token = generateJwtToken(user);                                                                                   // calls custom method to generate JWT

      return new AuthenticateResponse(user, token);                                                                         // returns the user and the token in the response
    }

    private string generateJwtToken(User user)                                                                              // generates the JWT token, which remains active for 7 days
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
  }
}