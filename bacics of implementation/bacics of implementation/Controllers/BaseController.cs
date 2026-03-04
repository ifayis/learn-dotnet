using Microsoft.AspNetCore.Mvc;

namespace bacics_of_implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        class Person
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        List<Person> person = new List<Person>
        {
            new Person {id = 1, name = "mhd"},
            new Person {id = 2, name = "fayis"}
        };
        [HttpGet]
        public IActionResult report()
        {
            return Ok(person);
        }
    }
}
