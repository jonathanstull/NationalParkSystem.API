using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using NationalParkSystem.Authorization;
using NationalParkSystem.Entities;
using NationalParkSystem.Helpers;
using NationalParkSystem.Models.Users;


namespace NationalParkSystem.Services
{
  public interface IUserService
  {
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(RegisterRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
  }

  public class UserService : IUserService
  {
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    // private readonly AppSettings _appSettings;                                                                           // appsettings property; correlated with AppSettings class, which has property Secret

    public UserService(DataContext context, IJwtUtils jwtUtils, IMapper mapper)                                             // instantiates class with user secret in appsettings.json
    {
      _context = context;
      _jwtUtils = jwtUtils;
      _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)                                                     // custom authentication method
    {
      var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);                                         // calls the user to the current context

      if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))                                            // validates
          throw new AppException("Username or password is incorrect");

      var response = _mapper.Map<AuthenticateResponse>(user);
      response.JwtToken = _jwtUtils.GenerateToken(user);                                                                    // calls custom method to generate JWT

      return response;                                                                                                      // returns the user and the token in the response
    }

    public IEnumerable<User> GetAll()
    {
      return _context.Users;
    }

    public User GetById(int id)
    {
      return getUser(id);
    }

    public void Register(RegisterRequest model)
    {
      if (_context.Users.Any(x => x.Username == model.Username))
          throw new AppException("Username '" + model.Username + "' is already taken");                             // checks to see if username already exists
    
      var user = _mapper.Map<User>(model);

      user.PasswordHash = BCryptNet.HashPassword(model.Password);

      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
      var user = getUser(id);

      if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
          throw new AppException("Username '" + model.Username + "' is already taken");

      if (!string.IsNullOrEmpty(model.Password))
          user.PasswordHash = BCryptNet.HashPassword(model.Password);

      _mapper.Map(model, user);
      _context.Users.Update(user);
      _context.SaveChanges();
    }

    public void Delete(int id)
    {
      var user = getUser(id);
      _context.Users.Remove(user);
      _context.SaveChanges();
    }

    private User getUser(int id)
    {
      var user = _context.Users.Find(id);
      if (user == null) throw new KeyNotFoundException("User not found");
      return user;
    }
  }
}