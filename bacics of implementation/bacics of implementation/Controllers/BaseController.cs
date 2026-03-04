using Microsoft.AspNetCore.Mvc;
using static bacics_of_implementation.Controllers.BaseController;

namespace bacics_of_implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public class Person
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        static List<Person> person = new List<Person>
        {
            new Person {id = 1, name = "mhd"},
            new Person {id = 2, name = "fayis"}
        };
        [HttpGet]
        public IActionResult report()
        {
            return Ok(person);
        }

        [HttpPost]
        public IActionResult addreport(Person per)
        {
            person.Add(per);
            return Ok();
        }
    }
}
