using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NationalParkSystem.Authorization;
using NationalParkSystem.Helpers;
using NationalParkSystem.Models.Users;
using NationalParkSystem.Services;

namespace NationalParkSystem.Controllers
{
  // [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private IUserService _userService; // user service property
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public UsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings) // instantiates the user service with the class
    {
      _userService = userService;
      _mapper = mapper;
      _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      var response = _userService.Authenticate(model); // sets the response to the result of custom authentication of the passed model (a username and password)
      
      return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
      _userService.Register(model);
      return Ok(new { message = "Registration successful" });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var users= _userService.GetAll();
      return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var user = _userService.GetById(id);
      return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
      _userService.Update(id, model);
      return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _userService.Delete(id);
      return Ok(new { message = "User deleted successfully" });
    }
  }
}