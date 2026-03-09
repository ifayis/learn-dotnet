using bacics_of_implementation.Models;
using Microsoft.AspNetCore.Mvc;

namespace bacics_of_implementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        static List<Auth> user = new List<Auth>()
        {

        };
        [HttpPost("login")]
        public IActionResult Login([FromBody] Auth data)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            user.Add(data);
            return Ok("login successful");
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(user);
        }
    }
}
