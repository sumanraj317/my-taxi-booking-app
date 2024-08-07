using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxiBookingApi.Models;
using TaxiBookingApi.Services;

namespace TaxiBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var createdUser = await _authService.Register(user);
            if (createdUser == null)
            {
                return Conflict("Email already exists.");
            }

            return Ok(createdUser);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            var user = _authService.Login(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(user);
        }
    }
}
