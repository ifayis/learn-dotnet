using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace week2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hellodotnet : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello, dotnet core web API.");
        }
    }
}
