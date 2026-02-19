using bacics_of_implementation.Service;
using Microsoft.AspNetCore.Mvc;

namespace bacics_of_implementation.Controllers
{
    [ApiController]
    [Route ("api/[Controller]")]
    public class HelloController : Controller
    {
        private readonly IHelloService _HelloService;

        public HelloController(IHelloService HelloService)
        {
            _HelloService = HelloService;
        }

        [HttpGet("{name}")]
        public IActionResult SayHello(string name)
        {
            var result = _HelloService.SayHello(name);
            return Ok(result);
        }
    }
}
