using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace week2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class helloController : ControllerBase
    {
        [HttpGet] // attribute
        public IActionResult Get()
        {
            return Ok("hello, dotnet core from web API");
        }
    }
}
