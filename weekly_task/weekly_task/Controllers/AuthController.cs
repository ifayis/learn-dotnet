using Microsoft.AspNetCore.Mvc;
using weekly_Task.Models;
using weekly_Task.Services;

namespace weekly_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new();
        private readonly JwtService _jwt;

        public AuthController(JwtService jwt)
        {
            _jwt = jwt;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var user = new User
            {
                Id = users.Count + 1,
                Username = request.Username,
                Password = request.Password,
                Role = request.Role
            };
            users.Add(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = users.SingleOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = _jwt.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
