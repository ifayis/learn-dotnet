using bacics_of_implementation.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("{names}")]
        public async Task<IActionResult> saygoodbye(string names)
        {
            return Ok(_HelloService.goodbye(names));
        }
    }
}
