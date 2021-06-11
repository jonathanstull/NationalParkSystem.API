using Microsoft.AspNetCore.Mvc;
using NationalParkSystem.Models;
using NationalParkSystem.Services;

namespace NationalParkSystem.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private IUserService _userService; // user service property

    public UsersController(IUserService userService) // instantiates the user service with the class
    {
      _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      var response = _userService.Authenticate(model); // sets the response to the result of custom authentication of the passed model (a JWT token)

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" }); // error handling
      
      return Ok(response);
    }
  }
}